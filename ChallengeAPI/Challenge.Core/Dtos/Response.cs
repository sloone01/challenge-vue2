using Challenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Core.Dtos
{
    public class Response<T> where T: Entity
    {
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public T? Result { get; set; }
        public static Response<T> Failure(string message) {
            return new Response<T> { Message = message, IsSuccess = false };
        }
        public static Response<T> Success(T Entity = null)
        {
            return new Response<T> { Result = Entity, IsSuccess = true };
        }
    }
}
