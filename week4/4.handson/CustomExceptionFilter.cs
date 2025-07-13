using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var logPath = "logs/errors.txt";

            Directory.CreateDirectory("logs");
            File.AppendAllText(logPath, $"{DateTime.Now}: {exception.Message}\n");

            context.Result = new ObjectResult("An internal error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}
