using Bussiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : BController
    {
        ServiceCalculator serviceCalculator;
        public CalculatorController() { 
            serviceCalculator = new ServiceCalculator();
        }

        [HttpPost]
        [Route("Addition")]
        [ProducesResponseType(typeof(ResultResponse), statusCode: 200)]
        public IActionResult Addition(OperationBasic operation) {
            return CreateResponse(serviceCalculator.ExecuteOperation<ResultResponse, OperationBasic>(operation, TypeOperation.Add));
        }
        [HttpPost]
        [Route("Substraction")]
        [ProducesResponseType(typeof(ResultResponse), statusCode: 200)]
        public IActionResult Substraction(OperationBasic operation)
        {
            return CreateResponse(serviceCalculator.ExecuteOperation<ResultResponse, OperationBasic>(operation, TypeOperation.Subs));
        }
        [HttpPost]
        [Route("Multiplication")]
        [ProducesResponseType(typeof(ResultResponse), statusCode: 200)]
        public IActionResult Multiplication(OperationBasic operation)
        {
            return CreateResponse(serviceCalculator.ExecuteOperation<ResultResponse, OperationBasic>(operation, TypeOperation.Mult));
        }
        [HttpPost]
        [Route("Division")]
        [ProducesResponseType(typeof(ResultResponse), statusCode: 200)]
        public IActionResult Division(OperationBasic operation)
        {
            return CreateResponse(serviceCalculator.ExecuteOperation<ResultResponse, OperationBasic>(operation, TypeOperation.Div));
        }
        [HttpPost]
        [Route("Factorial")]
        [ProducesResponseType(typeof(ResultResponse), statusCode: 200)]
        public IActionResult Factorial(FactorialValue operation)
        {
            return CreateResponse(serviceCalculator.ExecuteOperation<ResultResponse, FactorialValue>(operation, TypeOperation.Fact));
        }
    }
}
