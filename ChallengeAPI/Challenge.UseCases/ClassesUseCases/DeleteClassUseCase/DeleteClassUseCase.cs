using System.Threading.Tasks;
using Challenge.Core.Dtos;
using Challenge.Core.Models;
using Challenge.Core.Query;
using Challenge.Core.UseCases;
using Challenge.Repos;

namespace Challenge.UseCases.ClassesUseCases.DeleteClassUseCase
{
    public class DeleteClassUseCase : UseCase<DeleteClassRequest,DeleteClassResponse>
    {
        

        private DbServiceImpl<class_record> ClassDbService;

        public DeleteClassUseCase(IQuery<class_record> query)
        {
            ClassDbService = new DbServiceImpl<class_record>(query);
        }

        public async Task<DeleteClassResponse> ExecuteAsync(DeleteClassRequest request)
        {

            class_record record = await GetClassRecordObject(request);
            return GetResponse(await ClassDbService.Delete(record));
        }


        private DeleteClassResponse GetResponse(Response<class_record> DbResponse)
        {
            DeleteClassResponse response = new DeleteClassResponse();
            response.IsDeletedSuccessfully = DbResponse.IsSuccess;
            response.Message = DbResponse.IsSuccess ? "" : DbResponse.Message;
            return response;
        }

        private async Task<class_record> GetClassRecordObject(DeleteClassRequest request)
        {
            return await ClassDbService.Find(request.EntityId);
        }

    }
    
}