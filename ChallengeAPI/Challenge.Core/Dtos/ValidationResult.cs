using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Core.Dtos
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public static ValidationResult Valid()
        => new ValidationResult() { IsValid = true };
        public static ValidationResult NotValid(string error)
         => new ValidationResult() { IsValid = false, ErrorMessage = error };


    }
}
