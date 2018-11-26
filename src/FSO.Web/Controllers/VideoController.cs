using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FSO.Models;
using FSO.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FSO.Web.Controllers
{
    public class VideoController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly IVideoInfoService _service;

        public VideoController(IHostingEnvironment hostingEnvironment,IVideoInfoService service)
        {
            _hostingEnvironment = hostingEnvironment;
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetList());
        }

        public IActionResult Get(long id)
        {
            var videoInfo = _service.Get(id);
            if (videoInfo.IsLink)
            {
                return Redirect(videoInfo.Url);
            }
            return View(videoInfo);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(VideoInfo videoInfo)
        {
            var files = Request.Form.Files;
            if (files.Count > 0)
            {
                var rootPath = _hostingEnvironment.ContentRootPath.Replace("\\","/") + "/wwwroot";
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        string fileExt = formFile.FileName.Substring(formFile.FileName.LastIndexOf(".")); //文件扩展名，不含“.”
                        long fileSize = formFile.Length; //获得文件大小，以字节为单位
                        string newFileName = Guid.NewGuid().ToString() + "." + fileExt; //随机生成新的文件名
                        var filePath = rootPath;
                        if (formFile.Name.Equals("fileImg"))
                        {
                            videoInfo.ImgUrl = "/upload/images/" + newFileName;
                            filePath += videoInfo.ImgUrl;
                        }
                        else
                        {
                            videoInfo.Url = "/upload/video/" + newFileName;
                            filePath += videoInfo.Url;
                            videoInfo.IsLink = false;
                        }
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
            }
            
            _service.Add(videoInfo);
            return RedirectToAction("Index");
        }
    }
}