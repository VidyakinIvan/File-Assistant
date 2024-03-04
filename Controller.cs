namespace File_Assistant
{
    public class Controller
    {
        private List<Action<int>> Methods { get; }
        private View View { get; }
        readonly Tasks answers;
        public Controller(Tasks answers)
        {
            this.answers = answers;
            this.View = new();
            Methods =
            [
                FileSystem,
                FileStreams,
                JSONSerialization,
                XMLSerialization,
                ZipArchives
            ];
            Run();
        }

        public void Run()
        {
            while (true)
            {
                string? command = View.GetCommand();
                if (command == "0")
                {
                    break;
                }
                if (Int32.TryParse(command, out int result) && result > 0 && result <= 5 && answers.CanSolveTask(result))
                {
                    try
                    {
                        Methods[result - 1].Invoke(result - 1);
                        View.ShowResult("Action executed successfully.");
                    }
                    catch (Exception ex)
                    {
                        View.ShowResult($"An error occurred: {ex.Message}");
                    }
                }
                else
                {
                    View.ShowResult("Invalid command. Please enter a number between 0 and 5.");
                }
            }
        }
        private void JSONSerialization(int num)
        {
            answers.FileName = View.GetFilename();
            answers.InputPerson = View.PromptForPerson();
            answers.SolveTask(num);
        }
        private void XMLSerialization(int num)
        {
            answers.FileName = View.GetFilename();
            answers.InputPerson = View.PromptForPerson();
            answers.SolveTask(num);
        }
        private void FileSystem(int num)
        {
            answers.SolveTask(num);
        }
        private void FileStreams(int num)
        {
            answers.FileName = View.GetFilename();
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

