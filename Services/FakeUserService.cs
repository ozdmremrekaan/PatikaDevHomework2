using Microsoft.AspNetCore.Http;

public class FakeUserService : IUserService
{
    public bool IsUserAuthenticated(HttpContext httpContext)
    {
        // Burada gerçek bir kullanıcı kimliği kontrolü yapılabilir, ancak basitleştirmek için her zaman giriş yapılmış sayalım.
        return true;
    }
}
