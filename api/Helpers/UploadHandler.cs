namespace JobApplicationSystem.api.Helpers
{
    public class UploadHandler
    {
        public string Upload(IFormFile file)
        {
            List<string> validExtensions = new List<string>() { ".jpg", ".jpeg", ".png", ".pdf" };
            string extension = Path.GetExtension(file.FileName);

            if (!validExtensions.Contains(extension))
            {
                return $"Extension doesn't match expected types: {string.Join(',', validExtensions)}";
            }

            long size = file.Length;

            if (size > (5 * 1024 * 1024))
            {
                return "Maximum file size is 5 MB!";
            }

            string fileName = Guid.NewGuid().ToString() + extension;
            //string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            //using FileStream stream = new FileStream(Path.Combine(path,fileName), FileMode.Create);
            //file.CopyTo(stream);

            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
                file.CopyTo(stream);
            }
            catch (Exception ex)
            {
                return $"An error occurred while uploading the file: {ex.Message}";
            }

            return fileName;
        }
    }
}
