using AttributeExample.Exceptions;
using AttributeExample.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AttributeExample.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class UserInformationAttribute : ActionFilterAttribute
    {
        private const string HeaderKey = "user-name";
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Yalnızca iligli attribute tanımlanmış olan actionlar için çalışabilecek şekilde descriptor type kontrol ediliyor.
            if (!context.ActionDescriptor.FilterDescriptors.Any(d => d.Filter.GetType() == typeof(UserInformationAttribute)))
                return;

            // Request içerisindeki header alınıyor ve valide ediliyor.
            var headers = context.HttpContext.Request.Headers;

            if (!headers.Any() || headers is null || !headers.ContainsKey(HeaderKey))
                throw new MissingUsernameException();

            var username = headers[HeaderKey].ToString();

            // User nesnesi için bir instance oluşturulup Username propertysi dolduruluyor.
            var userModel = context.HttpContext.RequestServices.GetService(typeof(User)) as User;

            userModel.Username = username;
        }
    }
}
