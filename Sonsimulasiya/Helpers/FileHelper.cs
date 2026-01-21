namespace Sonsimulasiya.Helpers
{
    public static class FileHelper
    {
        public static bool CheckSize(this IFormFile file, int mb)
        {
            return file.Length <= mb * 1024 * 1024;
        }

        public static bool CheckType(this IFormFile file, string type)
        {
            return file.ContentType.Contains("image");
        }

        

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
