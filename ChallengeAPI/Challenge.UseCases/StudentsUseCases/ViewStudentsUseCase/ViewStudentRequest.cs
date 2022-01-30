using System;
using System.Linq.Expressions;
using Challenge.Core.Models;

namespace Challenge.UseCases.StudentsUseCases.ViewStudentsUseCase
{
    public class ViewStudentRequest
    {
        public Expression<Func<student_record, bool>> Expression { get; set; } = c => true;
    }
}