using Microsoft.VisualBasic;
using Minimal.Auth.Api.Domain.Base;
using Minimal.Auth.Api.Domain.Customer.Entities;
using Minimal.Auth.Api.Domain.Customer.Enums;

namespace Minimal.Auth.Api.Domain.Customer.VO
{
    public class Profile : ValueObject
    {

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Description;
        }

        public static Profile Administrator()
        {
            Profiles adminProfile = Profiles.Administrator;

            return Create(Profiles.Administrator);
        }


        public static Profile Create(Profiles profile)
        {
            return new()
            {
                Id = profile,
                Name = Enum.GetName(profile)!,
                Description = profile.ToString()
            };
        }

        public Profiles Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
