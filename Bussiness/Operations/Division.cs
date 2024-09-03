using Models;
using Models.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Operations
{
    internal class Division : ITask
    {
        public Result<TDataOut> ExecuteTask<TDataOut, TDataInt>(TDataInt value)
        {
            Result<TDataOut> result = new Result<TDataOut>() { CodeStatus = 200 };

            try
            {
                OperationBasic operation = (OperationBasic)(object)value;
                if (operation is null)
                {
                    result.SetError(400, "Datos no validos");
                }
                else
                {
                    if (operation.ValueB == 0)
                    {
                        result.SetError(400, $"el valor({operation.ValueA}) No puede ser dividido entre 0");
                    }
                    else {
                        result.Data = (TDataOut)(object)new ResultResponse { Result = operation.ValueA / operation.ValueB };
                    }                   
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
