public class SecurityHeadersMiddleware {
    private readonly RequestDelegate _next;
    public SecurityHeadersMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context) {
        context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'");
        context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
        await _next(context);
    }
}
