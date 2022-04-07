using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.Model
{
    /// <summary>
    /// Describes a sports apparel site user.
    /// </summary>
    public class User : BaseEntity
    {
        [JsonRequired]
        public string Email { get; set; }

        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime LastActiveTime { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static IEqualityComparer<User> ProductComparer { get; } = new ProductEqualityComparer();

        private sealed class ProductEqualityComparer : IEqualityComparer<User>
        {
            public bool Equals(User x, User y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Email == y.Email &&
                    x.Role == y.Role &&
                    x.FirstName == y.FirstName && x.LastName == y.LastName &&
                    x.StreetAddress == y.StreetAddress && x.StreetAddress2 == y.StreetAddress2 && x.City == y.City && x.State == y.State && x.ZipCode == y.ZipCode &&
                    x.PhoneNumber == y.PhoneNumber &&
                    x.LastActiveTime == y.LastActiveTime;
            }

            public int GetHashCode(User obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.Email);
                hashCode.Add(obj.Role);
                hashCode.Add(obj.FirstName);
                hashCode.Add(obj.LastName);
                hashCode.Add(obj.StreetAddress);
                hashCode.Add(obj.StreetAddress2);
                hashCode.Add(obj.City);
                hashCode.Add(obj.State);
                hashCode.Add(obj.ZipCode);
                hashCode.Add(obj.PhoneNumber);
                hashCode.Add(obj.LastActiveTime);
                return hashCode.ToHashCode();
            }
        }
    }
}
