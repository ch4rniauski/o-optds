using System.Text.RegularExpressions;

namespace laba3.Classes
{
    public class RegistrationLog
    {
        public string Name { get; set; }
        private string PhoneNumber { get; set; }
        public List<Client> Clients { get; set; }

        public RegistrationLog()
        {
            Name = string.Empty;
            PhoneNumber = string.Empty;
            Clients = new();

            Console.WriteLine("Конструктор без параметров класса Журнал регистрации");
        }

        public RegistrationLog(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Clients = new();

            Console.WriteLine("Конструктор с параметрами класса Журнал регистрации");
        }

        public RegistrationLog(ref RegistrationLog other)
        {
            Name = other.Name;
            PhoneNumber = other.PhoneNumber;
            Clients = other.Clients;

            Console.WriteLine("Конструктор копирования класса Журнал регистрации");
        }

        public RegistrationLog(RegistrationLog other)
        {
            Name = other.Name;
            PhoneNumber = other.PhoneNumber;
            Clients = other.Clients;

            other.Name = string.Empty;
            other.PhoneNumber = string.Empty;
            other.Clients = new();

            Console.WriteLine("Конструктор перемещения класса Журнал регистрации");
        }

        public void ShowInfo()
        {
            Console.Clear();
            Console.WriteLine($"Название организации: {Name}");
            Console.WriteLine($"Телефонный номер организации: {PhoneNumber}");
            Console.WriteLine();
        }

        public void ChangeName(List<RegistrationLog> regLogList)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите название организации: ");

                var name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                var doesExist = regLogList.FirstOrDefault(r => r.Name == name);

                if (doesExist is not null)
                {
                    Console.WriteLine("Организация с таким именем уже есть");
                    continue;
                }

                Name = name;

                break;
            }

