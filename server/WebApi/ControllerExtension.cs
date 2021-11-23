namespace WebApi
{
    using System.Net;
    using Application.ApiResponse;
    using Microsoft.AspNetCore.Mvc;

    public static class ControllerExtension
    {
        public static ActionResult Handle<TData>(this ControllerBase controllerBase, ApiResponse<TData> response, HttpStatusCode successStatusCode)
            where TData : class
        {
            return response.Success ? controllerBase.StatusCode((int)successStatusCode, response.Data) : controllerBase.StatusCode((int)response.Error.StatusCode, response.Error);
        }

        public static ActionResult Handle(this ControllerBase controllerBase, ApiResponse response)
        {
            return response.Success ? controllerBase.NoContent() : controllerBase.StatusCode((int)response.Error.StatusCode, response.Error);
        }
    }
}
