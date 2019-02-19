using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Wantsome.WebApp01.Models.Employee
{
    public class Employee
    {
        public string Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email address")]
        public string Email { get; set; }

        [DisplayName("Details")]
        public string Details { get; set; }


    }
}