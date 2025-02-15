using Microsoft.AspNetCore.Mvc;
using Lab4Web.Models;
namespace Lab4Web.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View(new Calculate());
        }
        public IActionResult History()
        {
            return View();
        }
        [HttpGet]
        public ViewResult CalculateForm()
        {
            return View(new Calculate());
        }

        [HttpPost]
        public ViewResult CalculateForm(Calculate calculationModel, string action)
        {
            if (action == "Очистить")
            {
                ModelState.Clear();
                return View("Index", new Calculate());

            }
            if (!ModelState.IsValid)
            {
                return View("Index", calculationModel);
            }
            if (calculationModel.operand1.HasValue)
            {
                switch (calculationModel.operation)
                {
                    case "+":
                        calculationModel.result = calculationModel.operand1.Value + calculationModel.operand2;
                        break;
                    case "-":
                        calculationModel.result = calculationModel.operand1.Value - calculationModel.operand2;
                        break;
                    case "*":
                        calculationModel.result = calculationModel.operand1.Value * calculationModel.operand2;
                        break;
                    case "/":
                        calculationModel.result = calculationModel.operand1.Value / calculationModel.operand2;
                        break;
                    
                    
                }
				string operationString = $"{calculationModel.operand1}{calculationModel.operation}{calculationModel.operand2}={calculationModel.result}";
				var cookieOptions = new CookieOptions
				{
					Expires = DateTime.Now.AddMinutes(30)
				};
				Response.Cookies.Append("LastOperation", operationString, cookieOptions);
			}
            ViewBag.CheckValue = 100;// допустим равен ли результат 100
            return View("Index",calculationModel);

        }
    }
}
