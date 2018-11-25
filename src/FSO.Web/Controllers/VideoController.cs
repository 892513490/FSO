using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSO.Models;
using FSO.Service;
using Microsoft.AspNetCore.Mvc;

namespace FSO.Web.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoInfoService _service;

        public VideoController(IVideoInfoService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetList());
        }

        public IActionResult Get(long id)
        {
            return View(_service.Get(id));
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}