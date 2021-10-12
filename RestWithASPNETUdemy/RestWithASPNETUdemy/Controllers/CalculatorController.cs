using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
     
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber) //String porque na aula quer passar conceitos de validações.
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult GetDivisionResult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && (IsNumeric(secondNumber) && !secondNumber.Equals("0")))
                return Ok(ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber));
            return BadRequest("Invalid Input, check the numbers of division");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtractionResult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && (IsNumeric(secondNumber)))
                return Ok(ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber));
            return BadRequest("Invalid Input");
        }

        [HttpGet("sqrRoot/{firstNumber}")]
        public IActionResult GetSquareRoot(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber))
                //return Ok(Math.Sqrt(ConvertToDecimal(firstNumber)));
                return Ok(Math.Pow((double)ConvertToDecimal(firstNumber), 0.5)); // Square Root = number pow 1/2 or math.sqrt.
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiplicationResult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && (IsNumeric(secondNumber)))
                return Ok(ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber));
            return BadRequest("Invalid Input");
        }



        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult GetMeanResult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && (IsNumeric(secondNumber)))
                return Ok(ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber) / 2);
            return BadRequest("Invalid Input");
        }




        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue)) //se for possivel converter, retorna, senao 0.
                return decimalValue;
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number); //Check if is a number... 
            return isNumber;
        }
    }
}
