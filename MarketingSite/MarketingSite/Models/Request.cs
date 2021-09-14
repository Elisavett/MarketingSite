using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingSite.Models
{
    public class Request
    {
        [Required]
        public Guid Id { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Ваш email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Дата окончания разработки")]
        public DateTime EndOfDevelopment { get; set; }
        public Guid AppliccationId { get; set; }
        public Application Application { get; set; }
    }
}
