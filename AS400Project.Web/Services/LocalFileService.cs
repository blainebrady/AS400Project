using Utilities;
namespace AS400Project.Web.Services
{
    public class LocalFileService
    {
        public LocalFileService()
        {
        }
        public List<string> getFile(IFormFile file)
        {

            //extract list of strings from the file
            return new List<string>();
        }
        public List<string> ProcessFiles(List<IFormFile> files, out string fileName)
        {
            //this function turns a text file into a string list, and determines the name of the file
            List<string> _res = new List<string>();
            string _fileName = "";
            files.ForEach(async file =>
            {
                //qualify the name of the file
                if (file.FileName.StringSafe().IndexOf("_") > 1)
                {
                    string[] fBreak = file.FileName.Split('_');

                    if (file.Length <= 1 || fBreak[1].StringSafe().Length > 0 || Utils.IsDate(fBreak[1].StringSafe()))
                        return;
                    try
                    {
                        DateTime dDate = Utils.ParseDateControlledReturn(fBreak[1].StringSafe());
                        _fileName = fBreak[0].StringSafe();
                        using (var reader = new StreamReader(file.OpenReadStream()))

                            while (!reader.EndOfStream)
                                //
                                _res.Add(await reader.ReadLineAsync());

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            });
            fileName = _fileName;
            return _res;
        }

        public string SaveFile(List<IFormFile> files, string subDirectory)
        {
            subDirectory = subDirectory ?? string.Empty;
            var target = Path.Combine("C:\\production\\", subDirectory);

            Directory.CreateDirectory(target);
            string _out = "";
            files.ForEach(async file =>
            {
                if (file.Length <= 0) return;
                var filePath = Path.Combine(target, file.FileName);
                target += @"\" + file.FileName;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    _out += stream.ToString();
                }

            });
            return _out;
        }
        
    }
}