using System.ComponentModel.DataAnnotations;

namespace homework_67_izida_kubekova.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Название страны обязательно")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Название столицы обязательно")]
        public string Capital { get; set; }
        public int Population { get; set; }
    }
}