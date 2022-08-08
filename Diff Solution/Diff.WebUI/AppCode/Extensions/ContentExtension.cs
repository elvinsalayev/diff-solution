using System.Text.RegularExpressions;

namespace Diff.WebUI.AppCode.Extensions
{
    public static partial class Extension
    {
        public static string HtmlToPlainText(this string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return html;

            html = Regex.Replace(html, @"(<[^>]*>|\r\n|\r|\n)", "");
            html = Regex.Replace(html, @"\s+", " ");
            return html;
        }

        public static string ToEllipse(this string text, int length = 50)
        {
            if (string.IsNullOrWhiteSpace(text) || length >= text.Length)
            {
                return text;
            }

            return $"{text.Substring(0, length)}...";
        }
    }
}
