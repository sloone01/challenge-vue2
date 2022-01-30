using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Core.Models;
using Challenge.Core.Query;
using Challenge.Core.UseCases;
using Challenge.Repos;

namespace Challenge.UseCases.ClassesUseCases.ViewClassListUseCase
{
    public class ViewClassListUseCase : UseCase<ViewClassListRequest,ViewClassListResponse>
    {
        private DbServiceImpl<class_record> CountryDbService;

        public ViewClassListUseCase(IQuery<class_record> query)
        {
            CountryDbService = new DbServiceImpl<class_record>(query);
        }
        public async Task<ViewClassListResponse> ExecuteAsync(ViewClassListRequest request)
        {
            return GetResponse(await CountryDbService.GetItems(request.Expression));
        }

        private ViewClassListResponse GetResponse(List<class_record> classRecords)
        {
            ViewClassListResponse viewCountriesResponse = new ViewClassListResponse();
            viewCountriesResponse.records = classRecords;
            return viewCountriesResponse;
        }
        
    }
}