using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cars.Models
{
    public class Car
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}
