
using API_Basic.Constant;
using API_Basic.Entities;
using API_Basic.IServices;
using API_Basic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Basic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocSinhController : ControllerBase
    {
        private readonly IHocSinhServices _hocSinhServices;
        public HocSinhController()
        {
            _hocSinhServices = new HocSinhServices();
        }   

        [HttpGet]
        public IActionResult GetDsHocSinh()
        {
            var dsHocSinh = _hocSinhServices.GetDsHocSinh();
            return Ok(dsHocSinh);
        }
        [HttpPost("themHocSinhVaoLop")]
        public IActionResult ThemHocSinh([FromBody] HocSinh hocSinh)
        {
            var ret = _hocSinhServices.ThemHocSinhVaoLop(hocSinh, hocSinh.Lop.LopId);
            if(ret == ErrorMessage.ThanhCong)
            {
                return Ok("Them thanh cong!");
            }
            else
            {
                return BadRequest("Them that bai!");
            }
        }
        [HttpPut("capNhatThongTinHocSinh")]
        public IActionResult CapNhatThongTinHocSinh([FromBody] HocSinh hocSinh)
        {
            var ret = _hocSinhServices.SuaThongTinHocSinh(hocSinh);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Cap Nhat thanh cong!");
            }
            else
            {
                return BadRequest("Cap Nhat that bai!");
            }
        }
        [HttpDelete("xoaHocSinh")]
        public IActionResult CapNhatThongTinHocSinh([FromQuery] int hocSinhId)
        {
            var ret = _hocSinhServices.XoaHocSinh(hocSinhId);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Xoa thanh cong!");
            }
            else
            {
                return BadRequest("Xoa that bai!");
            }
        }
    }
}
