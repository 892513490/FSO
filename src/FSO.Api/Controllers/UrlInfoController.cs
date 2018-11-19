using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSO.Models;
using FSO.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FSO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlInfoController : ControllerBase
    {
        private IUrlInfoService _service;

        public UrlInfoController(IUrlInfoService service)
        {
            _service = service;
        }

        [HttpGet("GetUrlInfos")]
        public IList<UrlInfo> GetUserInfos()
        {
            return _service.GetList();
        }

        [HttpPost("Add")]
        public IActionResult Add(UrlInfo urlInfo)
        {
            _service.Add(urlInfo);
            return Ok();
        }

        [HttpPost("Add")]
        public IActionResult AddRang(IList<UrlInfo> urlInfos)
        {
            _service.Add(urlInfos);
            return Ok();
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(long id)
        {
            _service.Delete(id);
            return Ok();
        }

        [HttpGet("Get/{id}")]
        public UrlInfo Get(long id)
        {
            return _service.Get(id);
        }

        public IActionResult Update(UrlInfo urlInfo)
        {
            _service.Update(urlInfo);
            return Ok();
        }
    }
}