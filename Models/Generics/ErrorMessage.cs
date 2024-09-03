using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Generics
{

    
    public class ErrorMessage
    {
        
        private StringBuilder _message = new StringBuilder();
        

        public string Message { get { return _message.ToString(); } set { _message.AppendLine(value); } }
        
    }
}
