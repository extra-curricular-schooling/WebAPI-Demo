using System.Diagnostics;
using System.Web.Http.ExceptionHandling;

namespace ECS.WebAPI.ExceptionHandlers
{
    public class TraceExceptionLogger : ExceptionLogger
    {
        /// <summary>
        /// Logs exceptions that are not handled.
        /// </summary>
        /// <param name="context"></param>
        public override void Log(ExceptionLoggerContext context)
        {
            Trace.TraceError(context.ExceptionContext.Exception.ToString());
        }
    }
}