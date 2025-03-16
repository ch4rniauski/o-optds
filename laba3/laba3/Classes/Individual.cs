namespace laba3.Classes
{
    public class Individual : Client
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

        public new void ShowInfo()
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
