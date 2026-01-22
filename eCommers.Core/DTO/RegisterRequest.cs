using eCommers.Core.DTO.Enums;

namespace eCommers.Core.DTO
{
    // public class registerRequest
    // {
    //     public string? PersonName { get; set; }
    //     public GenderOptions Gender { get; set; }

    //     public string? Email { get; set; }
    //     public string? Password { get; set; }
    // }
    public record RegisterRequest(string? PersonName,GenderOptions Gender,string? Email, string? Password);
}