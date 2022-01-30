using System;

namespace Challenge.UseCases.StudentsUseCases.UpdateStudentUseCase
{
    public class UpdateStudentRequest
    {
        public string Name;
        public DateTime? DateOfBirth;
        public int CountryId;
        public int ClassId;

        public int EntityId { get; set; }
    }
}