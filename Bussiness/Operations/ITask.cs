using Models.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Operations
{
    public interface ITask
    {
        Result<TDataOut> ExecuteTask<TDataOut, TDataInt>(TDataInt value);
    }
}
