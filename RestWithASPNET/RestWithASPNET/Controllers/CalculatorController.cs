using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Controllers
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

        [HttpGet("calc/{firstNumber}/{op}/{secundNumber}")]
        public IActionResult Get(string firstNumber,string op, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                switch (op)
                {
                    case "sum": var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secundNumber); 
                        return Ok(sum.ToString());

                    case "sub": var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secundNumber);
                        return Ok(sub.ToString());

                    case "mult": var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secundNumber);
                        return Ok(mult);

                    case "div": var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secundNumber);
                        return Ok(div);
                }
                return Ok();
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }


    }
}
