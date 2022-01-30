using System;
using System.ComponentModel.DataAnnotations;
namespace Challenge.Core.Shared
{
    public class Student
    {
        
        public string? className { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public int ClassId { get; set; }
        [Required]
        public int CountryId { get; set; }
        public int Id { get; set; }
        public string? CountryName { get; set; }
    }
}