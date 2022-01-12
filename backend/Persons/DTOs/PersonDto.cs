namespace Persons.DTOs
{
    public class PersonDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string Born { get; set; } = null!;
        public string? Tel { get; set; }
        public long AdressId { get; set; }
        public string Adress { get; set; } = null!;
    }
}
