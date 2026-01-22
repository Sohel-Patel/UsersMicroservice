using eCommers.Core.DTO.Enums;

namespace eCommers.Core.DTO
{
    // public class AuthenticationResponse
    // {
    //     public Guid UserId { get; set; }
    //     public string? PersonName { get; set; }
    //     public string? Email { get; set; }
    //     public string? Gender { get; set; }
    //     public bool Success { get; set; }
    //     public string? Token { get; set; }
    // }

    public record AuthenticationResponse(Guid UserId,string? PersonName,string? Email,string? Gender,bool Success,string? Token)
    {
        public AuthenticationResponse():this(default,default,default,default,default,default)
        {
            
        }
    }
}