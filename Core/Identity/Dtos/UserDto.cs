using System.Diagnostics.CodeAnalysis;

namespace BEN.DTOs
{
    public abstract class BaseUserDto
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? DisplayName { get; set; }

    }
    public class UserDto : BaseUserDto
    {
        public string? Token { get; set; }
        public string? Gender { get; set; }
        public string? ProfilePicturUrl { get; set; }
        public string? RefreshToken { get; set; }   
    }
    public class UserProfileInfo
    {
        
    }
    public class EmailConfirmationDto : BaseUserDto
    {
        public string EmailConfirmationToken { get; set; }
    }

    public class UserUpdateDTo
    {
        
        public string? DisplayName { get; set; }
        public string? Gender { get; set; }
    }

    public class AppSettings
    {
        public JwtSettings JwtSettings { get; set; }
        public string BasePath { get; set; }

        public string? ApiUrl { get; set; }
    }

    public class JwtSettings
    {
        public string JwtSecretKey { get; set; }
        public string Issuer { get; set; }
        
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    public class TokenSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
    }

    public class MailSettings
    {
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }

    public class ApplicationSettings
    {
        public string? ApiUrl { get; set; }
    }

}
