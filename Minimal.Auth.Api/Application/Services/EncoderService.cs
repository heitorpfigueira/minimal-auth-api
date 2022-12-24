using Minimal.Auth.Api.Application.Contracts;

namespace Minimal.Auth.Api.Application.Services
{
    public class EncoderService : IEncoderService
    {
        public EncoderService() { }

        public string Encode(Guid salt, string rawText)
        {
            return rawText;
        }

        public bool Verify(Guid salt, string encodedText, string rawText)
        {
            return true;
        }
    }
}
