using Models;
using Models.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Operations
{
    internal class Factorial : ITask
    {
        public Result<TDataOut> ExecuteTask<TDataOut, TDataInt>(TDataInt value)
        {
            Result<TDataOut> result = new Result<TDataOut>() { CodeStatus = 200 };

            try
            {
                FactorialValue operation = (FactorialValue)(object)value;
                if (operation is null)
                {
                    result.SetError(400, "Datos no validos");
                }
                else
                {
                    var r = new ResultResponse() { Result=operation.Value };
                    operation.Value--;
                    while (operation.Value > 0) {
                        r.Result *= operation.Value;
                        operation.Value--;
                    }
                    result.Data = (TDataOut)(object)r;
                }
            }
            catch (Exception ex)
            {
                result.SetError(500, ex.Message);
            }
            return result;
        }
    }
}
