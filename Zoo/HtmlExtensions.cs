using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Zoo
{
    public static class HtmlExtensions
    {
        public static HtmlString DisabledIf(this IHtmlHelper _, bool condition)
        {
            return new HtmlString(condition ? "disabled=\"disabled\"" : "");
        }
    }
}
