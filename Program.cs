
class Laba7
{
    static void Main()
    {
        // Словари для хранения логинов и паролей
        Dictionary<string, string> studentLogins = new Dictionary<string, string>
        {
            { "stud", "pass1" },
        };

        Dictionary<string, string> teacherLogins = new Dictionary<string, string>
        {
            { "prep", "pass2" }
        };

        Dictionary<string, string> adminLogins = new Dictionary<string, string>
        {
            { "admin", "pass3" }
        };

        // Предварительные данные
        List<Student> studentList = new List<Student>
        {
            new Student("Дроздовский", "Григорий", "Михайлович", 2003, "Группа 1"),
        };

        List<Teacher> teacherList = new List<Teacher>
        {
            new Teacher("Фидарчук", "Андрей", "Олегович", 1990, "Информатика")
        };

        Journal gradeJournal = new Journal();

        while (true)
        {
            Console.WriteLine("Выберите способ входа: Студент, Преподаватель, Администратор");
            string userRole = Console.ReadLine()?.ToLower();

            if (userRole == "студент")
            {
                if (Authenticate(studentLogins))
                {
                    Console.WriteLine("Добро пожаловать, студент!");
                    Console.WriteLine("Ваш журнал:");
                    gradeJournal.DisplayJournal();
                }
            }
            else if (userRole == "преподаватель")
            {
                if (Authenticate(teacherLogins))
                {
                    Console.WriteLine("Добро пожаловать, преподаватель!");
                    TeacherMenu(gradeJournal);
                }
            }
            else if (userRole == "администратор")
            {
                if (Authenticate(adminLogins))
                {
                    Console.WriteLine("Добро пожаловать, администратор!");
                    AdminMenu(studentList, teacherList, gradeJournal);
                }
            }
            else
            {
                Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
            }
        }
    }

    static bool Authenticate(Dictionary<string, string> validLogins)
    {
        Console.Write("Введите логин: ");
        string inputLogin = Console.ReadLine();
        Console.Write("Введите пароль: ");
        string inputPassword = Console.ReadLine();

        if (validLogins.ContainsKey(inputLogin) && validLogins[inputLogin] == inputPassword)
        {
            return true;
        }

        Console.WriteLine("Неверные логин или пароль.");
        return false;
    }

    static void TeacherMenu(Journal gradeJournal)
    {
        while (true)
        {
            Console.WriteLine("\nМеню преподавателя:");
            Console.WriteLine("1. Просмотреть журнал");
            Console.WriteLine("2. Добавить оценку");
            Console.WriteLine("3. Изменить оценку");
            Console.WriteLine("4. Удалить оценку");
            Console.WriteLine("5. Выход");

            string teacherChoice = Console.ReadLine();
            switch (teacherChoice)
            {
                case "1":
                    gradeJournal.DisplayJournal();
                    break;
                case "2":
                    gradeJournal.AddGrade();
                    break;
                case "3":
                    gradeJournal.EditGrade();
                    break;
                case "4":
                    gradeJournal.DeleteGrade();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    break;
            }
        }
    }

    static void AdminMenu(List<Student> students, List<Teacher> teachers, Journal gradeJournal)
    {
        while (true)
        {
            Console.WriteLine("\nМеню администратора:");
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Удалить студента");
            Console.WriteLine("3. Добавить преподавателя");
            Console.WriteLine("4. Удалить преподавателя");
            Console.WriteLine("5. Просмотреть журнал");
            Console.WriteLine("6. Выход");
            string adminChoice = Console.ReadLine();
            switch (adminChoice)
            {
                case "1":
                    Console.WriteLine("Введите данные студента: ");
                    students.Add(Student.CreateStudent());
                    break;
                case "2":
                    Console.WriteLine("Введите фамилию студента для удаления: ");
                    string studentLastNameToRemove = Console.ReadLine();
                    students.RemoveAll(student => student.Name2 == studentLastNameToRemove);
                    Console.WriteLine("Студент удален.");
                    break;
                case "3":
                    Console.WriteLine("Введите данные преподавателя: ");
                    teachers.Add(Teacher.CreateTeacher());
                    break;
                case "4":
                    Console.WriteLine("Введите фамилию преподавателя для удаления: ");
                    string teacherLastNameToRemove = Console.ReadLine();
                    teachers.RemoveAll(teacher => teacher.Name2 == teacherLastNameToRemove);
                    Console.WriteLine("Преподаватель удален.");
                    break;
                case "5":
                    gradeJournal.DisplayJournal();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    break;
            }
        }
    }
}

