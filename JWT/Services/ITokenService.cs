namespace JWT.Services
{
    public interface ITokenService
    {
        string Generate(string userName);
    }
}
