using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Generics
{
    
    public class Result<T>
    {
    
        public int CodeStatus { get; set; }
    
        public T Data { get; set; }
    
        public ErrorMessage MessageError { get; set; } = new ErrorMessage();
    
        public bool ExistError { get { return !string.IsNullOrEmpty(MessageError.Message.ToString()); } }
    
        public void SetError(int code, string message)
        {
            MessageError.Message = message;
            CodeStatus = code;
        }
    
        public void SetError<J>(Result<J> result)
        {
            if (result.ExistError)
            {
                CodeStatus = result.CodeStatus;
                MessageError.Message = result.MessageError.Message;
    
            }
        }        
       
        public void SetData(Result<T> result)
        {
            if (result.ExistError)
            {
                MessageError.Message = result.MessageError.Message;                
            }
            else
            {
                this.Data = result.Data;
            }
        }
    }
}
