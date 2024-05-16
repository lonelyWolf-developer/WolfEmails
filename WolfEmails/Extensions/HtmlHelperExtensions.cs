using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using WolfEmails.Classess;

namespace WolfEmails.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent RenderMessageBox(this IHtmlHelper helper)
        {
            var messageList = helper.ViewContext.TempData.DeserializeToObject<List<FlashMessage>>("Messages");

            var html = new HtmlContentBuilder();

            foreach (var message in messageList)
            {
                var container = new TagBuilder("div");
                container.AddCssClass("messageBox");
                container.GenerateId("messageBoxTimer", "");               

                var iconsDiv = new TagBuilder("div");
                iconsDiv.AddCssClass("iconsDiv");
                iconsDiv.GenerateId("icons", "");

                var image = new TagBuilder("img");
                image.AddCssClass("crossIcon");
                image.GenerateId("icon", "");
                image.MergeAttribute("src", "../img/crossMenu.png");
                image.MergeAttribute("alt", "Hamburger");

                var background = new TagBuilder("div");
                background.AddCssClass($"background {message.MessageType.ToString().ToLower()}");

                var paragraph = new TagBuilder("p");
                paragraph.InnerHtml.SetContent(message.Message);
                
                iconsDiv.InnerHtml.AppendHtml(image);                
                container.InnerHtml.AppendHtml(iconsDiv);
                container.InnerHtml.AppendHtml(background);
                container.InnerHtml.AppendHtml(paragraph);              

                html.AppendHtml(container);
       
            }

            return html;
        }
    }
}
