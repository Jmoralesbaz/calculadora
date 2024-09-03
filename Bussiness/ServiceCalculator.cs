using Bussiness.Operations;
using Models.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class ServiceCalculator
    {
        public ServiceCalculator() { }
        public Result<DOut> ExecuteOperation<DOut, DInt>(DInt value, TypeOperation type) {
            ITask task = (type) switch
            {
                (TypeOperation.Add) => new Addition(),
                (TypeOperation.Subs) => new Substraction(),
                (TypeOperation.Mult) => new Multiplication(),
                (TypeOperation.Div) => new Division(),
                (TypeOperation.Fact) => new Factorial(),
                _=>throw new NotImplementedException()
            };
            return task.ExecuteTask<DOut,DInt>(value);
        }
    }
}
