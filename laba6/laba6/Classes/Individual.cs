namespace laba6.Classes
{
    public class Individual : Client, IComparable<Individual> 
    {
        public string PassportNumber { get; set; }
        public string Gender { get; set; }

        public Individual() : base()
        {
            PassportNumber = string.Empty;
            Gender = string.Empty;

            Console.WriteLine("Конструктор класса Физическое лицо");
        }

        public Individual(string passportNumber, string gender, string name, string address = "", string contract_number = "") : base(name, address: address, contract_number: contract_number)
        {
            PassportNumber = passportNumber;
            Gender = gender;

            Console.WriteLine("Конструктор класса Физическое лицо");
        }

        public int CompareTo(Individual? other)
        {
            if (other is null)
                return 1;

            int nameComparison = string.Compare(Name, other.Name);
            if (nameComparison != 0)
                return nameComparison;

            return 0;
        }

        public static bool operator ==(Individual individual1, Individual individual2)
        {
            if (individual1.Name == individual2.Name &&
                individual1.Address == individual2.Address &&
                individual1.ContractNumber == individual2.ContractNumber &&
                individual1.PassportNumber == individual2.PassportNumber &&
                individual1.Gender == individual2.Gender)
                return true;

            return false;
        }

        public static bool operator !=(Individual individual1, Individual individual2)
        {
            if (individual1.Name != individual2.Name &&
                individual1.Address != individual2.Address &&
                individual1.ContractNumber != individual2.ContractNumber &&
                individual1.PassportNumber != individual2.PassportNumber &&
                individual1.Gender != individual2.Gender)
                return true;

            return false;
        }

        public Individual(string passportNumber, string gender, string name) : base(name)
        {
            PassportNumber = passportNumber;
            Gender = gender;

            Console.WriteLine("Конструктор класса Физическое лицо");
        }

        public Individual(ref Individual other)
        {
            PassportNumber = other.PassportNumber;
            Gender = other.Gender;
            Address = other.Address;
            ContractNumber = other.ContractNumber;
            Name = other.Name;

            Console.WriteLine("Конструктор копирования класса Физическое лицо");
        }

        public Individual(Individual other)
        {
            Name = other.Name;
            Address = other.Address;
            ContractNumber = other.ContractNumber;
            PassportNumber = other.PassportNumber;
            Gender = other.Gender;

            other.Name = string.Empty;
            other.Address = string.Empty;
            other.ContractNumber = string.Empty;
            other.PassportNumber = string.Empty;
            other.Gender = string.Empty;

            Console.WriteLine("Конструктор перемещения класса Физическое лицо");
        }

        public override void ShowInfo()
        {
            base.ShowInfo();

            Console.WriteLine($"Номер паспорта: {PassportNumber}");
            Console.WriteLine($"Пол: {Gender}");

            Console.WriteLine();
        }

        public void ChangePassportNumber()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите новый номер паспорта: ");
                var passportNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(passportNumber))
                    continue;

                PassportNumber = passportNumber;

                break;
            }
        }

        public void ChangeGender()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите новый пол: ");
                var gender = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(gender))
                    continue;

                Gender = gender;

                break;
            }
        }
    }
}
