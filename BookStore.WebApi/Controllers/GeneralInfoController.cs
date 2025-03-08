using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralInfoController : ControllerBase
    {
        private readonly IGeneralInfoService _generalInfoService;
        public GeneralInfoController(IGeneralInfoService generalInfoService)
        {
            _generalInfoService = generalInfoService;
        }

        [HttpGet]
        public IActionResult InfoList()
        {
            var generalInfo = _generalInfoService.TGetAll();
            return Ok(generalInfo);
        }

        [HttpGet("GetInfo")]
        public IActionResult GetInfo(int id)
        {
            var generalInfo = _generalInfoService.TGetById(id);
            return Ok(generalInfo);
        }

        [HttpPost]
        public IActionResult CreateInfo(GeneralInfo generalInfo)
        {
            _generalInfoService.TAdd(generalInfo);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateInfo(GeneralInfo generalInfo)
        {
            _generalInfoService.TUpdate(generalInfo);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteInfo(int id)
        {
            _generalInfoService.TDelete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetLastInfo")]
        public IActionResult GetLastInfo()
        {
            var generalInfo = _generalInfoService.TGetLastOne();
            return Ok(generalInfo);
        }
    }
}
