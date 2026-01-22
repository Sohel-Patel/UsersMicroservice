namespace eCommers.Core.DTO
{
    // public class LoginRequest
    // {
    //     public string? Email { get; set; }
    //     public string? Password { get; set; }
    // }

    public record LoginRequest(string? Email,string? Password);
}