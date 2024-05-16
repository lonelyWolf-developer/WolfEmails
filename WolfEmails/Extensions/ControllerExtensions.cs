using Microsoft.AspNetCore.Mvc;
using WolfEmails.Classess;

namespace WolfEmails.Extensions
{
    public static class ControllerExtensions
    {
        public static void AddFlashMessage(this Controller controller, FlashMessage message)
        {
            var list = controller.TempData.DeserializeToObject<List<FlashMessage>>("Messages");

            list.Add(message);

            controller.TempData.SerializeObject(list, "Messages");
        }

        public static void AddFlashMessage(this Controller controller, string message, FlashMessageType messageType)
        {
            controller.AddFlashMessage(new FlashMessage(message, messageType));
        }
    }
}
