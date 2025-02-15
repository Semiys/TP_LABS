using System.ComponentModel.DataAnnotations;

namespace Lab4Web.Models
{
    public class Calculate
    {
        [Required(ErrorMessage="Пожалуйста, введите первое число")]
        [Display(Name ="Первое число")]
        public long? operand1 { get; set; }
        [Range(1,10000,ErrorMessage="Пожалуйста, введите второе число в диапозоне от 1 до 10000")]
        [Display(Name ="Второе число")]
        public float operand2 { get; set; }
        [Display(Name ="Операция")]
        public string operation { get; set; }

        [Display(Name ="Результат")]
        public float result { get; set; }

    }
}
