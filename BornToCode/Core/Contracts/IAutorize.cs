namespace BornToCode.Core.Contracts
{
    public interface IAutorize
    {
        bool TokenIsValid(string token);
    }
}
