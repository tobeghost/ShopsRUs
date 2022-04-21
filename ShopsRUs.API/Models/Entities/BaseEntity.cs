using System;
using System.ComponentModel.DataAnnotations;

namespace ShopsRUs.API.Models.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOnDate { get; set; }
    }
}
