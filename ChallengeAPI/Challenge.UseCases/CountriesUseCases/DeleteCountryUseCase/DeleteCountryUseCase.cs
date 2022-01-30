using Challenge.Core.Dtos;
using Challenge.Core.Models;
using Challenge.Core.Query;
using Challenge.Core.UseCases;
using Challenge.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.UseCases.CountriesUseCases.DeleteCountryUseCase
{
    public class DeleteCountryUseCase : UseCase<DeleteCountryRequest,DeleteCountryResponse>
    {

        private DbServiceImpl<country_record> CountryDbService;

        public DeleteCountryUseCase(IQuery<country_record> query)
        {
            CountryDbService = new DbServiceImpl<country_record>(query);
        }

        public async Task<DeleteCountryResponse> ExecuteAsync(DeleteCountryRequest request)
        {

            country_record record = await GetStudentRecordObject(request);
            return GetResponse(await CountryDbService.Delete(record));
        }


        private DeleteCountryResponse GetResponse(Response<country_record> DbResponse)
        {
            DeleteCountryResponse response = new DeleteCountryResponse();
            response.IsDeletedSuccessfully = DbResponse.IsSuccess;
            response.Message = DbResponse.IsSuccess ? "" : DbResponse.Message;
            return response;
        }

        private async Task<country_record> GetStudentRecordObject(DeleteCountryRequest request)
        {
            return await CountryDbService.Find(request.EntityId);
        }

    }
}
