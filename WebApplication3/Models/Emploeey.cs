using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication3.Models
{
    public partial class Emploeey
    {
        public Emploeey()
        {
            Ordes = new HashSet<Orde>();
        }
        [Display(Name = "Код сотрудника")]
        public long EmployeeCode { get; set; }
        [Display(Name = "ФИО")]
        public string FullName { get; set; }
        [Display(Name = "Возраст")]
        public long Old { get; set; }
        [Display(Name = "Пол")]
        public string Gender { get; set; }
        [Display(Name = "Адресс")]
        public string Adress { get; set; }
        [Display(Name = "Телефон")]
        public long Phone { get; set; }
        [Display(Name = "Паспортные данные")]
        public long PassportData { get; set; }
        [Display(Name = "Код должности")]
        public int PositionCode { get; set; }
        [Display(Name = "Код должности")]
        public virtual Position PositionCodeNavigation { get; set; }
        public virtual ICollection<Orde> Ordes { get; set; }
    }
}
