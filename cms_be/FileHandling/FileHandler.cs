namespace cms_be.FileHandling
{
    public class FileHandler
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public FileHandler(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public string UploadImage(IFormFile file, string FolderName)
        {
            try
            {
                if (file != null)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Images\\" + FolderName))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Images\\" + FolderName);
                    }
                    string path = _environment.WebRootPath + "\\Images\\" + FolderName + "\\";
                    string imagePath = path + file.FileName;
                    using (FileStream fileStream = System.IO.File.Create(imagePath))
                    {
                        file.CopyTo(fileStream);
                        fileStream.Flush();
                    }

                    return file.FileName;
                }
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
