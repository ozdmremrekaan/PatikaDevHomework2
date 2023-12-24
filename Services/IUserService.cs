using Microsoft.AspNetCore.Http;

public interface IUserService
{
    bool IsUserAuthenticated(HttpContext httpContext);
}