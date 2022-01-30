using Challenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.UseCases.CountryUseCases.AddStudentUseCase
{
    public class AddStudentResponse
    {
        public bool IsStudentInserted;
        public student_record? InsertedEntity;
        public string? Message;
    }
}
