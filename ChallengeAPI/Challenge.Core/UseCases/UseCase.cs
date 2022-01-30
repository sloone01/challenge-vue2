using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Core.UseCases
{
    public interface UseCase<Request,Response>
    {
        Task<Response> ExecuteAsync(Request request); 
    }
}
