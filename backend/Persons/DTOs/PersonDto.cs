using System.ComponentModel.DataAnnotations;

namespace Persons.DTOs
{
    public class PersonDto
    {
        [RegularExpression(@"^[A-Z][a-z]{2,}$")]
        public string? Firstname { get; set; }
        [RegularExpression(@"^[A-Z][a-z]{2,}$")]
        public string? Lastname { get; set; }
        [RegularExpression(@"^\d{2}.\d{2}.\d{4}$")]
        public string Born { get; set; } = null!;
        [RegularExpression(@"^\+\d{2}\s\(\d{1,3}\)\s\d{4,6}$")]
        public string? Tel { get; set; }
        [RegularExpression(@"^([A-Z])-(\d{4})\s(\w+),\s(\w+)\s(\d+)$")]
        public string Adress { get; set; } = null!;
    }
}
