using EmailServices;
using MimeKit;
using System.ComponentModel.DataAnnotations;

namespace WolfEmails.Models
{
    public class MessageViewModel
    {
        public Message Message { get; set; }

        public string ControlQuestionLabel { get; set; }
        public string ControlQuestionPlaceholder { get; set; }

        [Required(ErrorMessage = "Odpovězte prosím na otázku.")]
        public string ControlQuestion { get; set; }
        public int QuestionIndex { get; set; }


        public MessageViewModel() 
        {
            ControlQuestionLabel = "";
            Message = new Message();
        }

    }
}
