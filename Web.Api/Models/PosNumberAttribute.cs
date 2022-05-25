using System.ComponentModel.DataAnnotations;

namespace Web.Api.Models
{
    public class PosNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            if (int.TryParse(value.ToString(), out var getval))
            {
                if (getval >= 0)
                    return true;
            }
            return false;
        }
    }
}