// Класс для студентов
class Student
{
    public string Name1 { get; set; }
    public string Name2 { get; set; }
    public string Name3 { get; set; }
    public int YearOfBirth { get; set; }
    public string Group { get; set; }

    public Student(string name1, string name2, string name3, int yearOfBirth, string group)
    {
        Name1 = name1;
        Name2 = name2;
        Name3 = name3;
        YearOfBirth = yearOfBirth;
        Group = group;
    }

    public static Student CreateStudent()
    {
        Console.Write("Фамилия: ");
        string last = Console.ReadLine();
        Console.Write("Имя: ");
        string first = Console.ReadLine();
        Console.Write("Отчество: ");
        string middle = Console.ReadLine();
        Console.Write("Год рождения: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Группа: ");
        string group = Console.ReadLine();

        return new Student(last, first, middle, year, group);
    }
}

// Класс для преподавателей
class Teacher
{
    public string Name1 { get; set; }
    public string Name2 { get; set; }
    public string Name3 { get; set; }
    public int YearOfBirth { get; set; }
    public string Discipline { get; set; }

    public Teacher(string name1, string name2, string name3, int yearOfBirth, string discipline)
    {
        Name1 = name1;
        Name2 = name2;
        Name3 = name3;
        YearOfBirth = yearOfBirth;
        Discipline = discipline;
    }

    public static Teacher CreateTeacher()
    {
        Console.Write("Фамилия: ");
        string last = Console.ReadLine();
        Console.Write("Имя: ");
        string first = Console.ReadLine();
        Console.Write("Отчество: ");
        string middle = Console.ReadLine();
        Console.Write("Год рождения: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Дисциплина: ");
        string discipline = Console.ReadLine();

        return new Teacher(last, first, middle, year, discipline);
    }
}

// Класс для работы с журналом
class Journal
{
    private Dictionary<string, int> gradeRecords = new Dictionary<string, int>();

    public void DisplayJournal()
    {
        if (gradeRecords.Count == 0)
        {
            Console.WriteLine("Журнал пуст.");
            return;
        }

        foreach (var record in gradeRecords)
        {
            Console.WriteLine($"{record.Key}: {record.Value}");
        }
    }

    public void AddGrade()
    {
        Console.Write("Введите предмет: ");
        string subject = Console.ReadLine();
        Console.Write("Введите оценку (1-5): ");
        int grade = int.Parse(Console.ReadLine());
        gradeRecords[subject] = grade;
        Console.WriteLine("Оценка добавлена.");
    }

    public void EditGrade()
    {
        Console.Write("Введите предмет для изменения оценки: ");
        string subject = Console.ReadLine();

        if (gradeRecords.ContainsKey(subject))
        {
            Console.Write("Введите новую оценку (1-5): ");
            int grade = int.Parse(Console.ReadLine());
            gradeRecords[subject] = grade;
            Console.WriteLine("Оценка изменена.");
        }
        else
        {
            Console.WriteLine("Такого предмета нет в журнале.");
        }
    }

    public void DeleteGrade()
    {
        Console.Write("Введите предмет для удаления: ");
        string subject = Console.ReadLine();

        if (gradeRecords.Remove(subject))
        {
            Console.WriteLine("Оценка удалена.");
        }
        else
        {
            Console.WriteLine("Такого предмета нет в журнале.");
        }
    }
}
