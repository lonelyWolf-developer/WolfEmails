using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServices
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }

        [Required(ErrorMessage = "Vyplňte jméno.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Napište text zprávy.")]
        public string Content { get; set; }

        public Message()
        {
        }

    }
}
