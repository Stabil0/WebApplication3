using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication3.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Menus = new HashSet<Menu>();
        }
        [Display(Name = "Код ингредиента")]
        public long IngredientCode { get; set; }
        [Display(Name = "Наименование ингредиента")]
        public string IngredientName { get; set; }
        [Display(Name = "Дата")]
        public long Data { get; set; }
        [Display(Name = "Объём")]
        public long Volume { get; set; }
        [Display(Name = "Срок годности")]
        public DateTime ShelfIfe { get; set; }
        [Display(Name = "Стоимость")]
        public long Cost { get; set; }
        [Display(Name = "Поставщик")]
        public string Provider { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
