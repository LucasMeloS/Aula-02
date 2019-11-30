using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebService.Models;
namespace WebService.Controllers
{
    public class ApiCepController : Controller
    {
        private readonly Context _context;
        public ApiCepController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.ApiCep.ToList());
        }

        public IActionResult ApiCep()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ApiCep(string cep)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString("https://viacep.com.br/ws/" + cep + "/json/");
            ApiCep cidade = JsonConvert.DeserializeObject<ApiCep>(json);

            _context.Add(cidade);
            _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}

//Lucas de Melo da Silva