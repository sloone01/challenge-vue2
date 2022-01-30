using System;
using System.Linq;
using System.Threading.Tasks;
using Challenge.Core.Models;
using Challenge.Core.Shared;
using Challenge.Core.UseCases;
using Challenge.UseCases.ClassesUseCases.AddCountryUseCase;
using Challenge.UseCases.ClassesUseCases.DeleteClassUseCase;
using Challenge.UseCases.ClassesUseCases.UpdateClassUseCase;
using Challenge.UseCases.ClassesUseCases.ViewClassListUseCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Challenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private UseCase<AddClassRequest, AddClassResponse> _addClassUseCase;
        private UseCase<DeleteClassRequest, DeleteClassResponse> _deleteClassUseCase;
        private UseCase<ViewClassListRequest, ViewClassListResponse> _viewClassUseCase;
        private UseCase<UpdateClassRequest, UpdateClassResponse> _updateClassUseCase;

        public ClassController(ILogger<WeatherForecastController> logger,
            UseCase<AddClassRequest,AddClassResponse> addClassUseCase,
            UseCase<DeleteClassRequest,DeleteClassResponse> deleteClassUseCase,
            UseCase<ViewClassListRequest,ViewClassListResponse> viewClassUseCase,
            UseCase<UpdateClassRequest ,UpdateClassResponse> updateClassUseCase)
        {
            _updateClassUseCase = updateClassUseCase;
            _viewClassUseCase = viewClassUseCase;
            _deleteClassUseCase = deleteClassUseCase;
            _addClassUseCase = addClassUseCase;
            _logger = logger;
        }
        
        [HttpGet]
        public  async Task<IActionResult>  ViewCountries()
        {
            try
            {
                ViewClassListResponse response = await _viewClassUseCase.ExecuteAsync(new ViewClassListRequest());
                return Ok(response.records.Select(MapToViewModel).ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        private ClassRecord MapToViewModel(class_record arg)
        {
            return new ()
            {
                Id = arg.Id, Name = arg.class_name
            };
        }

        [HttpPost]
        public  async Task<IActionResult>  AddCountry([FromBody] ClassRecord record)
        {
            try
            {
                AddClassResponse response = await _addClassUseCase.ExecuteAsync(GetAddRequest(record));
                return response.IsEntityInserted ? Ok(response.InsertedEntity) : BadRequest(response.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        
        [HttpPut]
        public  async Task<IActionResult>  UpdateCountry([FromBody] ClassRecord record)
        {
            try
            {
                UpdateClassResponse response = await _updateClassUseCase.ExecuteAsync(GetUpdateRequest(record));
                return response.IsUpdatedSuccessfully ? Ok(response.Message) : BadRequest(response.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        private UpdateClassRequest GetUpdateRequest(ClassRecord country)
        {
            UpdateClassRequest request = new ();
            request.Name = country.Name;
            request.EntityId = country.Id;
            return request;
        }

        [HttpDelete]
        public  async Task<IActionResult>  DeleteCountry(int Id)
        {
            try
            {
                DeleteClassResponse response = await _deleteClassUseCase.ExecuteAsync(GetDeleteRequest(Id));
                return response.IsDeletedSuccessfully ? Ok(response.Message) : BadRequest(response.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        private DeleteClassRequest GetDeleteRequest(int record)
            => new() {EntityId = record};


        private AddClassRequest GetAddRequest(ClassRecord classRecord)
        {
            AddClassRequest request = new();
            request.Name = classRecord.Name;
            return request;
        }
    }
}