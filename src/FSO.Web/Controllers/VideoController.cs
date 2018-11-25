using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSO.Models;
using Microsoft.AspNetCore.Mvc;

namespace FSO.Web.Controllers
{
    public class VideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get(long id)
        {
            return View(new VideoInfo() {
                Id = id,
                Author = "杨老师",
                Remark = "杨老师。。。。。。。。。。。。。",
                ImgUrl = "",
                Url = id % 2 == 1 ? "/upload/video/AngryBall.mp4" : "/upload/video/StreetBattle.mp4"
            });
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}