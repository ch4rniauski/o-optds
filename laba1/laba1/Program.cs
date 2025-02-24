using System.Text.RegularExpressions;

var registrationLog = new RegistrationLog();

while (true)
{
    Console.WriteLine("Сначала Вам необходимо создать организацию");
    Console.WriteLine("1 = Продолжить");
    Console.WriteLine("2 = Выйти");
    Console.Write(">> ");

    var choise = Console.ReadLine();

    if (choise == "1")
    {
        registrationLog.ChangeName();
        registrationLog.ChangePhoneNumber();
    }
    else if (choise == "2")
        Environment.Exit(0);
    else
    {
        Console.Clear();
        continue;
    }

    break;
}

for (int i = 0; i < 1; )
{
    Console.WriteLine("Введите номер операции, которую хотите произвести:");
    Console.WriteLine("1 = Просмотреть общую информацию об организации");
    Console.WriteLine("2 = Изменить название организации");
    Console.WriteLine("3 = Изменить телефонный номер огранизации");
    Console.WriteLine("4 = Просмотреть список клиентов");
    Console.WriteLine("5 = Добавить клиента в журнал регистрации");
    Console.WriteLine("6 = Изменить информацию о конкретном клиенте");
    Console.WriteLine("7 = Просмотреть информацию о конкретном клиенте");
    Console.WriteLine("8 = Завершить работу программы");
    Console.Write(">> ");

    var choise = Console.ReadLine();

    switch (choise)
    {
        case "1":
            registrationLog.ShowInfo();
            break;
        case "2":
            registrationLog.ChangeName();
            break;
        case "3":
            registrationLog.ChangePhoneNumber();
            break;
        case "4":
            registrationLog.ShowClientsList();
            break;
        case "5":
            registrationLog.AddClient();
            break;
        case "6":
            registrationLog.ChangeClientInfo();
            break;
        case "7":
            registrationLog.ShowClientInfo();
            break;
        case "8":
            i++;
            break;
    }
}

class RegistrationLog
{
    private string Name { get; set; } = string.Empty;
    private string PhoneNumber { get; set; } = string.Empty;
    private List<Client> Clients { get; set; } = new();

    public void ShowInfo()
    {
        Console.Clear();
        Console.WriteLine($"Название организации: {Name}");
        Console.WriteLine($"Телефонный номер организации: {PhoneNumber}");
        Console.WriteLine();
    }

    public void ChangeName()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Введите название организации: ");

            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
                continue;

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
                || (!Regex.IsMatch(phoneNumber, @"^\+\d{12}$") && !Regex.IsMatch(phoneNumber, @"^\d{11}$")))
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

        for (int i = 0; i < 1; )
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
}

class Client
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string ContractNumber { get; set; } = string.Empty;

    public Client(string name)
    {
        Name = name;
    }

    public Client(string name, string address = "", string contract_number = "")
    {
        Name = name;
        Address = address;
        ContractNumber = contract_number;
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

    public void ShowInfo()
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

        Console.WriteLine();
    }
}
