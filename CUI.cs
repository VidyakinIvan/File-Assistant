namespace File_Assistant
{
    public class CUI
    {
        private List<Action<int>> Methods { get; }
        readonly Tasks answers;
        public CUI(Tasks answers)
        {
            this.answers = answers;
            Methods = new List<Action<int>>()
            {
                FileSystem,
                FileStreams,
                JSONSerialization,
                XMLSerialization,
                ZipArchives
            };
            Console.WriteLine(@"Приложение для выполнения первого практического задания.
                1 - Задание по работе с файловой системой.
                2 - Задание по работе с файловыми потоками.
                3 - Задание по работе с форматом JSON.
                4 - Задание по работе с форматом XML.
                5 - Задание по работе с архивом zip.
                0 - Выход. 
                Введите номер команды.");
            string? command = Console.ReadLine();
            while (command != "0")
            {
                if (Int32.TryParse(command, out int result) && answers.CanSolveTask(result))
                {
                    Methods[result - 1].Invoke(result - 1);
                }
                else
                {
                    Console.WriteLine("Неизвестная команда");
                }
                Console.WriteLine("Введите номер команды.");
                command = Console.ReadLine();
            }

        }
        private void FileSystem(int num)
        {
            answers.SolveTask(num);
        }
        private void FileStreams(int num)
        {
            Console.WriteLine("Введите имя файла:");
            answers.FileName = Console.ReadLine();
            Console.WriteLine("Введите любую строку...");
            answers.InputString = Console.ReadLine();
            answers.SolveTask(num);
        }
        private void JSONSerialization(int num)
        {
            Console.WriteLine("Введите имя файла:");
            answers.FileName = Console.ReadLine();
            Console.WriteLine("Введите имя.");
            string? firstname = Console.ReadLine();
            Console.WriteLine("Введите фамилию.");
            string? lastname = Console.ReadLine();
            Console.WriteLine("Введите возраст.");
            string? age = Console.ReadLine();
            Console.WriteLine("Введите страну.");
            string? country = Console.ReadLine();
            Console.WriteLine("Введите город.");
            string? city = Console.ReadLine();
            Person person = new(
                String.IsNullOrWhiteSpace(firstname) ? "Имя пропущено" : firstname,
                String.IsNullOrWhiteSpace(lastname) ? "Фамилия пропущена" : lastname,
                Int32.TryParse(age, out int result) ? result : 0,
                String.IsNullOrWhiteSpace(country) ? "Страна пропущена" : country,
                String.IsNullOrWhiteSpace(city) ? "Город пропущен" : city);
            answers.InputPerson = person;
            answers.SolveTask(num);
        }
        private void XMLSerialization(int num)
        {
            Console.WriteLine("Введите имя файла:");
            answers.FileName = Console.ReadLine();
            Console.WriteLine("Введите имя.");
            string? firstname = Console.ReadLine();
            Console.WriteLine("Введите фамилию.");
            string? lastname = Console.ReadLine();
            Console.WriteLine("Введите возраст.");
            string? age = Console.ReadLine();
            Console.WriteLine("Введите страну.");
            string? country = Console.ReadLine();
            Console.WriteLine("Введите город.");
            string? city = Console.ReadLine();
            Person person = new(
                String.IsNullOrWhiteSpace(firstname) ? "Имя пропущено" : firstname,
                String.IsNullOrWhiteSpace(lastname) ? "Фамилия пропущена" : lastname,
                Int32.TryParse(age, out int result) ? result : 0,
                String.IsNullOrWhiteSpace(country) ? "Страна пропущена" : country,
                String.IsNullOrWhiteSpace(city) ? "Город пропущен" : city);
            answers.InputPerson = person;
            answers.SolveTask(num);
        }
        private void ZipArchives(int num)
        {
            Console.WriteLine("Введите имя файла архива:");
            answers.FileName = Console.ReadLine();
            Console.WriteLine("Введите полный путь до файла.");
            answers.InputString = Console.ReadLine();
            answers.SolveTask(num);
        }
    }

}

