using laba7.Classes;
try{
    var genericClass = new GenericClass<Individual>(5);
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
        Console.WriteLine("5 = Добавить в журнал объект по умолчанию");
        Console.WriteLine("6 = Просмотреть информацию об объекте по его индексу");
        Console.WriteLine("7 = Сравнить 2 объекта журнала");
        Console.WriteLine("8 = Завершить работу программы");
        Console.WriteLine("9 = Отсортировать элементы");
        Console.WriteLine("10 = Добавить журнал");
        Console.WriteLine("12 = Скопировать один журнал в другой");
        Console.WriteLine("13 = Переместить журнал");
        Console.WriteLine("14 = Удалить журнал");
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
        Console.WriteLine("27 = Сгенерировать исколючение");
        Console.WriteLine("28 = Сгенерировать кастомное исколючение");
        Console.WriteLine("29 = Сгенерировать кастомное исколючение для обработчика верхнего уровня");
        Console.WriteLine("30 = Сгенерировать кастомное исколючение для локального обработчика");
        Console.Write(">> ");

        var choise = Console.ReadLine();
        (bool, RegistrationLog?) cortege;

        switch (choise)
        {
            case "1":
                cortege = FindOrganisation(regLogList);

                if (cortege.Item1)
                    break;

                var result = cortege.Item2! << 1;
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
                Console.Clear();
                cortege = FindOrganisation(regLogList);

                if (cortege.Item1)
                    break;

                if (cortege.Item2!.Clients.Count == 0)
                {
                    Console.WriteLine("Журнал выбранной организации пуст");
                    Console.WriteLine();
                    break;
                }

                cortege.Item2!++;
                Console.Clear();
                break;
            case "6":
                Console.Clear();
                cortege = FindOrganisation(regLogList);

                if (cortege.Item1)
                    break;

                if (cortege.Item2!.Clients.Count == 0)
                {
                    Console.WriteLine("Журнал выбранной организации пуст");
                    Console.WriteLine();
                    break;
                }

                int index = 0;

                while (true)
                {
                    Console.Clear();
                    Console.Write("Введите индекс объекта: ");

                    var str = Console.ReadLine();

                    if (!Int32.TryParse(str, out index))
                        continue;
                    break;
                }

                var client = cortege.Item2![index];

                client.ShowInfo();
                break;
            case "7":
                Console.Clear();
                cortege = FindOrganisation(regLogList);

                if (cortege.Item1)
                    break;

                if (cortege.Item2!.Clients.Count <= 1)
                {
                    Console.WriteLine("В выбранномм журнале недостаточно объектов для сравнения");
                    Console.WriteLine();
                    break;
                }

                int indexObj = 0;

                while (true)
                {
                    Console.Clear();
                    Console.Write("Введите индекс 1-ого объекта: ");

                    var str = Console.ReadLine();

                    if (!Int32.TryParse(str, out indexObj))
                        continue;
                    break;
                }
                int indexObj2 = 0;
                var client1 = cortege.Item2![indexObj];

                while (true)
                {
                    Console.Clear();
                    Console.Write("Введите индекс 2-ого объекта: ");

                    var str = Console.ReadLine();

                    if (!Int32.TryParse(str, out indexObj2))
                        continue;
                    break;
                }

                var client2 = cortege.Item2![indexObj2];

                while (true)
                {
                    Console.Clear();
                    Console.Write("Введите оператор сравнения: ");

                    var answ = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(answ) || (answ != "<" && answ != ">" && answ != "=="))
                        continue;

                    switch (answ)
                    {
                        case "<":
                            if (client1 < client2)
                                Console.WriteLine("Вы правы");
                            else
                                Console.WriteLine("Вы не правы");
                            break;
                        case ">":
                            if (client1 > client2)
                                Console.WriteLine("Вы правы");
                            else
                                Console.WriteLine("Вы не правы");
                            break;
                        case "==":
                            if (client1 == client2)
                                Console.WriteLine("Вы правы");
                            else
                                Console.WriteLine("Вы не правы");
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine();
                    break;
                }

                break;
            case "8":
                i++;
                break;
            case "9":
                Console.Clear();
                cortege = FindOrganisation(regLogList);

                if (cortege.Item1)
                    break;

                if (cortege.Item2!.Clients.Count == 0)
                {
                    Console.WriteLine("Журнал выбранной организации пуст");
                    Console.WriteLine();
                    break;
                }

                cortege.Item2.Clients.Sort();
                break;
            case "10":
                AddRegLog(regLogList);
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

                cortege.Item2!.ChangeIndividualInfo();
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

                            if (!Int32.TryParse(count, out int result1))
                                continue;

                            cortege.Item2.CopyIndividuals(individual, result1);
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

                            if (!Int32.TryParse(count, out int result2))
                                continue;

                            cortege.Item2.CopyLegalEntities(individual1, result2);
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
            case "27":
                Console.Clear();
                try
                {
                    Console.WriteLine("Генерируется исключение деления на ноль");
                    throw new DivideByZeroException();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.Write("Нажмите любую клавишу, чтобы продолжить");
                    Console.ReadLine();
                }
                Console.Clear();
                try
                {
                    Console.WriteLine("Генерируется исключение нулевой ссылки");
                    throw new NullReferenceException();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.Write("Нажмите любую клавишу, чтобы продолжить");
                    Console.ReadLine();
                }
                Console.Clear();
                break;
            case "28":
                Console.Clear();
                try
                {
                    Console.WriteLine("Генерируется первое кастомное исключение");
                    throw new FirstCustomException("First custom exception was thrown");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.Write("Нажмите любую клавишу, чтобы продолжить");
                    Console.ReadLine();
                }
                Console.Clear();
                try
                {
                    Console.WriteLine("Генерируется второе кастомное исключение");
                    throw new SecondCustomException("Second custom exception was thrown");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.Write("Нажмите любую клавишу, чтобы продолжить");
                    Console.ReadLine();
                }
                Console.Clear();
                break;
            case "29":
                Console.Clear();
                Console.WriteLine("Генерируется первое кастомное исключение для обработчика верхнего уровня");
                throw new FirstCustomException("First custom exception was thrown");
            case "30":
                Console.Clear();
                ThrowExc();
                break;
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    Console.Write("Нажмите любую клавишу, чтобы продолжить");
    Console.ReadLine();
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

static void ThrowExc()
{
    try
    {
        Console.Clear();
        Console.WriteLine("Генерируется первое кастомное исключение для локального обработчика");
        throw new FirstCustomException("First custom exception was thrown");
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        Console.Write("Нажмите любую клавишу, чтобы продолжить");
        Console.ReadLine();
    }
}
