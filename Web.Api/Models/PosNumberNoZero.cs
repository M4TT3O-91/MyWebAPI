using System.ComponentModel.DataAnnotations;

namespace Web.Api.Models
{
    public class PosNumberNoZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            int getal;
            if (int.TryParse(value.ToString(), out getal))
            {
                if (getal > 0)
                    return true;
            }
            return false;
        }
    }
}

