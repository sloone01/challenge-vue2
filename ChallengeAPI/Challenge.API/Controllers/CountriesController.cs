using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Challenge.Core.Models;
using Challenge.Core.Shared;
using Challenge.Core.UseCases;
using Challenge.Core.Validations;
using Challenge.UseCases.CountriesUseCases.AddCountryUseCase;
using Challenge.UseCases.CountriesUseCases.DeleteCountryUseCase;
using Challenge.UseCases.CountriesUseCases.UpdateCountryUseCase;
using Challenge.UseCases.CountriesUseCases.ViewCountriesUseCase;
using Challenge.UseCases.CountryUseCases.AddStudentUseCase;
using Challenge.UseCases.CountryUseCases.DeleteStudentUseCase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Challenge.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private UseCase<AddCountryRequest, AddCountryResponse> _addCountryUseCase;
        private UseCase<DeleteCountryRequest, DeleteCountryResponse> _deleteCountryUseCase;
        private UseCase<ViewCountriesRequest, ViewCountriesResponse> _viewCountryUseCase;
        private UseCase<UpdateCountryRequest, UpdateCountryResponse> _updateCountryUseCase;
        
        public CountriesController(ILogger<WeatherForecastController> logger,
            UseCase<AddCountryRequest,AddCountryResponse> addCountryUseCase,
            UseCase<DeleteCountryRequest,DeleteCountryResponse> deleteCountryUseCase,
            UseCase<ViewCountriesRequest,ViewCountriesResponse> viewCountryUseCase,
            UseCase<UpdateCountryRequest ,UpdateCountryResponse> updateCountryUseCase
          )
        {
            _updateCountryUseCase = updateCountryUseCase;
            _viewCountryUseCase = viewCountryUseCase;
            _deleteCountryUseCase = deleteCountryUseCase;
            _addCountryUseCase = addCountryUseCase;
            _logger = logger;
        }
        
        [HttpGet]
        public  async Task<IActionResult>  ViewCountries()
        {
            try
            {
                ViewCountriesResponse response = await _viewCountryUseCase.ExecuteAsync(new ViewCountriesRequest());
                return Ok(response.records.Select(MapToViewModel).ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        private Country MapToViewModel(country_record arg)
        {
            return new() {Id = arg.Id, Name = arg.name};
        }

        [HttpPost]
        public  async Task<IActionResult>  AddCountry([FromBody] Country country)
        {
            try
            {
                AddCountryResponse response = await _addCountryUseCase.ExecuteAsync(GetAddRequest(country));
                return response.IsEntityInserted ? Ok(response.InsertedEntity) : BadRequest(response.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        
        [HttpPut]
        public  async Task<IActionResult>  UpdateCountry([FromBody] Country country)
        {
            try
            {
                UpdateCountryResponse response = await _updateCountryUseCase.ExecuteAsync(GetUpdateRequest(country));
                return response.IsUpdatedSuccessfully ? Ok(response.Message) : BadRequest(response.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        private UpdateCountryRequest GetUpdateRequest(Country country)
        {
            UpdateCountryRequest request = new ();
            request.Name = country.Name;
            request.EntityId = country.Id;
            return request;
        }

        [HttpDelete]
        public  async Task<IActionResult>  DeleteCountry(int Id)
        {
            try
            {
                DeleteCountryResponse response = await _deleteCountryUseCase.ExecuteAsync(GetDeleteRequest(Id));
                return response.IsDeletedSuccessfully ? Ok(response.Message) : BadRequest(response.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        private DeleteCountryRequest GetDeleteRequest(int country)
            => new() {EntityId = country};


        private AddCountryRequest GetAddRequest(Country country)
        {
            AddCountryRequest request = new();
            request.Name = country.Name;
            return request;
        }
    }
}