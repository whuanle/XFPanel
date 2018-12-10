using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XFPanel.Service.FileManager;
using System.IO;
using XFPanel.Model.Response;

namespace XFPanel.Controllers
{
    public class ExplorerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}