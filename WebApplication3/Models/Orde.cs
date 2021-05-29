using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication3.Models
{
    public partial class Orde
    {
        [Display(Name = "Дата")]
        public DateTime Data { get; set; }
        [Display(Name = "Время")]
        public DateTime Time { get; set; }
        [Display(Name = "Имя покупателя")]
        public string CustomerName { get; set; }
        [Display(Name = "Телефон")]
        public long Phone { get; set; }
        [Display(Name = "Стоимость")]
        public long Cost { get; set; }
        [Display(Name = "Отметка о выполнении")]
        public long Chec { get; set; }
        [Display(Name = "Код сотрудника")]
        public long EmployeeCode { get; set; }
        [Display(Name = "Код блюда")]
        public long DishCode { get; set; }
        [Display(Name = "Код блюда")]
        public virtual Menu DishCodeNavigation { get; set; }
        [Display(Name = "Код сотрудника")]
        public virtual Emploeey EmployeeCodeNavigation { get; set; }
    }
}