            Console.Clear();
        }

        public void ChangePhoneNumber()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите телефонный номер организации: ");

                var phoneNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(phoneNumber)
                    || !Regex.IsMatch(phoneNumber, @"^\+\d{12}$") && !Regex.IsMatch(phoneNumber, @"^\d{11}$"))
                    continue;

                PhoneNumber = phoneNumber;

                break;
            }

            Console.Clear();
        }

        public void ShowClientsList()
        {
            Console.Clear();

            if (Clients.Count == 0)
            {
                Console.WriteLine("Список клиентов пуст");
                Console.WriteLine();
                return;
            }
            else
            {
                foreach (var client in Clients)
                    Console.Write($"{client.Name}, ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void AddClient()
        {
            string? name;
            string? address;
            string? contractNumber;

            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя клиента: ");

                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                break;
            }

            Console.Clear();
            Console.Write("Введите адрес клиента: ");

            address = Console.ReadLine();

            Console.Clear();
            Console.Write("Введите номер договора: ");

            contractNumber = Console.ReadLine();

            Console.Clear();

            Client client;

            if (string.IsNullOrWhiteSpace(address) && string.IsNullOrWhiteSpace(contractNumber))
                client = new Client(name);
            else if (!string.IsNullOrWhiteSpace(address) && string.IsNullOrWhiteSpace(contractNumber))
                client = new Client(name, address);
            else if (string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(contractNumber))
                client = new Client(name, contract_number: contractNumber);
            else
                client = new Client(name, address!, contractNumber!);

            Clients.Add(client);

            Console.WriteLine();
        }

        public void AddIndividual()
        {
            string? name;
            string? address;
            string? contractNumber;
            string? passportNumber;
            string? gender;

            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя клиента: ");

                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                break;
            }

            Console.Clear();
            Console.Write("Введите адрес клиента: ");

            address = Console.ReadLine();

            Console.Clear();            
            Console.Write("Введите номер договора: ");

            contractNumber = Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.Write("Введите номер паспорта: ");

                passportNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(passportNumber))
                    continue;

                break;
            }

            while (true)
            {
                Console.Clear();
                Console.Write("Введите пол: ");

                gender = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(gender))
                    continue;

                break;
            }
            Console.Clear();

            Individual individual;

            if (string.IsNullOrWhiteSpace(address) && string.IsNullOrWhiteSpace(contractNumber))
                individual = new Individual(passportNumber,gender, name);
            else if (!string.IsNullOrWhiteSpace(address) && string.IsNullOrWhiteSpace(contractNumber))
                individual = new Individual(passportNumber, gender, name, address: address);
            else if (string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(contractNumber))
                individual = new Individual(passportNumber, gender, name, contract_number: contractNumber);
            else
                individual = new Individual(passportNumber, gender, name, address!, contractNumber!);

            Clients.Add(individual);

            Console.WriteLine();
        }

        public void AddLegalEntity()
        {
            string? name;
            string? address;
            string? contractNumber;
            string? organizationName;
            string? legalAddress;
            string? registrationNumber;
            string? contactPerson;

            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя клиента: ");

                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                break;
            }

            Console.Clear();
            Console.Write("Введите адрес клиента: ");

            address = Console.ReadLine();

            Console.Clear();
            Console.Write("Введите номер договора: ");

            contractNumber = Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.Write("Введите название организации юридического лица: ");

                organizationName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(organizationName))
                    continue;

                break;
            }

            while (true)
            {
                Console.Clear();
                Console.Write("Введите юридический адрес: ");

                legalAddress = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(legalAddress))
                    continue;

                break;
            }

            while (true)
            {
                Console.Clear();
                Console.Write("Введите основной государственный регистрационный номер: ");

                registrationNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(registrationNumber))
                    continue;

                break;
            }

            while (true)
            {
                Console.Clear();
                Console.Write("Введите контактное лицо: ");

                contactPerson = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(contactPerson))
                    continue;

                break;
            }

            Console.Clear();

            LegalEntity legalEntity;

            if (string.IsNullOrWhiteSpace(address) && string.IsNullOrWhiteSpace(contractNumber))
                legalEntity = new LegalEntity(organizationName, legalAddress, registrationNumber, contactPerson, name);
            else if (!string.IsNullOrWhiteSpace(address) && string.IsNullOrWhiteSpace(contractNumber))
                legalEntity = new LegalEntity(organizationName, legalAddress, registrationNumber, contactPerson, name, address: address);
            else if (string.IsNullOrWhiteSpace(address) && !string.IsNullOrWhiteSpace(contractNumber))
                legalEntity = new LegalEntity(organizationName, legalAddress, registrationNumber, contactPerson, name, contract_number: contractNumber);
            else
                legalEntity = new LegalEntity(organizationName, legalAddress, registrationNumber, contactPerson, name, address!, contractNumber!);

            Clients.Add(legalEntity);

            Console.WriteLine();
        }

        public void ChangeClientInfo()
        {
            string? clientName;

            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя клиента, информацию о котором хотите изменить: ");

                clientName = Console.ReadLine();

                Console.Clear();

                if (string.IsNullOrWhiteSpace(clientName))
                    continue;
                break;
            }

            var client = Clients.FirstOrDefault(c => c.Name.ToLower() == clientName.ToLower());

            if (client is null)
            {
                Console.WriteLine("Клиент с данным именем не найден");
                Console.WriteLine();
                return;
            }

            for (int i = 0; i < 1;)
            {
                Console.WriteLine("Выберите, что необходимо именить:");
                Console.WriteLine($"0 = Вернуться в главное меню");
                Console.WriteLine($"1 = Имя");
                Console.WriteLine($"2 = Адрес");
                Console.WriteLine($"3 = Номер договора");
                Console.Write(">> ");

                var choise = Console.ReadLine();

                switch (choise)
                {
                    case "0":
                        i++;
                        break;
                    case "1":
                        client.ChangeName();
                        i++;
                        break;
                    case "2":
                        client.ChangeAddress();
                        i++;
                        break;
                    case "3":
                        client.ChangeContractNumber();
                        i++;
                        break;
                }
            }
        }

        public void ChangeIndividualInfo()
        {
            string? individualName;

            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя физического лица, информацию о котором хотите изменить: ");

                individualName = Console.ReadLine();

                Console.Clear();

                if (string.IsNullOrWhiteSpace(individualName))
                    continue;
                break;
            }

            Individual? client = Clients.FirstOrDefault(c => c.Name.ToLower() == individualName.ToLower()) as Individual;

            if (client is null)
            {
                Console.WriteLine("Клиент с данным именем не найден");
                Console.WriteLine();
                return;
            }

            for (int i = 0; i < 1;)
            {
                Console.WriteLine("Выберите, что необходимо именить:");
                Console.WriteLine($"0 = Вернуться в главное меню");
                Console.WriteLine($"1 = Имя");
                Console.WriteLine($"2 = Адрес");
                Console.WriteLine($"3 = Номер договора");
                Console.WriteLine($"4 = Номер паспорта");
                Console.WriteLine($"5 = Пол");
                Console.Write(">> ");

                var choise = Console.ReadLine();

                switch (choise)
                {
                    case "0":
                        i++;
                        break;
                    case "1":
                        client.ChangeName();
                        i++;
                        break;
                    case "2":
                        client.ChangeAddress();
                        i++;
                        break;
                    case "3":
                        client.ChangeContractNumber();
                        i++;
                        break;
                    case "4":
                        client.ChangePassportNumber();
                        i++;
                        break;
                    case "5":
                        client.ChangeGender();
                        i++;
                        break;
                }
            }
        }

        public void ShowClientInfo()
        {
            string? clientName;

            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя клиента, информацию о котором желаете просмотреть: ");

                clientName = Console.ReadLine();

                Console.Clear();

                if (string.IsNullOrWhiteSpace(clientName))
                    continue;
                break;
            }

            var client = Clients.FirstOrDefault(c => c.Name.ToLower() == clientName.ToLower());

            if (client is null)
            {
                Console.WriteLine("Клиент с данным именем не найден");
                Console.WriteLine();
                return;
            }

            client.ShowInfo();
        }

        public void ShowIndividualInfo()
        {
            string? clientName;

            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя физического лица, информацию о котором желаете просмотреть: ");

                clientName = Console.ReadLine();

                Console.Clear();

                if (string.IsNullOrWhiteSpace(clientName))
                    continue;
                break;
            }

            Individual? client = Clients.FirstOrDefault(c => c.Name.ToLower() == clientName.ToLower()) as Individual;

            if (client is null)
            {
                Console.WriteLine("Клиент с данным именем не найден");
                Console.WriteLine();
                return;
            }

            client.ShowInfo();
        }

        public void ShowLegalEntityInfo()
        {
            string? clientName;

            while (true)
            {
                Console.Clear();
                Console.Write("Введите название юридического лица, информацию о котором желаете просмотреть: ");

                clientName = Console.ReadLine();

                Console.Clear();

                if (string.IsNullOrWhiteSpace(clientName))
                    continue;
                break;
            }

            LegalEntity? client = Clients.FirstOrDefault(c => c.Name.ToLower() == clientName.ToLower()) as LegalEntity;

            if (client is null)
            {
                Console.WriteLine("Клиент с данным именем не найден");
                Console.WriteLine();
                return;
            }

            client.ShowInfo();
        }

        public void ShowClientInfoByParam()
        {
            string? clientName;

            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя клиента, информацию о котором желаете просмотреть: ");

                clientName = Console.ReadLine();

                Console.Clear();

                if (string.IsNullOrWhiteSpace(clientName))
                    continue;
                break;
            }

            var client = Clients.FirstOrDefault(c => c.Name.ToLower() == clientName.ToLower());

            if (client is null)
            {
                Console.WriteLine("Клиент с данным именем не найден");
                Console.WriteLine();
                return;
            }

            while (true)
            {
                Console.Write("Введите параметр, по которому хотите просмотреть информацию: ");
                var param = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(param))
                    continue;
                client.ShowInfo(param);
                break;
            }
        }

        public void CopyClients(Client client, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var newClient = new Client(ref client);
                Clients.Add(newClient);
            }
        }

        public void CopyIndividuals(Individual individual, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var newIndividual = new Individual(ref individual);
                Clients.Add(newIndividual);
            }
        }

        public void CopyLegalEntities(LegalEntity legalEntity, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var newLegalEntity = new LegalEntity(legalEntity);
                Clients.Add(newLegalEntity);
            }
        }
    }
}
