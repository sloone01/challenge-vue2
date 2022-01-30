using Challenge.Core.Models;
using Challenge.Core.Query;
using Challenge.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.UseCases.CountriesUseCases.ViewCountriesUseCase
{
    public class ViewCountryUseCase : Core.UseCases.UseCase<ViewCountriesRequest, ViewCountriesResponse>
    {
        private DbServiceImpl<country_record> CountryDbService;

        public ViewCountryUseCase(IQuery<country_record> query)
        {
            CountryDbService = new DbServiceImpl<country_record>(query);
        }
        public async Task<ViewCountriesResponse> ExecuteAsync(ViewCountriesRequest request)
        {
            return GetResponse(await CountryDbService.GetItems(request.Expression));
        }

        private ViewCountriesResponse GetResponse(List<country_record> country_records)
        {
            ViewCountriesResponse viewCountriesResponse = new ViewCountriesResponse();
            viewCountriesResponse.records = country_records;
            return viewCountriesResponse;
        }
    }
}
