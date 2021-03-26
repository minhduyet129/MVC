using Bai2MVc.Filters;
using Microsoft.AspNetCore.Mvc;

public class AuthorizeAttribute : TypeFilterAttribute
{
    public AuthorizeAttribute(string permission)
        : base(typeof(AuthorizeActionFilter))
    {
        Arguments = new object[] { permission };
    }
}