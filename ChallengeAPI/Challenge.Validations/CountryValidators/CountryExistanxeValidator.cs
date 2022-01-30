using Challenge.Core.Dtos;
using Challenge.Core.Models;
using Challenge.Core.Services;
using Challenge.Core.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Validations.CountryValidators
{
    public class CountryExistanxeValidator : ExistanceValidation<country_record>
    {
        public override async Task<ValidationResult> Validate(country_record value, IDbService<country_record> DbService)
        {
           var result =await DbService.Find(x => x.name == value.name) ;
            return result == null ? ValidationResult.Valid() : ValidationResult.NotValid(ErrorMessage);
        }
    }
}
