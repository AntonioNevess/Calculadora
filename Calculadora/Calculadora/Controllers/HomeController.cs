using Calculadora.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Calculadora.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(){
            //inicializar os dados para a calculadora funcionar
            ViewBag.visor = "0";

            return View();
        }

        [HttpPost]
        public IActionResult Index(string botao, string visor) {
            //vamos decidir o que fazer com o valor do botao
            switch (botao) {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                    //o utilizador pressionou um algarismo

                    if(visor == "0") {
                        visor = botao;
                    }
                    else {
                        visor += botao;
                    }

                    break;

                case ",":
                    //foi pressioanada a ','    
                    if (!visor.Contains(',')) 
                        visor += botao;
                    break;

                case "+/-":
                    //inverter o valor do visor
                    if (visor.StartsWith('-'))
                        visor = visor.Substring(1);
                    else
                        visor = '-' + visor;
                    break;

                case "+":
                case "-":
                case "x":
                case ":":
                    //foi pressionado um operador
                    break;
            }

            //preparar os dados a serem enviados para a View
            ViewBag.visor = visor;

            return View();
        }
        public IActionResult Privacy(){
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}