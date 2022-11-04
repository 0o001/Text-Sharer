namespace ATProject.TextSharer.API.Validator
{
    public interface IRecaptchaValidator
    {
        bool IsRecaptchaValid(string token);
    }
}
