namespace File_Assistant
{
    public class Controller
    {
        private List<Action<int>> Methods { get; }
        public IView view { get; }
        readonly IModel model;
        public Controller(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
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
                string? command = view.GetCommand();
                if (command == "0")
                {
                    break;
                }
                if (Int32.TryParse(command, out int result) && result > 0 && result <= 5)
                {
                    try
                    {
                        Methods[result - 1].Invoke(result - 1);
                        view.ShowResult("Action executed successfully.");
                    }
                    catch (Exception ex)
                    {
                        view.ShowResult($"An error occurred: {ex.Message}");
                    }
                }
                else
                {
                    view.ShowResult("Invalid command. Please enter a number between 0 and 5.");
                }
            }
        }
        private void FileSystem(int num)
        {
            view.ShowResult(model.FileSystemInfo());
        }
        private void FileStreams(int num)
        {
            model.FileType = ".txt";
            string? command = view.GetFileCommand();
            while (command != "0")
            {
                switch (command)
                {
                    case "1":
                        model.FileName = view.ReadLine("Enter file name:");
                        model.InputString = "";
                        view.ShowResult(model.CreateTextFile());
                        break;
                    case "2":
                        model.FileName = view.ReadLine("Enter file name:");
                        model.InputString = view.ReadLine("Enter file content...");
                        view.ShowResult(model.CreateTextFile());
                        break;
                    case "3":
                        model.FileName = view.ReadLine("Enter file name:");
                        model.InputString = view.ReadLine("Enter file content...");
                        view.ShowResult(model.InsertTextFile());
                        break;
                    case "4":
                        model.FileName = view.ReadLine("Enter file name:");
                        view.ShowResult(model.ReadTextFile());
                        break;
                    case "5":
                        model.FileName = view.ReadLine("Enter file name:");
                        view.ShowResult(model.DeleteFile());
                        break;
                    case "0":
                        break;
                    default:
                        view.ShowResult("Invalid command. Please enter a number between 0 and 5.");
                        break;
                }
                command = view.GetFileCommand();
            }
        }
        private void JSONSerialization(int num)
        {
            model.FileType= ".json";
            string? command = view.GetFileCommand();
            while (command != "0")
            {
                switch (command)
                {
                    case "1":
                        model.FileName = view.ReadLine("Enter file name:");
                        model.InputPerson = new();
                        view.ShowResult(model.CreateJsonFile());
                        break;
                    case "2":
                        model.FileName = view.ReadLine("Enter file name:");
                        model.InputPerson = view.PromptForPerson();
                        view.ShowResult(model.CreateJsonFile());
                        break;
                    case "3":
                        view.ShowResult("This action is not supported for JSON files.");
                        break;
                    case "4":
                        model.FileName = view.ReadLine("Enter file name:");
                        view.ShowPerson(model.ReadJsonFile());
                        break;
                    case "5":
                        model.FileName = view.ReadLine("Enter file name:");
                        view.ShowResult(model.DeleteFile());
                        break;
                    case "0":
                        break;
                    default:
                        view.ShowResult("Invalid command. Please enter a number between 0 and 5.");
                        break;
                }
                command = view.GetFileCommand();
            }
        }
        private void XMLSerialization(int num)
        {
            model.FileType = ".xml";
            string? command = view.GetFileCommand();
            while (command != "0")
            {
                switch (command)
                {
                    case "1":
                        model.FileName = view.ReadLine("Enter file name:");
                        model.InputPerson = new();
                        view.ShowResult(model.CreateXmlFile());
                        break;
                    case "2":
                        model.FileName = view.ReadLine("Enter file name:");
                        model.InputPerson = view.PromptForPerson();
                        view.ShowResult(model.CreateXmlFile());
                        break;
                    case "3":
                        view.ShowResult("This action is not supported for XML files.");
                        break;
                    case "4":
                        model.FileName = view.ReadLine("Enter file name:");
                        view.ShowPerson(model.ReadXmlFile());
                        break;
                    case "5":
                        model.FileName = view.ReadLine("Enter file name:");
                        view.ShowResult(model.DeleteFile());
                        break;
                    case "0":
                        break;
                    default:
                        view.ShowResult("Invalid command. Please enter a number between 0 and 5.");
                        break;
                }
                command = view.GetFileCommand();
            }
        }
        public void ZipArchives(int num)
        {
            model.FileType = ".zip";
            string? command = view.GetFileCommand();
            while (command != "0")
            {
                switch (command)
                {
                    case "1":
                        view.ShowResult("This action is not supported for ZIP files.");
                        break;
                    case "2":
                        model.FileName = view.ReadLine("Enter archive name:");
                        model.InputString = view.ReadLine("Enter file path.").Trim('"');
                        view.ShowResult(model.CreateZipFile());
                        break;
                    case "3":
                        view.ShowResult("This action is not supported for ZIP files.");
                        break;
                    case "4":
                        model.FileName = view.ReadLine("Enter file name:");
                        view.ShowResult(model.CheckZipFile());
                        break;
                    case "5":
                        model.FileName = view.ReadLine("Enter file name:");
                        model.InputString = view.ReadLine("Enter extraction path.").Trim('"');
                        view.ShowResult(model.ExtractZipFile());
                        break;
                    case "0":
                        break;
                    default:
                        view.ShowResult("Invalid command. Please enter a number between 0 and 5.");
                        break;
                }
                command = view.GetFileCommand();
            }
        }
    }

}

