using System.Net;

namespace ProgramApp.Application;

public class AppResponse<T>
{
    public T? Result { get; set; }
    public string Message { get; set; } = "Operation Successfull!"; 
    public string Error { get; set; } = string.Empty;
    public bool IsSuccess { get; set; } = true;
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
}