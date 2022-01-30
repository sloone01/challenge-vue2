using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge.Core.Models;
using Challenge.Core.Query;
using Challenge.Core.Shared;
using Challenge.Core.UseCases;
using Challenge.Repos;

namespace Challenge.UseCases.StudentsUseCases.ViewStudentsUseCase
{
    public class ViewStudentUseCase : UseCase<ViewStudentRequest,ViewStudentResponse>
    {
        
        private DbServiceImpl<student_record> StudentDbService;

        public ViewStudentUseCase(IQuery<student_record> query)
        {
            StudentDbService = new DbServiceImpl<student_record>(query);
        }
        public async Task<ViewStudentResponse> ExecuteAsync(ViewStudentRequest request)
        {
            return GetResponse(await StudentDbService.GetItems(request.Expression));
        }

        private ViewStudentResponse GetResponse(List<student_record> records)
        {
            ViewStudentResponse viewStudentResponse = new ();
            viewStudentResponse.records = records;
            return viewStudentResponse;
        }


    }
}