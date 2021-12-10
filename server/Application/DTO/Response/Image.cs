namespace Application.DTO.Response
{
    using System.IO;

    public class Image
    {
        public Stream Photo { get; set; }

        public string FileFormat { get; set; }
    }
}
