using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendingEmailsWith.NetCore.Dtos;
using SendingEmailsWith.NetCore.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SendingEmailsWith.NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {
        private readonly IMailingService _mailService;

        public MailingController(IMailingService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequestDto dto)
        {
             await _mailService.SendEmailAsync(dto.ToEmail, dto.Subject, dto.Body, dto.Attachments);
            return Ok();
        }

        [HttpPost("welcome")]
        public async Task<IActionResult> SendWelcomeEmail([FromBody] WelcomeRequestDto dto)
        {
            var filePath = $"{Directory.GetCurrentDirectory()}\\Templates\\EmailTemplate.html";
            var str = new StreamReader(filePath);

            var mailText = str.ReadToEnd();
            str.Close();

            mailText = mailText.Replace("[username]", dto.UserName).Replace("[email]", dto.Email);

            await _mailService.SendEmailAsync(dto.Email, "Welcome to our channel", mailText);
            return Ok();
        }


    }
}
