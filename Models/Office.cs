using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcRentApp.Models
{
    public class Office
    {
        // ID офиса
        public virtual int OfficeId { get; set; }
        // Адрес бизнес-центра
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DisplayName("Адрес бизнес-центра")]
        public virtual string BuisnessCenterAdress { get; set; }
        // Этаж бизнес-центра
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DisplayName("Этаж бизнес-центра")]
        public virtual int BuisnessCenterFloor { get; set; }
        // Номер офиса
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DisplayName("Номер офиса")]
        public virtual string OfficeNumber { get; set; }
        // Площадь офиса
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DisplayName("Площадь офиса, кв.м")]
        public virtual double OfficeSquare { get; set; }
        // Арендная ставка
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DisplayName("Арендная ставка, руб./кв.м")]
        public virtual double RentalRate { get; set; }
        // Статус занято/свободно
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DisplayName("Статус офиса")]
        public virtual string OfficeState { get; set; }
        // Планировка офиса, путь к картинке
        [DisplayName("Планировка офиса")]
        public virtual string OfficeLayout { get; set; }
    }
}
