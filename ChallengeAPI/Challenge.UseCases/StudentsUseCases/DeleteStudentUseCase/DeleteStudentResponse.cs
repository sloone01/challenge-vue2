namespace Challenge.UseCases.CountryUseCases.DeleteStudentUseCase
{
    public class DeleteStudentResponse
    {
        public bool IsDeletedSuccessfully { get; internal set; }
        public string? Message { get; internal set; }
    }
}