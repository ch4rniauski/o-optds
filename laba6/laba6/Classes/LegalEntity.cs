namespace laba6.Classes
{
    public class LegalEntity : Client, IComparable<LegalEntity>
    {
        public string OrganizationName { get; set; }
        public string LegalAddress { get; set; }
        public string RegistrationNumber { get; set; }
        public string ContactPerson { get; set; }

        public LegalEntity() : base()
        {
            OrganizationName = string.Empty;
            LegalAddress = string.Empty;
            RegistrationNumber = string.Empty;
            ContactPerson = string.Empty;

            Console.WriteLine("Конструктор класса Юридическое лицо");
        }

        public LegalEntity(string organizationName, string legalAddress, string registrationNumber, string contactPerson, string name, string address = "", string contract_number = "") : base(name, address: address, contract_number: contract_number)
        {
            OrganizationName = organizationName;
            LegalAddress = legalAddress;
            RegistrationNumber = registrationNumber;
            ContactPerson = contactPerson;

            Console.WriteLine("Конструктор класса Юридическое лицо");
        }

        public LegalEntity(string organizationName, string legalAddress, string registrationNumber, string contactPerson, string name) : base(name)
        {
            OrganizationName = organizationName;
            LegalAddress = legalAddress;
            RegistrationNumber = registrationNumber;
            ContactPerson = contactPerson;

            Console.WriteLine("Конструктор класса Юридическое лицо");
        }

        public LegalEntity(ref LegalEntity other)
        {
            OrganizationName = other.OrganizationName;
            LegalAddress = other.LegalAddress;
            RegistrationNumber = other.RegistrationNumber;
            ContactPerson = other.ContactPerson;
            ContractNumber = other.ContractNumber;
            Address = other.Address;
            Name = other.Name;

            Console.WriteLine("Конструктор копирования класса Юридическое лицо");
        }

        public LegalEntity(LegalEntity other)
        {
            Name = other.Name;
            Address = other.Address;
            ContractNumber = other.ContractNumber;
            OrganizationName = other.OrganizationName;
            LegalAddress = other.LegalAddress;
            RegistrationNumber = other.RegistrationNumber;
            ContactPerson = other.ContactPerson;

            other.Name = string.Empty;
            other.Address = string.Empty;
            other.ContractNumber = string.Empty;
            other.OrganizationName = string.Empty;
            other.LegalAddress = string.Empty;
            other.RegistrationNumber = string.Empty;
            other.ContactPerson = string.Empty;

            Console.WriteLine("Конструктор перемещения класса Юридическое лицо");
        }

        public int CompareTo(LegalEntity? other)
        {
            if (other is null)
                return 1;

            int nameComparison = string.Compare(Name, other.Name);
            if (nameComparison != 0)
                return nameComparison;

            return 0;
        }

        public static bool operator ==(LegalEntity legalEntity1, LegalEntity legalEntity2)
        {
            if (legalEntity1.Name == legalEntity2.Name &&
                legalEntity1.Address == legalEntity2.Address &&
                legalEntity1.ContractNumber == legalEntity2.ContractNumber &&
                legalEntity1.OrganizationName == legalEntity2.OrganizationName &&
                legalEntity1.LegalAddress == legalEntity2.LegalAddress &&
                legalEntity1.RegistrationNumber == legalEntity2.RegistrationNumber &&
                legalEntity1.ContactPerson == legalEntity2.ContactPerson)
                return true;

            return false;
        }

        public static bool operator !=(LegalEntity legalEntity1, LegalEntity legalEntity2)
        {
            if (legalEntity1.Name != legalEntity2.Name &&
                legalEntity1.Address != legalEntity2.Address &&
                legalEntity1.ContractNumber != legalEntity2.ContractNumber &&
                legalEntity1.OrganizationName != legalEntity2.OrganizationName &&
                legalEntity1.LegalAddress != legalEntity2.LegalAddress &&
                legalEntity1.RegistrationNumber != legalEntity2.RegistrationNumber &&
                legalEntity1.ContactPerson != legalEntity2.ContactPerson)
                return true;

            return false;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();

            Console.WriteLine($"Название организации юридического лица: {OrganizationName}");
            Console.WriteLine($"Юридический адрес: {LegalAddress}");
            Console.WriteLine($"Основной государственный регистрационный номер: {RegistrationNumber}");
            Console.WriteLine($"Контактное лицо: {ContactPerson}");

            Console.WriteLine();
        }
    }
}
