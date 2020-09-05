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
    /// 视频专区
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VideoInfoController : ControllerBase
    {
        private IVideoInfoService _service;

        public VideoInfoController(IVideoInfoService service)
        {
            _service = service;
        }

        /// <summary>
        /// 视频列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IList<VideoInfo> List()
        {
            return _service.GetList();
        }

        /// <summary>
        /// 添加视频
        /// </summary>
        /// <param name="videoInfo"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public IActionResult Add(VideoInfo videoInfo)
        {
            _service.Add(videoInfo);
            return Ok();
        }

        /// <summary>
        /// 批量添加视频
        /// </summary>
        /// <param name="videoInfos"></param>
        /// <returns></returns>
        [HttpPost("AddRange")]
        public IActionResult AddRange(IList<VideoInfo> videoInfos)
        {
            _service.AddRange(videoInfos);
            return Ok();
        }

        /// <summary>
        /// 删除视频
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
        /// 获取视频详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Get/{id}")]
        public VideoInfo Get(long id)
        {
            return _service.Get(id);
        }

        /// <summary>
        /// 更新视频
        /// </summary>
        /// <param name="videoInfo"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public IActionResult Update(VideoInfo videoInfo)
        {
            _service.Update(videoInfo);
            return Ok();
        }

        /// <summary>
        /// 审批视频
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Approval(long id,int status)
        {
            var videoInfo = _service.Get(id);
            videoInfo.Status = status;
            _service.Update(videoInfo);
            return Ok();
        }
    }
}