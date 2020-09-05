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
    /// <summary>
    /// 网址专区
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UrlInfoController : ControllerBase
    {
        private IUrlInfoService _service;

        public UrlInfoController(IUrlInfoService service)
        {
            _service = service;
        }

        /// <summary>
        /// 收藏列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IList<UrlInfo> List()
        {
            return _service.GetList();
        }

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="urlInfo"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public IActionResult Add(UrlInfo urlInfo)
        {
            _service.Add(urlInfo);
            return Ok();
        }

        /// <summary>
        /// 批量收藏
        /// </summary>
        /// <param name="urlInfos"></param>
        /// <returns></returns>
        [HttpPost("AddRange")]
        public IActionResult AddRange(IList<UrlInfo> urlInfos)
        {
            _service.AddRange(urlInfos);
            return Ok();
        }

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Delete/{id}")]
        public IActionResult Delete(long id)
        {
            _service.Delete(id);
            return Ok();
        }

        /// <summary>
        /// 获取收藏详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        public UrlInfo Get(long id)
        {
            return _service.Get(id);
        }

        /// <summary>
        /// 更新收藏
        /// </summary>
        /// <param name="urlInfo"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public IActionResult Update(UrlInfo urlInfo)
        {
            _service.Update(urlInfo);
            return Ok();
        }
    }
}