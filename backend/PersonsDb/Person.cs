using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonsDb
{
    public partial class Person
    {
        public long Id { get; set; }
        [RegularExpression(@"^[A-Z][a-z]{2,}$")]
        public string? Firstname { get; set; }
        [RegularExpression(@"^[A-Z][a-z]{2,}$")]
        public string? Lastname { get; set; }
        [RegularExpression(@"^\d{2}.\d{2}.\d{4}$")]
        public string Born { get; set; } = null!;
        [RegularExpression(@"^\+\d{2}\s\(\d{1,3}\)\s\d{4,6}$")]
        public string? Tel { get; set; }
        public long AdressId { get; set; }

        public virtual Adress Adress { get; set; } = null!;
    }
}
