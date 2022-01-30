using System;
using Challenge.Core.Models;
using System.Linq.Expressions;

namespace Challenge.UseCases.CountriesUseCases.ViewCountriesUseCase
{
    public class ViewCountriesRequest
    {
        public Expression<Func<country_record, bool>> Expression { get; set; } = c=> true;
    }
}