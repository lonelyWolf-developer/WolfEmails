using EmailServices;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Diagnostics;
using WolfEmails.Classess;
using WolfEmails.Extensions;
using WolfEmails.Models;

namespace WolfEmails.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;            
        }

        public IActionResult Index(MessageViewModel model)
        {
            model = new MessageViewModel();

            ControllQuestions questions = new ControllQuestions();
            model.QuestionIndex = questions.GenerateIndex();
            model.ControlQuestionPlaceholder = questions.Questions[model.QuestionIndex];
            
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult sendEmail(MessageViewModel model)
        {
            ControllQuestions questions = new ControllQuestions();
            
            if(!questions.CompareInputs(model.QuestionIndex, model.ControlQuestion.ToLower()))
            {
                model.ControlQuestionLabel = "Zkus to znovu";                
                return View("Index", model);
            }            
            
            model.Message.To = new List<MailboxAddress>() { new MailboxAddress("spravce@vlksamotar.cz") };
            model.Message.Subject = "Pøišla ti zpráva od: " + model.Message.Subject;
            
            _emailSender.SendEmail(model.Message);

            this.AddFlashMessage(new FlashMessage("Zpráva byla úspìšnì odeslána.", FlashMessageType.Success));


            return RedirectToAction("Index");
        }
    }
}
