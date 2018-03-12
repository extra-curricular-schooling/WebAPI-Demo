using System.Diagnostics;
using System.Web.Http.ExceptionHandling;

namespace ECS.WebAPI.ExceptionHandlers
{
    public class TraceExceptionLogger : ExceptionLogger
    {
        // Logging if we ever need it.
        public override void Log(ExceptionLoggerContext context)
        {
            Trace.TraceError(context.ExceptionContext.Exception.ToString());
        }
    }
}