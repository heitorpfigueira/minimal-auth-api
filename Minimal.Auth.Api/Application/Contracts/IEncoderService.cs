namespace Minimal.Auth.Api.Application.Contracts
{
    public interface IEncoderService
    {
        public string Encode(Guid salt, string rawText);
        public bool Verify(Guid salt, string encodedText, string rawText);
    }
}
