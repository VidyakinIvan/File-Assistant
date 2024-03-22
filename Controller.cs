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
            model.FileType = ".txt";
            string? command = View.GetFileCommand();
            while (command != "0")
            {
                switch (command)
                {
                    case "1":
                        model.FileName = View.ReadLine("Enter file name:");
                        model.InputString = "";
                        View.ShowResult(model.CreateTextFile());
                        break;
                    case "2":
                        model.FileName = View.ReadLine("Enter file name:");
                        model.InputString = View.ReadLine("Enter file content...");
                        View.ShowResult(model.CreateTextFile());
                        break;
                    case "3":
                        model.FileName = View.ReadLine("Enter file name:");
                        model.InputString = View.ReadLine("Enter file content...");
                        View.ShowResult(model.InsertTextFile());
                        break;
                    case "4":
                        model.FileName = View.ReadLine("Enter file name:");
                        View.ShowResult(model.ReadTextFile());
                        break;
                    case "5":
                        model.FileName = View.ReadLine("Enter file name:");
                        View.ShowResult(model.DeleteFile());
                        break;
                    case "0":
                        break;
                    default:
                        View.ShowResult("Invalid command. Please enter a number between 0 and 5.");
                        break;
                }
                command = View.GetFileCommand();
            }
        }
        private void JSONSerialization(int num)
        {
            model.FileType= ".json";
            string? command = View.GetFileCommand();
            while (command != "0")
            {
                switch (command)
                {
                    case "1":
                        model.FileName = View.ReadLine("Enter file name:");
                        model.InputPerson = new();
                        View.ShowResult(model.CreateJsonFile());
                        break;
                    case "2":
                        model.FileName = View.ReadLine("Enter file name:");
                        model.InputPerson = View.PromptForPerson();
                        View.ShowResult(model.CreateJsonFile());
                        break;
                    case "3":
                        View.ShowResult("This action is not supported for JSON files.");
                        break;
                    case "4":
                        model.FileName = View.ReadLine("Enter file name:");
                        View.ShowPerson(model.ReadJsonFile());
                        break;
                    case "5":
                        model.FileName = View.ReadLine("Enter file name:");
                        View.ShowResult(model.DeleteFile());
                        break;
                    case "0":
                        break;
                    default:
                        View.ShowResult("Invalid command. Please enter a number between 0 and 5.");
                        break;
                }
                command = View.GetFileCommand();
            }
        }
        private void XMLSerialization(int num)
        {
            model.FileType = ".xml";
            string? command = View.GetFileCommand();
            while (command != "0")
            {
                switch (command)
                {
                    case "1":
                        model.FileName = View.ReadLine("Enter file name:");
                        model.InputPerson = new();
                        View.ShowResult(model.CreateXmlFile());
                        break;
                    case "2":
                        model.FileName = View.ReadLine("Enter file name:");
                        model.InputPerson = View.PromptForPerson();
                        View.ShowResult(model.CreateXmlFile());
                        break;
                    case "3":
                        View.ShowResult("This action is not supported for XML files.");
                        break;
                    case "4":
                        model.FileName = View.ReadLine("Enter file name:");
                        View.ShowPerson(model.ReadXmlFile());
                        break;
                    case "5":
                        model.FileName = View.ReadLine("Enter file name:");
                        View.ShowResult(model.DeleteFile());
                        break;
                    case "0":
                        break;
                    default:
                        View.ShowResult("Invalid command. Please enter a number between 0 and 5.");
                        break;
                }
                command = View.GetFileCommand();
            }
        }
        public void ZipArchives(int num)
        {
            model.FileType = ".zip";
            string? command = View.GetFileCommand();
            while (command != "0")
            {
                switch (command)
                {
                    case "1":
                        View.ShowResult("This action is not supported for ZIP files.");
                        break;
                    case "2":
                        model.FileName = View.ReadLine("Enter archive name:");
                        model.InputString = View.ReadLine("Enter file path.").Trim('"');
                        View.ShowResult(model.CreateZipFile());
                        break;
                    case "3":
                        View.ShowResult("This action is not supported for ZIP files.");
                        break;
                    case "4":
                        model.FileName = View.ReadLine("Enter file name:");
                        View.ShowResult(model.CheckZipFile());
                        break;
                    case "5":
                        model.FileName = View.ReadLine("Enter file name:");
                        model.InputString = View.ReadLine("Enter extraction path.").Trim('"');
                        View.ShowResult(model.ExtractZipFile());
                        break;
                    case "0":
                        break;
                    default:
                        View.ShowResult("Invalid command. Please enter a number between 0 and 5.");
                        break;
                }
                command = View.GetFileCommand();
            }
        }
        //private void ZipArchives(int num)
        //{
        //    model.FileName = View.ReadLine("Enter achive name:");
        //    model.InputString = View.ReadLine("Enter file path.");
        //    model.ZipFilesHandling();
        //}
    }

}

