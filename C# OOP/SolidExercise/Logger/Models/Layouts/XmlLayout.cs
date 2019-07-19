using System.Text;

using Logger.Models.Contracts;

namespace Logger.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("<log>");
            result.AppendLine("\t<date>{0}</date>");
            result.AppendLine("\t<level>{1}</level>");
            result.AppendLine("\t<message>{2}</message>");
            result.AppendLine("</log>");

            return result.ToString().TrimEnd();
        }
    }
}
