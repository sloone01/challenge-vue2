using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.UseCases.CountryUseCases.AddStudentUseCase
{
    public class AddStudentRequest
    {
        public DateTime? DateOfBirth { get; set; }
        public int ClassId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
}
