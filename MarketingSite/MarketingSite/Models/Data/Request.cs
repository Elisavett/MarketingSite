using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingSite.Models.Data
{
    public class Request
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Ваш email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Дата окончания разработки")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = false)]
        public DateTime EndOfDevelopment { get; set; }
        [Display(Name = "Приложение")]
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
