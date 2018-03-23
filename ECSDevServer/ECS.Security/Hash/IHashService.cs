namespace ECS.Security.Hash
{
    public interface IHashService
    {
        string CreateSaltKey();
        string HashPasswordWithSalt(string salt, string password, bool isPrependSalt);
    }
}
