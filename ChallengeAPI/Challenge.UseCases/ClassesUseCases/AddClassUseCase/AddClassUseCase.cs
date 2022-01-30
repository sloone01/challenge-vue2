using System.Threading.Tasks;
using Challenge.Core.Dtos;
using Challenge.Core.Models;
using Challenge.Core.Query;
using Challenge.Core.UseCases;
using Challenge.Core.Validations;
using Challenge.Repos;

namespace Challenge.UseCases.ClassesUseCases.AddCountryUseCase
{
    public class AddClassUseCase : UseCase<AddClassRequest, AddClassResponse>
    {
        private DbServiceImpl<class_record> ClassDbService;
        ExistanceValidation<class_record> _existanceValidator;

        public AddClassUseCase(IQuery<class_record> query, ExistanceValidation<class_record> existanceValidator)
        {
            ClassDbService = new DbServiceImpl<class_record>(query);
            _existanceValidator = existanceValidator;
        }

        public async Task<AddClassResponse> ExecuteAsync(AddClassRequest request)
        {
            class_record record = GetCountryRecordObject(request);
            var validation = await _existanceValidator.Validate(record, ClassDbService);
            return validation.IsValid ? GetResponse(await ClassDbService.AddItem(record)) :
                GetValidationErrorResponse(validation);
        }

        private AddClassResponse GetValidationErrorResponse(ValidationResult validation)
        {
            AddClassResponse response = new AddClassResponse();
            response.IsEntityInserted = false;
            response.InsertedEntity = null;
            response.Message = validation.ErrorMessage;
            return response;
        }

        private AddClassResponse GetResponse(Response<class_record> DbResponse)
        {
            AddClassResponse response = new AddClassResponse();
            response.IsEntityInserted = DbResponse.IsSuccess;
            response.InsertedEntity = DbResponse.Result;
            response.Message = DbResponse.IsSuccess ? "Inserting Done" : DbResponse.Message;
            return response;
        }

        private class_record GetCountryRecordObject(AddClassRequest request)
        {
            class_record class_record = new class_record();
            class_record.class_name = request.Name;
            return class_record;
        }
    }
}
