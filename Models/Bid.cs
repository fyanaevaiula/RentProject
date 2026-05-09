using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcRentApp.Models
{
    public class Bid
    {
        // ID заявки
        public virtual int BidId { get; set; }
        // Имя заявителя
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DisplayName("Имя заявителя")]
        public virtual string Name { get; set; }
        // Эл.почта заявителя
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DisplayName("Электронная почта заявителя")]
        public virtual string Email { get; set; }
        // Телефон заявителя
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DisplayName("Телефон заявителя")]
        public virtual string Phone { get; set; }
        // Адрес бизнес центра
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [DisplayName("Адрес бизнес центра")]
        public virtual string Adress { get; set; }
        // Офис
        [DisplayName("Офис")]
        public virtual string Number { get; set; }
        // Дата подачи заявки
        [DisplayName("Дата подачи заявки")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public virtual DateTime bidDate { get; set; }
    }
}
