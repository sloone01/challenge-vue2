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

namespace Challenge.UseCases.CountryUseCases.DeleteStudentUseCase
{
    public class DeleteStudentUseCase : UseCase<DeleteStudentRequest,DeleteStudentResponse>
    {


        private DbServiceImpl<student_record> studentDbService;

        public DeleteStudentUseCase(IQuery<student_record> query)
        {
            studentDbService = new DbServiceImpl<student_record>(query);
        }

        public async Task<DeleteStudentResponse> ExecuteAsync(DeleteStudentRequest request)
        {

            student_record record = await GetStudentRecordObject(request);
            return GetResponse(await studentDbService.Delete(record));
        }


        private DeleteStudentResponse GetResponse(Response<student_record> DbResponse)
        {
            DeleteStudentResponse response = new DeleteStudentResponse();
            response.IsDeletedSuccessfully = DbResponse.IsSuccess;
            response.Message = DbResponse.IsSuccess ? "" : DbResponse.Message;
            return response;
        }

        private async Task<student_record> GetStudentRecordObject(DeleteStudentRequest request)
        {
            return await studentDbService.Find(request.EntityId);
        }
    }
}
