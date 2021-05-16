using Management.Entities;

namespace Web.Implementation.Contracts
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(UserEntity user, string token)
        {
            UserId = user.UserId;
            Username = user.UserName;
            Token = token;
        }
    }
}
