namespace AS400Project.Web
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKey = "XApiKey";
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Request.Headers.TryGetValue(ApiKey, out var key))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("ApiKey is missing or incorrect");
                return;
            }
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>("apiKey");
            if (apiKey != key) {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized Client");
                return;
            }
            await _next(context);
        }

    }
}
