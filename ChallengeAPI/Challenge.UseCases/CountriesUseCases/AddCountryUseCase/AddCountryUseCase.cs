using Challenge.Core.Dtos;
using Challenge.Core.Models;
using Challenge.Core.Query;
using Challenge.Core.UseCases;
using Challenge.Core.Validations;
using Challenge.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.UseCases.CountriesUseCases.AddCountryUseCase
{
    public class AddCountryUseCase : UseCase<AddCountryRequest, AddCountryResponse>
    {

        private DbServiceImpl<country_record> CountryDbService;
        private ExistanceValidation<country_record> _existanceValidator;


        public AddCountryUseCase(IQuery<country_record> query, ExistanceValidation<country_record> existanceValidator)
        {
            CountryDbService = new DbServiceImpl<country_record>(query);
            _existanceValidator = existanceValidator; 
        }

        public async Task<AddCountryResponse> ExecuteAsync(AddCountryRequest request)
        {
            country_record record = GetCountryRecordObject(request);
            var validation =await _existanceValidator.Validate(record,CountryDbService);
            return validation.IsValid ?
                 GetResponse(await CountryDbService.AddItem(record)) :
                 GetValidationErrorResponse(validation);

        }

        private AddCountryResponse GetValidationErrorResponse(ValidationResult validation)
        {
            AddCountryResponse response = new AddCountryResponse();
            response.IsEntityInserted = false;
            response.InsertedEntity = null;
            response.Message = validation.ErrorMessage;
            return response;
        }

        private AddCountryResponse GetResponse(Response<country_record> DbResponse)
        {
            AddCountryResponse response = new AddCountryResponse();
            response.IsEntityInserted = DbResponse.IsSuccess;
            response.InsertedEntity = DbResponse.Result;
            response.Message = DbResponse.IsSuccess ? "Inserting Done" : DbResponse.Message;
            return response;
        }

        private country_record GetCountryRecordObject(AddCountryRequest request)
        {
            country_record country_record = new country_record();
            country_record.name = request.Name;
            return country_record;
        }
    }
}
