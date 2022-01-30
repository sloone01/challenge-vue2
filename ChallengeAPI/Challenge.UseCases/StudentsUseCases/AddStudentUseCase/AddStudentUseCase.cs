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

namespace Challenge.UseCases.CountryUseCases.AddStudentUseCase
{
    public class AddStudentUseCase : UseCase<AddStudentRequest, AddStudentResponse>
    {
        private DbServiceImpl<student_record> studentDbService;

        public AddStudentUseCase(IQuery<student_record> query) {
            studentDbService = new DbServiceImpl<student_record>(query);
        }

        public async Task<AddStudentResponse> ExecuteAsync(AddStudentRequest request)
        {
            student_record record = GetStudentRecordObject(request);
            return GetResponse(await studentDbService.AddItem(record));
        }


        private AddStudentResponse GetResponse(Response<student_record> dbResponse)
        {
            AddStudentResponse response = new AddStudentResponse();
            response.IsStudentInserted = dbResponse.IsSuccess;
            response.InsertedEntity = dbResponse.Result;
            response.Message = dbResponse.IsSuccess ? "Inserting Done" : dbResponse.Message;
            return response; 
        }

        private student_record GetStudentRecordObject(AddStudentRequest request)
        {
            student_record record = new student_record();
            record.name = request.Name;
            record.date_of_birth = request.DateOfBirth;
            record.class_id = request.ClassId;
            record.country_id = request.CountryId;
            return record;
        }
    }
}
