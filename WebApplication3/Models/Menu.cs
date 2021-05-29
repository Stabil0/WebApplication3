using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebApplication3.Models
{
    public partial class Menu
    {
        public Menu()
        {
            Ordes = new HashSet<Orde>();
        }
        [Display(Name = "Код блюда")]
        public long DishCode { get; set; }
        [Display(Name = "Наименование блюда")]
        public string DishName { get; set; }
        [Display(Name = "Объём 1")]
        public long Volume1 { get; set; }
        [Display(Name = "Объём 2")]
        public long Volume2 { get; set; }
        [Display(Name = "Объём 3")]
        public long Volume3 { get; set; }
        [Display(Name = "Стоимость")]
        public long Cost { get; set; }
        [Display(Name = "Время приготовления")]
        public DateTime Time { get; set; }
        [Display(Name = "Код ингредиента")]
        public long IngredientCode { get; set; }
        [Display(Name = "Код ингредиента")]
        public virtual Warehouse IngredientCodeNavigation { get; set; }
        public virtual ICollection<Orde> Ordes { get; set; }
    }
}
