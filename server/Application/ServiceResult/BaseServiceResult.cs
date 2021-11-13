namespace Application.ServiceResult
{
    using System.Collections.Generic;
    using Application.Interfaces;

    public class BaseServiceResult : IServiceResult
    {
        public BaseServiceResult()
        {
            Errors = new List<string>();
        }

        public bool Success { get; set; }

        public ICollection<string> Errors { get; set; }
    }
}
