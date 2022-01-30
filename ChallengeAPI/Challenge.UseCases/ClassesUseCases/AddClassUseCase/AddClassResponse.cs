using Challenge.Core.Models;

namespace Challenge.UseCases.ClassesUseCases.AddCountryUseCase
{
    public class AddClassResponse
    {
        public bool IsEntityInserted;
        public class_record? InsertedEntity;
        public string? Message;
    }
}