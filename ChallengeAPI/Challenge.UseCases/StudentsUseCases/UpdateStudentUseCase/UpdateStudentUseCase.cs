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

namespace Challenge.UseCases.StudentsUseCases.UpdateStudentUseCase
{
    public class UpdateStudentUseCase : UseCase<UpdateStudentRequest, UpdateStudentResponse>
    {

        private DbServiceImpl<student_record> studentDbService;

        public UpdateStudentUseCase(IQuery<student_record> query)
        {
            studentDbService = new DbServiceImpl<student_record>(query);
        }

        public async Task<UpdateStudentResponse> ExecuteAsync(UpdateStudentRequest request)
        {
            
            student_record record =await GetStudentRecordObject(request);
            return GetResponse(await studentDbService.UpdateEntity(record));
        }

        private UpdateStudentResponse GetResponse(Response<student_record> DbResponse)
        {
            UpdateStudentResponse response = new ();
            response.IsUpdatedSuccessfully = DbResponse.IsSuccess;
            response.Message = DbResponse.Message;
            return response;
        }

        private async Task<student_record> GetStudentRecordObject(UpdateStudentRequest request)
        {
            var record = await studentDbService.Find(request.EntityId);
            record.name = request.Name;
            record.UpdateDate = DateTime.Now;
            record.date_of_birth = request.DateOfBirth;
            record.class_id = request.ClassId;
            record.country_id = request.CountryId;
            return record;
        }

    }
}
