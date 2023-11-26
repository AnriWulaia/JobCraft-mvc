using JobCraft.Repositories.Abstract;

namespace JobCraft.Repositories.Implementation
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _enviroment;

        public FileService(IWebHostEnvironment enviroment)
        {
            _enviroment = enviroment;
        }

        public Tuple<int, string> SaveImage(IFormFile imageFile)
        {
            try
            {
                var wwwPath = _enviroment.WebRootPath;
                var path = Path.Combine(wwwPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Check the allowed extensions
                var ext = Path.GetExtension(imageFile.FileName)?.ToLower();
                var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png", ".bmp", ".tiff", ".webp" };
                if (ext == null || !allowedExtensions.Contains(ext))
                {
                    string msg = string.Format("Only {0} extensions are allowed", string.Join(" ", allowedExtensions));
                    return new Tuple<int, string>(0, msg);
                }


                // Resize image to 150x150 pixels
                using (var stream = new MemoryStream())
                {
                    imageFile.CopyTo(stream);
                    stream.Seek(0, SeekOrigin.Begin);

                    using (var image = Image.Load(stream))
                    {
                        image.Mutate(x => x.Resize(new ResizeOptions
                        {
                            Size = new Size(150, 150),
                            Mode = ResizeMode.Max
                        }));

                        // Create a unique filename
                        string uniqueString = Guid.NewGuid().ToString();
                        var newFileName = uniqueString + ext;
                        var filePath = Path.Combine(path, newFileName);

                        // Save the resized image
                        image.Save(filePath);

                        return new Tuple<int, string>(1, newFileName);
                    }
                }
            }
            catch (Exception)
            {
                return new Tuple<int, string>(0, "Error has occurred");
            }
        }


        public bool DeleteImage(string imageFileName)
        {
            try
            {
                var wwwPath = _enviroment.WebRootPath;
                var path = Path.Combine(wwwPath, "Uploads\\", imageFileName);
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
