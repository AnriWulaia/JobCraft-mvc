using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

public class AuthorizeProfileAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            // if user is not authenticated, redirect to login page
            string returnUrl = context.HttpContext.Request.Path;
            context.Result = new RedirectToActionResult("Index", "Authorization", null);
        }
    }
}
