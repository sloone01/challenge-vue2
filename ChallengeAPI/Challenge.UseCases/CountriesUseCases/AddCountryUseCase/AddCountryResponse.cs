using Challenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.UseCases.CountriesUseCases.AddCountryUseCase
{
    public class AddCountryResponse
    {
        public bool IsEntityInserted;
        public country_record? InsertedEntity;
        public string? Message;
    }
}
