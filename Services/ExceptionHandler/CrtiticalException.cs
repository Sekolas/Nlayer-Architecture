using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExceptionHandler
{
    public class CrtiticalException(string message):Exception(message)
    {
        

    }
}
