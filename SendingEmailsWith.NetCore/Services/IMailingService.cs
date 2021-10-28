using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendingEmailsWith.NetCore.Services
{
   public interface IMailingService
    {
        Task SendEmailAsync(string to, String subject , string body, IList<IFormFile> attatchment =null);
    }
}
