using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace FSO.Web.Controllers
{
    public class FileController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upload()
        {
            var list = new List<IFormFile>();
            string fileType = Request.Form["UploadType"];
            if (string.IsNullOrWhiteSpace(fileType))
            {
                return BadRequest("错误的上传类型");
            }
            var files = Request.Form.Files;
            string rootPath = _hostingEnvironment.WebRootPath;
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    string fileExt = formFile.FileName.Substring(formFile.FileName.LastIndexOf(".")); //文件扩展名，不含“.”
                    long fileSize = formFile.Length; //获得文件大小，以字节为单位
                    string newFileName = Guid.NewGuid().ToString() + "." + fileExt; //随机生成新的文件名
                    var filePath = rootPath + "/upload/" + newFileName;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
                list.Add(formFile);
            }
            return Ok(list);
        }
    }
}