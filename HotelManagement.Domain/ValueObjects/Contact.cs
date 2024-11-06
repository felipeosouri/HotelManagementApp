namespace HotelManagement.Domain.ValueObjects
{
    public class Contact
    {
        public string FullName { get; }
        public string ContactPhone { get; }

        public Contact(string fullName, string contactPhone)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name cannot be empty", nameof(fullName));

            if (string.IsNullOrWhiteSpace(contactPhone))
                throw new ArgumentException("Contact phone cannot be empty", nameof(contactPhone));

            FullName = fullName;
            ContactPhone = contactPhone;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Contact other) return false;
            return FullName == other.FullName && ContactPhone == other.ContactPhone;
        }

        public override int GetHashCode() => HashCode.Combine(FullName, ContactPhone);
    }

}
