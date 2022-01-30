using System;
using System.Linq.Expressions;
using Challenge.Core.Models;

namespace Challenge.UseCases.ClassesUseCases.ViewClassListUseCase
{
    public class ViewClassListRequest
    {
        public Expression<Func<class_record, bool>> Expression { get; set; } = c => true;
    }
}