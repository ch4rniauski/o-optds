using laba3.Classes;

var regLogList = new List<RegistrationLog>();
var registrationLog = new RegistrationLog();
regLogList.Add(registrationLog);

while (true)
{
    Console.WriteLine("Сначала Вам необходимо создать организацию");
    Console.WriteLine("1 = Продолжить");
    Console.WriteLine("2 = Выйти");
    Console.Write(">> ");

    var choise = Console.ReadLine();

    if (choise == "1")
    {
        registrationLog.ChangeName(regLogList);
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

for (int i = 0; i < 1;)
{
    Console.WriteLine("Введите номер операции, которую хотите произвести:");
    Console.WriteLine("1 = Просмотреть общую информацию об организации");
    Console.WriteLine("2 = Изменить название организации");
    Console.WriteLine("3 = Изменить телефонный номер огранизации");
    Console.WriteLine("4 = Просмотреть список объектов в журнале");
    Console.WriteLine("5 = Добавить клиента в журнал регистрации");
    Console.WriteLine("6 = Изменить информацию о конкретном клиенте");
    Console.WriteLine("7 = Просмотреть информацию о конкретном клиенте");
    Console.WriteLine("8 = Завершить работу программы");
    Console.WriteLine("9 = Просмотреть конкретную информацию о конкретном клиенте");
    Console.WriteLine("10 = Добавить журнал");
    Console.WriteLine("11 = Скопировать n-ное количество клиентов в журнал");
    Console.WriteLine("12 = Скопировать один журнал в другой");
    Console.WriteLine("13 = Переместить журнал");
    Console.WriteLine("14 = Удалить журнал");
    Console.WriteLine("15 = Скопировать одного клиента в другого");
    Console.WriteLine("16 = Переместить клиента");
    Console.WriteLine("17 = Удалить кого-либо из журнала регистрации");
    Console.WriteLine("18 = Добавить физическое лицо");
    Console.WriteLine("19 = Просмотреть информацию о конкретном физическом лице");
    Console.WriteLine("20 = Добавить юридическое лицо");
    Console.WriteLine("21 = Просмотреть информацию о конкретном юридическом лице");
    Console.WriteLine("22 = Изменить информацию о конкретном физическом лице");
    Console.WriteLine("23 = Скопировать n-ное количество физических лиц в журнал");
    Console.WriteLine("24 = Скопировать n-ное количество юридических лиц в журнал");
    Console.WriteLine("25 = Переместить физическое лицо");
    Console.WriteLine("26 = Переместить юридическое лицо");
    Console.Write(">> ");

    var choise = Console.ReadLine();
    (bool, RegistrationLog?) cortege;

    switch (choise)
    {
        case "1":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.ShowInfo();
            break;
        case "2":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.ChangeName(regLogList);
            break;
        case "3":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.ChangePhoneNumber();
            break;
        case "4":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.ShowClientsList();
            break;
        case "5":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.AddClient();
            break;
        case "6":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.ChangeClientInfo();
            break;
        case "7":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.ShowClientInfo();
            Console.WriteLine();
            break;
        case "8":
            i++;
            break;
        case "9":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.ShowClientInfoByParam();
            break;
        case "10":
            AddRegLog(regLogList);
            break;
        case "11":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя клиента, которого хотите скопировать: ");

                var name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                var client = cortege.Item2!.Clients.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());

                if (client is null)
                {
                    Console.Clear();
                    Console.WriteLine("Такого клиента не существует");
                }
                else
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Введите количесвто копий");

                        var count = Console.ReadLine();

                        if (!Int32.TryParse(count, out int result))
                            continue;

                        cortege.Item2.CopyClients(client, result);
                        break;
                    }
                }
                break;
            }
            break;
        case "12":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            new RegistrationLog(ref cortege.Item2!);
            break;
        case "13":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            new RegistrationLog(cortege.Item2!);
            break;
        case "14":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            regLogList.Remove(cortege.Item2!);
            cortege.Item2 = null;
            GC.Collect();
            Console.WriteLine("Сборщик мусора удалил выбранный журнал");
            break;
        case "15":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            string? name1;
            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя клиента: ");
                name1 = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name1))
                    continue;
                break;
            }

            var client1 = cortege.Item2!.Clients.FirstOrDefault(c => c.Name.ToLower() == name1.ToLower());

            if (client1 is null)
            {
                Console.Clear();
                Console.WriteLine("Данный клиент не найден");
            }

            new Client(ref client1!);
            break;
        case "16":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            string? name2;
            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя клиента: ");
                name2 = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name2))
                    continue;
                break;
            }

            var client2 = cortege.Item2!.Clients.FirstOrDefault(c => c.Name.ToLower() == name2.ToLower());

            if (client2 is null)
            {
                Console.Clear();
                Console.WriteLine("Данный клиент не найден");
                break;
            }

            new Client(client2!);
            break;
        case "17":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            string? name3;
            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя клиента: ");
                name3 = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name3))
                    continue;
                break;
            }

            var client3 = cortege.Item2!.Clients.FirstOrDefault(c => c.Name.ToLower() == name3.ToLower());

            if (client3 is null)
            {
                Console.Clear();
                Console.WriteLine("Данный клиент не найден");
            }

            cortege.Item2!.Clients.Remove(client3!);
            client3 = null;
            GC.Collect();
            Console.WriteLine("Сборщик мусора удалил выбранный объект");
            Console.WriteLine();
            break;
        case "18":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.AddIndividual();
            break;
        case "19":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.ShowIndividualInfo();
            break;
        case "20":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.AddLegalEntity();
            break;
        case "21":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.ShowLegalEntityInfo();
            break;
        case "22":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            cortege.Item2!.ChangeClientInfo();
            break;
        case "23":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя физического лица, которого хотите скопировать: ");

                var name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                var individual = cortege.Item2!.Clients.FirstOrDefault(c => c.Name.ToLower() == name.ToLower()) as Individual;

                if (individual is null)
                {
                    Console.Clear();
                    Console.WriteLine("Такого клиента не существует");
                }
                else
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Введите количесвто копий");

                        var count = Console.ReadLine();

                        if (!Int32.TryParse(count, out int result))
                            continue;

                        cortege.Item2.CopyIndividuals(individual, result);
                        break;
                    }
                }
                break;
            }
            break;
        case "24":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            while (true)
            {
                Console.Clear();
                Console.Write("Введите название юридического лица, которого хотите скопировать: ");

                var name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                var individual1 = cortege.Item2!.Clients.FirstOrDefault(c => c.Name.ToLower() == name.ToLower()) as LegalEntity;

                if (individual1 is null)
                {
                    Console.Clear();
                    Console.WriteLine("Такого клиента не существует");
                }
                else
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Введите количесвто копий");

                        var count = Console.ReadLine();

                        if (!Int32.TryParse(count, out int result))
                            continue;

                        cortege.Item2.CopyLegalEntities(individual1, result);
                        break;
                    }
                }
                break;
            }
            break;
        case "25":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            string? name4;
            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя клиента: ");
                name4 = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name4))
                    continue;
                break;
            }

            var individual3 = cortege.Item2!.Clients.FirstOrDefault(c => c.Name.ToLower() == name4.ToLower()) as Individual;

            if (individual3 is null)
            {
                Console.Clear();
                Console.WriteLine("Данный клиент не найден");
                break;
            }

            new Individual(individual3!);
            break;
        case "26":
            cortege = FindOrganisation(regLogList);

            if (cortege.Item1)
                break;

            string? name5;
            while (true)
            {
                Console.Clear();
                Console.Write("Введите имя клиента: ");
                name5 = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name5))
                    continue;
                break;
            }

            var legalEntity = cortege.Item2!.Clients.FirstOrDefault(c => c.Name.ToLower() == name5.ToLower()) as LegalEntity;

            if (legalEntity is null)
            {
                Console.Clear();
                Console.WriteLine("Данный клиент не найден");
                break;
            }

            new LegalEntity(legalEntity!);
            break;
    }
}

static void AddRegLog(List<RegistrationLog> regLogList)
{
    var registrationLog = new RegistrationLog();

    registrationLog.ChangeName(regLogList);
    registrationLog.ChangePhoneNumber();

    regLogList.Add(registrationLog);
}

static (bool, RegistrationLog?) FindOrganisation(List<RegistrationLog> regLogList)
{
    Console.Clear();

    string? name;
    while (true)
    {
        Console.Write("Введите название организации: ");
        name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
            continue;
        break;
    }

    var doesExist = regLogList.FirstOrDefault(r => r.Name.ToLower() == name.ToLower());

    if (doesExist is null)
    {
        Console.WriteLine("Такой организации нет");
        Console.WriteLine();
    }

    return ((doesExist is null), doesExist);
}
