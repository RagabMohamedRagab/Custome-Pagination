using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pagination.Models
{
    public class Customer
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required,MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(20)]
        public string Contact { get; set; }
        [DataType(DataType.EmailAddress),Required]
        public string Email { get; set; }
        public DateTime DataBirth { get; set; }
    }
}
