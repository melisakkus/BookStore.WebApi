using BookStore.BusinessLayer.Abstract;
using BookStore.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEmailsController : ControllerBase
    {
        private readonly IUserEmailService _userEmailService;

        public UserEmailsController(IUserEmailService userEmailService)
        {
            _userEmailService = userEmailService;
        }

        [HttpGet]
        public IActionResult GetEmails()
        {
            var emails = _userEmailService.TGetAll();
            return Ok(emails);
        }

        [HttpPost]
        public IActionResult CreateEmail(UserEmail email)
        {
            _userEmailService.TAdd(email);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete]
        public IActionResult DeleteEmail(int id)
        {
            _userEmailService.TDelete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateEmail(UserEmail email)
        {
            _userEmailService.TUpdate(email);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("GetEmailById")]
        public IActionResult GetEmailById(int id)
        {
            var email = _userEmailService.TGetById(id);
            return Ok(email);
        }
    }
}
