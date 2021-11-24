namespace Infrastructure.FileSystem
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    public class FileManager
    {
        public void SaveFile(IFormFile file, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.CreateNew))
            {
                file.CopyTo(stream);
            }
        }

        public async Task SaveFileAsync(IFormFile file, string path, CancellationToken cancellationToken = default)
        {
            using (FileStream stream = new FileStream(path, FileMode.CreateNew))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}
