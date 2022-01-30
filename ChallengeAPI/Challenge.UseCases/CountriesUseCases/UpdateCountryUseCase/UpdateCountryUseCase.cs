using System.Threading.Tasks;
using Challenge.Core.Dtos;
using Challenge.Core.Models;
using Challenge.Core.Query;
using Challenge.Core.UseCases;
using Challenge.Repos;

namespace Challenge.UseCases.CountriesUseCases.UpdateCountryUseCase
{
    public class UpdateCountryUseCase : UseCase<UpdateCountryRequest,UpdateCountryResponse>
    {
        private DbServiceImpl<country_record> CountryDbService;

        public UpdateCountryUseCase(IQuery<country_record> query)
        {
            CountryDbService = new DbServiceImpl<country_record>(query);
        }

        public async Task<UpdateCountryResponse> ExecuteAsync(UpdateCountryRequest request)
        {
            
            country_record record =await GetStudentRecordObject(request);
            return GetResponse(await CountryDbService.UpdateEntity(record));
        }

        private UpdateCountryResponse GetResponse(Response<country_record> DbResponse)
        {
            UpdateCountryResponse response = new UpdateCountryResponse();
            response.IsUpdatedSuccessfully = DbResponse.IsSuccess;
            response.Message = DbResponse.Message;
            return response;
        }

        private async Task<country_record> GetStudentRecordObject(UpdateCountryRequest request)
        {
            var record = await CountryDbService.Find(request.EntityId);
            record.name = request.Name;
            record.UpdateDate = DateTime.Now;
            return record;
        }
        
    }
    
}