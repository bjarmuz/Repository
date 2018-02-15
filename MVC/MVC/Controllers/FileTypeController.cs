using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class FileTypeController : Controller
    {
        // GET: FileType
        public ActionResult TestView()
        {
            FileType file = new FileType() { Name = "IDML"};
            
            return View(file);
        }
    }
}