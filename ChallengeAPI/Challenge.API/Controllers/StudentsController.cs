using System;
using System.Linq;
using System.Threading.Tasks;
using Challenge.Core.Models;
using Challenge.Core.Shared;
using Challenge.Core.UseCases;
using Challenge.UseCases.CountryUseCases.AddStudentUseCase;
using Challenge.UseCases.CountryUseCases.DeleteStudentUseCase;
using Challenge.UseCases.StudentsUseCases.UpdateStudentUseCase;
using Challenge.UseCases.StudentsUseCases.ViewStudentsUseCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Challenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private UseCase<AddStudentRequest, AddStudentResponse> _addStudentUseCase;
        private UseCase<DeleteStudentRequest, DeleteStudentResponse> _deleteStudentUseCase;
        private UseCase<UpdateStudentRequest, UpdateStudentResponse> _updateStudentUseCase;
        private UseCase<ViewStudentRequest, ViewStudentResponse> _viewStudentUseCase;

        public StudentsController(ILogger<WeatherForecastController> logger,
            UseCase<AddStudentRequest, AddStudentResponse> addStudentUseCase,
            UseCase<DeleteStudentRequest, DeleteStudentResponse> deleteStudentUseCase,
            UseCase<UpdateStudentRequest, UpdateStudentResponse> updateStudentUseCase,
            UseCase<ViewStudentRequest, ViewStudentResponse> viewStudentUseCase)
        {
            _viewStudentUseCase = viewStudentUseCase;
            _updateStudentUseCase = updateStudentUseCase;
            _deleteStudentUseCase = deleteStudentUseCase;
            _addStudentUseCase = addStudentUseCase;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> ViewCountries()
        {
            try
            {
                ViewStudentResponse response = await _viewStudentUseCase.ExecuteAsync(new ViewStudentRequest());
                return Ok(response.records.Select(MapToStudent).ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddCountry([FromBody] Student student)
        {
            try
            {
                AddStudentResponse response = await _addStudentUseCase.ExecuteAsync(GetAddRequest(student));
                return response.IsStudentInserted ? Ok(response.InsertedEntity) : BadRequest(response.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountry([FromBody] Student student)
        {
            try
            {
                UpdateStudentResponse response = await _updateStudentUseCase.ExecuteAsync(GetUpdateRequest(student));
                return response.IsUpdatedSuccessfully ? Ok(response.Message) : BadRequest(response.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        private UpdateStudentRequest GetUpdateRequest(Student student)
        {
            UpdateStudentRequest request = new();
            request.Name = student.Name;
            request.EntityId = student.Id;
            request.DateOfBirth = student.DateOfBirth;
            request.ClassId = student.ClassId;
            request.CountryId = student.CountryId;
            return request;
        }
        private Student MapToStudent(student_record studentRecord)
        {
            Student student = new();
            student.Id = studentRecord.Id;
            student.Name = studentRecord.name;
            student.ClassId = studentRecord.class_id;
            student.DateOfBirth = studentRecord.date_of_birth;
            student.className = studentRecord.class_record.class_name;
            student.CountryId = studentRecord.country_id;
            student.CountryName = studentRecord.country_record.name;
            return student;
        }

        [HttpDelete]
        public  async Task<IActionResult>  DeleteCountry(int Id)
        {
            try
            {
                DeleteStudentResponse response = await _deleteStudentUseCase.ExecuteAsync(GetDeleteRequest(Id));
                return response.IsDeletedSuccessfully ? Ok(response.Message) : BadRequest(response.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        private DeleteStudentRequest GetDeleteRequest(int studentid)
            => new() {EntityId = studentid};


        private AddStudentRequest GetAddRequest(Student student)
        {
            AddStudentRequest request = new();
            request.Name = student.Name;
            request.DateOfBirth = student.DateOfBirth;
            request.ClassId = student.ClassId;
            request.CountryId = student.CountryId;
            return request;
        }
    }
}