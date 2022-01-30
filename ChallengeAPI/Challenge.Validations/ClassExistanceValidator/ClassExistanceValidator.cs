using Challenge.Core.Dtos;
using Challenge.Core.Models;
using Challenge.Core.Services;
using Challenge.Core.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Validations.ClassExistanceValidator
{
    public class ClassExistanceValidator :ExistanceValidation<class_record>
    {
        public override async Task<ValidationResult> Validate(class_record value, IDbService<class_record> DbService)
    {
        var result =await DbService.Find(x => x.class_name == value.class_name);
        return result == null ? ValidationResult.Valid() : ValidationResult.NotValid(ErrorMessage);
    }
}
}
