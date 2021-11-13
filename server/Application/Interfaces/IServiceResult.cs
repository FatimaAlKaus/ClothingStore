namespace Application.Interfaces
{
    using System.Collections.Generic;

    public interface IServiceResult
    {
        bool Success { get; set; }

        ICollection<string> Errors { get; set; }
    }
}
