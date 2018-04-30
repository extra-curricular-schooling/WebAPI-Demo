namespace ECS.DTO.Sso
{
    /// <summary>
    /// Registration Data Transfer Object for traversing multiple application layers.
    /// </summary>
    public class SsoRegistrationRequestDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public string HashedPassword { get; set; }

        public string RoleType { get; set; }
    }
}