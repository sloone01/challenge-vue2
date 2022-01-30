using Challenge.Core.Dtos;
using Challenge.Core.Models;
using Challenge.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Core.Validations
{
    public abstract class ExistanceValidation<T> : IValidator<T> where T : Entity
    {
        protected readonly string ErrorMessage = "Item With this Name Is Already Exist";
        public abstract Task<ValidationResult> Validate(T value, IDbService<T> DbService);
     
    }
}
