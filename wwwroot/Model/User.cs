namespace WebApplication5.wwwroot.Model
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }

}
