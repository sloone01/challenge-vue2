namespace Challenge.UseCases.StudentsUseCases.UpdateStudentUseCase
{
    public class UpdateStudentResponse
    {
        public bool IsUpdatedSuccessfully { get; internal set; }
        public object? Message { get; set; }
    }
}