namespace laba3.Classes
{
    abstract public class Client
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContractNumber { get; set; }

        public Client()
        {
            Name = string.Empty;
            Address = string.Empty;
            ContractNumber = string.Empty;

            Console.WriteLine("Конструктор без параметров класса Клиент");
        }

        public Client(ref Client other)
        {
            Name = other.Name;
            Address = other.Address;
            ContractNumber = other.ContractNumber;

            Console.WriteLine("Конструктор копирования класса Клиент");
        }

        public Client(Client other)
        {
            Name = other.Name;
            Address = other.Address;
            ContractNumber = other.ContractNumber;

            other.Name = string.Empty;
            other.Address = string.Empty;
            other.ContractNumber = string.Empty;

            Console.WriteLine("Конструктор перемещения класса Клиент");
        }

        public Client(string name)
        {
            Name = name;
            Address = string.Empty;
            ContractNumber = string.Empty;

            Console.WriteLine("Конструктор с одним параметром класса Клиент");
        }

        public Client(string name, string address = "", string contract_number = "")
        {
            Name = name;
            Address = address;
            ContractNumber = contract_number;

            Console.WriteLine("Конструктор с параметрами класса Клиент");
        }

        public void ChangeName()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите новое имя: ");
                var name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                Name = name;

                break;
            }
        }

        public void ChangeAddress()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите новый адрес: ");
                var address = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(address))
                    continue;

                Address = address;

                break;
            }
        }

        public void ChangeContractNumber()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите новоый номер договора: ");
                var contractNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(contractNumber))
                    continue;

                ContractNumber = contractNumber;

                break;
            }
        }

        public virtual void ShowInfo()
        {
            Console.Clear();
            Console.WriteLine($"Имя клиента: {Name}");

            if (string.IsNullOrWhiteSpace(Address))
                Console.WriteLine("Ифнормации об адресе данного клиента нет");
            else
                Console.WriteLine($"Адрес клиента: {Address}");

            if (string.IsNullOrWhiteSpace(ContractNumber))
                Console.WriteLine("Ифнормации о номере договора клиента нет");
            else
                Console.WriteLine($"Адрес клиента: {ContractNumber}");
        }
    }
}
