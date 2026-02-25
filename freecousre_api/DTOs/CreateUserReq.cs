using System.ComponentModel.DataAnnotations;
public class CreateUserReq
{   [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "Password must contain uppercase, lowercase, number and special character (min 8 chars)"
    )]
    public string Password { get; set; }
}