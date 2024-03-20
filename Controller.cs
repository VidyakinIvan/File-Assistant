namespace File_Assistant
{
    public class Controller
    {
        private List<Action<int>> Methods { get; }
        private View View { get; }
        readonly IModel model;
        public Controller(IModel model)
        {
            this.model = model;
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
                if (Int32.TryParse(command, out int result) && result > 0 && result <= 5)
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
        private void FileSystem(int num)
        {
            View.ShowResult(model.FileSystemInfo());
        }
        private void FileStreams(int num)
        {
            switch (View.getFileCommand())
            {
                case "1":
                    model.FileName = View.ReadLine("Enter file name:");
                    model.InputString = "";
                    model.CreateTextFile();
                    break;
                case "2":
                    model.FileName = View.ReadLine("Enter file name:");
                    model.InputString = View.ReadLine("Enter file content...");
                    model.CreateTextFile();
                    break;
                //"3" => model.InsertDataInFile();
                //"4" => model.DeleteFile();
                case "0":
                    break;
                default:
                    View.ShowResult("Invalid command. Please enter a number between 0 and 4.");
                    break;
            }

        }
        private void JSONSerialization(int num)
        {
            model.FileName = View.ReadLine("Enter file name:");
            model.InputPerson = View.PromptForPerson();
            model.JsonFilesHandling();
        }
        private void XMLSerialization(int num)
        {
            model.FileName = View.ReadLine("Enter file name:");
            model.InputPerson = View.PromptForPerson();
            model.XmlFilesHandling();
        }
        private void ZipArchives(int num)
        {
            model.FileName = View.ReadLine("Enter achive name:");
            model.InputString = View.ReadLine("Enter file path.");
            model.ZipFilesHandling();
        }
    }

}

