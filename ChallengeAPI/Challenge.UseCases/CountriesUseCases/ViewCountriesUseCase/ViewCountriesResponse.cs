using System.Collections.Generic;
using Challenge.Core.Models;

namespace Challenge.UseCases.CountriesUseCases.ViewCountriesUseCase
{
    public class ViewCountriesResponse
    {
        public List<country_record> records { get; set; }
    }
}