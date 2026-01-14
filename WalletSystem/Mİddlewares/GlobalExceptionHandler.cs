
namespace WalletSystem.Mİddlewares
{
    public class GlobalExceptionHandler : IMiddleware
    { 
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
            }
			catch (Exception ex )
			{
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode=ex switch
                {
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    InvalidOperationException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };
                await context.Response.WriteAsJsonAsync( new { error = ex.Message });

            }
        }

 
    }
}
