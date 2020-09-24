using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DB_BookPhone.Models
{
    public class Abonent
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Изображение")]
        [Required(ErrorMessage ="картинка не выбрана")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Введите имя")]
        // [RegularExpression(@"\w+", ErrorMessage = "Проверьте правильность ввода")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите фамилию")]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "Введите номер телефона")]
        [Display(Name = "Номер телефона")]
        [StringLength(12, ErrorMessage = "Макс. длина 12 символов")]
        public string Number { get; set; }
    }
}