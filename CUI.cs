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
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine(@"Welcome to File Assistant console application!
                        Please, enter the number of required action.
                        1 - File system stats.
                        2 - Text file actions.
                        3 - JSON file actions.
                        4 - XML file actions.
                        5 - Zip archive actions.
                        0 - Close application.");
                string? command = Console.ReadLine();
                if (command == "0")
                {
                    break;
                }
                if (Int32.TryParse(command, out int result) && result >= 0 && result <= 5 && answers.CanSolveTask(result))
                {
                    try
                    {
                        Methods[result - 1].Invoke(result - 1);
                        Console.WriteLine("Action executed successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command. Please enter a number between 0 and 5.");
                }
            }
        }

        private Person PromptForPerson()
        {
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
            return new Person(
                String.IsNullOrWhiteSpace(firstname) ? "The firstname is missing" : firstname,
                String.IsNullOrWhiteSpace(lastname) ? "The lastname is missing" : lastname,
                Int32.TryParse(age, out int result) ? result : 0,
                String.IsNullOrWhiteSpace(country) ? "The country is missing" : country,
                String.IsNullOrWhiteSpace(city) ? "The city is missing" : city);
        }

        private void JSONSerialization(int num)
        {
            Console.WriteLine("Enter file name:");
            answers.FileName = Console.ReadLine();
            answers.InputPerson = PromptForPerson();
            answers.SolveTask(num);
        }

        private void XMLSerialization(int num)
        {
            Console.WriteLine("Enter file name:");
            answers.FileName = Console.ReadLine();
            answers.InputPerson = PromptForPerson();
            answers.SolveTask(num);
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

