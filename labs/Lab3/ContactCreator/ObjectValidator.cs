//ISTE 1430
//Joshua Bradshaw
//11-9-22
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactCreator
{
    public static class ObjectValidator
    {
        public static bool IsValid ( IValidatableObject instance, out string errorMessage )
        {
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(instance, new ValidationContext(instance), results, true))
            {
                errorMessage = results[0].ErrorMessage;
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}
