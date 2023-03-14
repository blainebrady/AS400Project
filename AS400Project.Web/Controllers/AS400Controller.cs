using Microsoft.AspNetCore.Mvc;
using AS400Project.Data;
using AS400Project.Web.Models;
using System.Diagnostics.CodeAnalysis;
using AS400Project.Services;

namespace AS400Project.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AS400Controller<TEntity> : IBaseController<TEntity>
        where TEntity : class, IImport, new()
    {
        public AS400Controller([NotNull] FileConvert<TEntity> service, IConfiguration configuration) : base(service, configuration)
        {

        }
    }
}
