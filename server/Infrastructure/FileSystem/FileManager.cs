namespace Infrastructure.FileSystem
{
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class FileManager
    {
        public void SaveFile(Stream file, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.CreateNew))
            {
                file.CopyTo(stream);
            }
        }

        public async Task SaveFileAsync(Stream file, string path, CancellationToken cancellationToken = default)
        {
            using (FileStream stream = new FileStream(path, FileMode.CreateNew))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}
