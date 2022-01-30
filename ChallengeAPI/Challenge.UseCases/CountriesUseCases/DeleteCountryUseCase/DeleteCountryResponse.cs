namespace Challenge.UseCases.CountriesUseCases.DeleteCountryUseCase
{
    public class DeleteCountryResponse
    {
        public bool IsDeletedSuccessfully { get; set; }

        public string? Message { get; set; }
    }
}