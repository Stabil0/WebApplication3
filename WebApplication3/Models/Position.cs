using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication3.Models
{
    public partial class Position
    {
        public Position()
        {
            Emploeeys = new HashSet<Emploeey>();
        }
        [Display(Name = "Код должности")]
        public int PositionCode { get; set; }
        [Display(Name = "Наименование должности")]
        public string JobTitle { get; set; }
        [Display(Name = "Оклад")]
        public long Salary { get; set; }
        [Display(Name = "Обязанности")]
        public string Responsibilities { get; set; }
        [Display(Name = "Требования")]
        public string Requirements { get; set; }

        public virtual ICollection<Emploeey> Emploeeys { get; set; }
    }
}
