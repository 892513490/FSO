using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            return View(_service.GetList(predicate: item => item.Status.Equals((int)EnumStatus.Y)));
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
                        string fileExt = formFile.FileName.Substring(formFile.FileName.LastIndexOf(".")).ToLower(); //文件扩展名，含“.”
                        long fileSize = formFile.Length; //获得文件大小，以字节为单位
                        string newFileName = Guid.NewGuid().ToString() + fileExt; //随机生成新的文件名
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

                        //苹果手机格式转换（mov -> mp4）
                        if (filePath.EndsWith(".mov"))
                        {
                            string tmpPath = filePath.Replace(".mov", ".mp4");
                            await this.MovToMp4(filePath, tmpPath);
                            videoInfo.Url = videoInfo.Url.Replace(".mov", ".mp4");
                        }
                    }
                }
            }
            
            _service.Add(videoInfo);
            return RedirectToAction("Index");
        }

        private async Task MovToMp4(string movPath, string mp4Path)
        {
            //创建一个ProcessStartInfo对象 使用系统shell 指定命令和参数 设置标准输出
            var psi = new ProcessStartInfo("ffmpeg", $"-i {movPath} -vcodec copy -acodec copy {mp4Path}") { RedirectStandardOutput = true };
            //启动
            var proc = Process.Start(psi);
            if (proc == null)
            {
                throw new Exception("ffmpeg can not found");
            }
            else
            {
                //开始读取
                using (var sr = proc.StandardOutput)
                {
                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }

                    if (!proc.HasExited)
                    {
                        proc.Kill();
                    }
                }
            }
        }
    }
}