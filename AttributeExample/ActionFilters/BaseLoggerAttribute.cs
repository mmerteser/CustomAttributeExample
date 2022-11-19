using Microsoft.AspNetCore.Mvc.Filters;

namespace AttributeExample.ActionFilters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class BaseLoggerAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Yalnızca iligli attribute tanımlanmış olan actionlar için çalışabilecek şekilde descriptor type kontrol ediliyor.
            if (!context.ActionDescriptor.FilterDescriptors.Any(d => d.Filter.GetType() == typeof(BaseLoggerAttribute)))
            {
                await next();
                return;
            }

            // Logger servisinin bir instance'ı oluşturuluyor.
            var logger = context.HttpContext.RequestServices.GetService<ILogger<BaseLoggerAttribute>>();

            // İlgili aciton başlamadan önce consol'a log basılıyor.
            logger.LogInformation("Before action execution with url: " + context.HttpContext.Request.Path);

            await next();

            // Action tamamlandıktan sonra konsola log basılıyor.
            logger.LogInformation("After action execution with status: " + context.HttpContext.Response.StatusCode);
        }
    }
}
