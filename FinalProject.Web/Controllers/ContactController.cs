﻿using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
