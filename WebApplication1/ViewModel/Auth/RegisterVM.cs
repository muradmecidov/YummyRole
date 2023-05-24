using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel.Auth
{
    public class RegisterVM
    {
        [Required,MaxLength(100)]
        public string Name { get; set; }
        [Required,MaxLength(255),DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required,MinLength(8),DataType(DataType.Password)] //include elemek.
        public string Password { get; set; }
        [Required,MinLength(8),DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }// yazdigimiz passwordu ikinci defe yoxlamaq uchundur
    }
}
