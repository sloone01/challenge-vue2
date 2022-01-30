using Challenge.Core.Dtos;
using Challenge.Core.Models;
using Challenge.Core.Services;

namespace Challenge.Core.Validations
{
    public interface IValidator<T> where T : Entity
    {
        Task<ValidationResult> Validate(T value,IDbService<T> DbService);
    }
}
