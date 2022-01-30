using System.Threading.Tasks;
using Challenge.Core.Dtos;
using Challenge.Core.Models;
using Challenge.Core.Query;
using Challenge.Core.UseCases;
using Challenge.Repos;
using Challenge.UseCases.CountriesUseCases.UpdateCountryUseCase;

namespace Challenge.UseCases.ClassesUseCases.UpdateClassUseCase
{
    public class UpdateClassUseCase : UseCase<UpdateClassRequest,UpdateClassResponse>
    {
        private DbServiceImpl<class_record> ClassDbService;

        public UpdateClassUseCase(IQuery<class_record> query)
        {
            ClassDbService = new DbServiceImpl<class_record>(query);
        }

        public async Task<UpdateClassResponse> ExecuteAsync(UpdateClassRequest request)
        {
            
            class_record record =await GetClassRecordObject(request);
            return GetResponse(await ClassDbService.UpdateEntity(record));
        }

        private UpdateClassResponse GetResponse(Response<class_record> DbResponse)
        {
            UpdateClassResponse response = new UpdateClassResponse();
            response.IsUpdatedSuccessfully = DbResponse.IsSuccess;
            response.Message = DbResponse.Message;
            return response;
        }

        private async Task<class_record> GetClassRecordObject(UpdateClassRequest request)
        {
            var record = await ClassDbService.Find(request.EntityId);
            record.class_name = request.Name;
            record.UpdateDate = DateTime.Now;
            return record;
        }
        
    }
}