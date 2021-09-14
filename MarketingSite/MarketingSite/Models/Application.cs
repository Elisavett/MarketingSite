using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingSite.Models
{
    public class Application
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
