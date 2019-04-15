using System.ComponentModel.DataAnnotations;

namespace FC_EMDB.Entities
{
   public class LoginModel
    {
        [Required(ErrorMessage = "Не указан номер абонемента")]
        public string AbonementNumber { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Нет токена")]
        public string FcmToken { get; set; }
    }
}
