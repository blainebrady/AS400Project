using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using AS400Project.Data;
using AS400Project.Web.Services;
using AS400Project.Services;
using AS400Project.Services.Models;
using AS400Project.Web.Models;
using System.IO;

namespace AS400Project.Web.Controllers
{
    [ApiController]
    public abstract class IBaseController<TEntity> : Controller
        where TEntity : class, IImport
    {
        protected readonly FileConvert<TEntity> _service;
        protected readonly IConfiguration _configuration;

        protected IBaseController([NotNull] FileConvert<TEntity> service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }
        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> FileUpload([FromForm(Name = "files")] List<IFormFile> files, TEntity entity)
        {
            Settings settings = _configuration.GetValue<Settings>("settings");
            try
            {
                if (files != null && files.Count > 0)
                {
                    string fileName = "";
                    LocalFileService fs = new LocalFileService();

                    //save the file locally for posterity
                    string textString = fs.SaveFile(files, settings.fileDirectory);
                    //convert the space-delimited string to a generic collection
                    foreach (IFormFile file in files)
                    {
                        fileName = file.FileName;

                        if (fileName != null)
                        {
                            List<string> fileString = fs.getFile(file);
                            List<Diagram> pattern = convertBillingExport();
                            foreach (string fileLine in fileString)
                            {
                                var _billingExport = _service.ConvertToEntity(fileLine, pattern, new billingExport());
                                billingExport _billingEntity = (billingExport)Convert.ChangeType(entity, typeof(billingExport));
                                //now we have the actual class, which we can build with the other functions

                                billingExportFunctions _functions = new billingExportFunctions(_billingEntity);
                                _functions.HomeSavings();
                                _functions.Clear();
                                _functions.ReadAOMOB();
                                _functions.Form();
                                _functions.Custom90338();
                                _functions.Life();
                                _functions.Disability();
                                _functions.DebtProt();
                            }
                        }
                    }
                }
                else
                    return Ok("Upload failed");
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }


            return Ok(entity);
        }
        private List<Diagram> convertBillingExport()
        {
            List<Diagram> diagram = new List<Diagram>
            {
                new Diagram
                {
                    fieldName = "PgmNam",
                    start = 1,
                    end = 10
                },
                new Diagram
                {
                    fieldName = "NParms",
                    start = 37,
                    end = 39
                },
                new Diagram
                {
                    fieldName = "LibNam",
                    start = 81,
                    end = 90
                },
                new Diagram
                {
                    fieldName = "WsId",
                    start = 244,
                    end = 253
                },
                new Diagram
                {
                    fieldName = "UserId",
                    start = 254,
                    end = 263
                },
                new Diagram
                {
                    fieldName = "JobNbr",
                    start = 264,
                    end = 269
                },
                new Diagram
                {
                    fieldName = "JobDte",
                    start = 270,
                    end = 275
                },
                new Diagram
                {
                    fieldName = "SyDte",
                    start = 276,
                    end = 281
                },
                new Diagram
                {
                    fieldName = "JobTme",
                    start = 282,
                    end = 287
                },
                new Diagram
                {
                    fieldName = "CmpDte",
                    start = 288,
                    end = 293
                },
                new Diagram
                {
                    fieldName = "CmpTme",
                    start = 294,
                    end = 299
                },
                new Diagram
                {
                    fieldName = "CmpLvl",
                    start = 300,
                    end = 303
                },
                new Diagram
                {
                    fieldName = "SrcFil",
                    start = 304,
                    end = 313
                },
                new Diagram
                {
                    fieldName = "SrcLib",
                    start = 314,
                    end = 323
                },
                new Diagram
                {
                    fieldName = "SrcMbr",
                    start = 324,
                    end = 333
                }
            };
            return diagram;
        }
    }
}
