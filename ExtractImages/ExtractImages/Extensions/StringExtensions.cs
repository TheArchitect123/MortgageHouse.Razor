using System.Text;

namespace ExtractImages.Extensions
{
    public static class StringExtensions
    {
        public static string FormatJson(this string json)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                StringBuilder jsonFormatter = new StringBuilder();
                jsonFormatter.Append(json);
                jsonFormatter.Replace("\\", string.Empty);
                return jsonFormatter.ToString().Trim('"');
            }
            else
                return json;
        }
    }
}
