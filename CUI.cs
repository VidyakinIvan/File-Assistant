namespace File_Assistant
{
    public class CUI
    {
        private List<Action<int>> Methods { get; }
        readonly Tasks answers;
        public CUI(Tasks answers)
        {
            this.answers = answers;
            Methods =
            [
                FileSystem,
                FileStreams,
                JSONSerialization,
                XMLSerialization,
                ZipArchives
            ];
            Console.WriteLine(@"Welcome to File Assistant console application!
                Please, enter the number of required action.
                1 - File system stats.
                2 - Text file actions.
                3 - JSON file actions.
                4 - XML file actions.
                5 - Zip archive actions.
                0 - Close application.");
            string? command = Console.ReadLine();
            while (command != "0")
            {
                if (Int32.TryParse(command, out int result) && answers.CanSolveTask(result))
                {
                    Methods[result - 1].Invoke(result - 1);
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
                Console.WriteLine("Please, enter the number.");
                command = Console.ReadLine();
            }

        }
        private void FileSystem(int num)
        {
            answers.SolveTask(num);
        }
        private void FileStreams(int num)
        {
            Console.WriteLine("Enter file name:");
            answers.FileName = Console.ReadLine();
            Console.WriteLine("Enter file content...");
            answers.InputString = Console.ReadLine();
            answers.SolveTask(num);
        }
        private void JSONSerialization(int num)
        {
            Console.WriteLine("Enter file name:");
            answers.FileName = Console.ReadLine();
            Console.WriteLine("Enter your firstname.");
            string? firstname = Console.ReadLine();
            Console.WriteLine("Enter your lastname.");
            string? lastname = Console.ReadLine();
            Console.WriteLine("Enter your age.");
            string? age = Console.ReadLine();
            Console.WriteLine("Enter your country.");
            string? country = Console.ReadLine();
            Console.WriteLine("Enter your city.");
            string? city = Console.ReadLine();
            Person person = new(
                String.IsNullOrWhiteSpace(firstname) ? "The firstname is missing" : firstname,
                String.IsNullOrWhiteSpace(lastname) ? "The lastname is missing" : lastname,
                Int32.TryParse(age, out int result) ? result : 0,
                String.IsNullOrWhiteSpace(country) ? "The country is missing" : country,
                String.IsNullOrWhiteSpace(city) ? "The city is missing" : city);
            answers.InputPerson = person;
            answers.SolveTask(num);
        }
        private void XMLSerialization(int num)
        {
            Console.WriteLine("Enter file name:");
            answers.FileName = Console.ReadLine();
            Console.WriteLine("Enter your firstname.");
            string? firstname = Console.ReadLine();
            Console.WriteLine("Enter your lastname.");
            string? lastname = Console.ReadLine();
            Console.WriteLine("Enter your age.");
            string? age = Console.ReadLine();
            Console.WriteLine("Enter your country.");
            string? country = Console.ReadLine();
            Console.WriteLine("Enter your city.");
            string? city = Console.ReadLine();
            Person person = new(
                String.IsNullOrWhiteSpace(firstname) ? "The firstname is missing" : firstname,
                String.IsNullOrWhiteSpace(lastname) ? "The lastname is missing" : lastname,
                Int32.TryParse(age, out int result) ? result : 0,
                String.IsNullOrWhiteSpace(country) ? "The country is missing" : country,
                String.IsNullOrWhiteSpace(city) ? "The city is missing" : city);
            answers.InputPerson = person;
            answers.SolveTask(num);
        }
        private void ZipArchives(int num)
        {
            Console.WriteLine("Enter achive name:");
            answers.FileName = Console.ReadLine();
            Console.WriteLine("Enter file path.");
            answers.InputString = Console.ReadLine();
            answers.SolveTask(num);
        }
    }

}

