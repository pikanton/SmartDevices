using System.ComponentModel.DataAnnotations;

namespace SmartDevices.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
