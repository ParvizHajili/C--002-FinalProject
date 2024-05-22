using Core.Validation;
using System.Text;

namespace Core.Extenstions
{
    public static class CollectionExtensionMethods
    {
        public static string ValidationErrorMessagesWithNewLine(this List<ValidationErrorModel> errors)
        {
            StringBuilder sb = new();
            foreach (var error in errors)
            {
                sb.Append(error.ErrorMessage);
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
