using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace t4.Model
{
    public class Offer4
    {
        [Key]
        [Required]
        public string Id4 { get; set; }
        public string Name4 { get; set; }
    }
}