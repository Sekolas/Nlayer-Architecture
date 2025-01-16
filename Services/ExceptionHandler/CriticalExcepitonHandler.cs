using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExceptionHandler
{
    public class CriticalExcepitonHandler : IExceptionHandler
    {
        
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is CrtiticalException)
            {
                Console.WriteLine("hata sms i gönderildi ");

            }
            return ValueTask.FromResult(false);
        }
    }
}
