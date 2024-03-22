using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;


namespace File_Assistant
{
    internal class Model : IModel
    {
        private Person person = new();
        public Person InputPerson
        {
            get
            {
                return person;
            }
            set
            {
                if (value is not null)
                {
                    person = value;
                }
            }
        }
        private string inputString = "";
        public string InputString
        {
            get
            {
                return inputString;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    inputString = value;
                }
            }
        }
        private string fileType = ".txt";
        public string FileType
        {
            get
            {
                return fileType;
            }
            set
            {
                if (value is not null && (value == ".txt" || value == ".json" || value == ".xml"))
                {
                    fileType = value;
                }
            }
        }
        private string fileName = "Undefined.txt";
        public string FileName 
        { 
            get
            {
                return fileName;
            }
            set
            {
                fileName = validateFileName(value, FileType);
            }
        }

        public string FileSystemInfo()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            StringBuilder stringBuilder = new();
            foreach (DriveInfo drive in drives)
            {
                stringBuilder.AppendLine($"Name: {drive.Name}");
                stringBuilder.AppendLine($"\tType: {drive.DriveType}");
                if (drive.IsReady)
                {
                    stringBuilder.AppendLine($"\tDisk space: {drive.TotalSize}B");
                    stringBuilder.AppendLine($"\tFree space: {drive.TotalFreeSpace}B");
                    stringBuilder.AppendLine($"\tLabel: {drive.VolumeLabel}");
                    stringBuilder.AppendLine($"\tFormat: {drive.DriveFormat}");
                }
            }
            return stringBuilder.ToString();
        }
        public string CreateTextFile()
        {
            using FileStream file = new(FileName, FileMode.Create, FileAccess.Write);
            byte[] array = Encoding.UTF8.GetBytes(InputString);
            file.Write(array, 0, array.Length);
            return "File was created";
        }
        public string InsertTextFile()
        {
            using FileStream file = new(FileName, FileMode.Append, FileAccess.Write);
            byte[] array = Encoding.UTF8.GetBytes(InputString);
            file.Write(array, 0, array.Length);
            return "Data was inserted";
        }
        public string ReadTextFile()
        {
            using FileStream file = new(FileName, FileMode.Open, FileAccess.Read);
            byte[] array = new byte[file.Length];
            file.Read(array, 0, array.Length);
            return Encoding.UTF8.GetString(array);
        }
        public string DeleteFile()
        {
            FileInfo fileInfo = new(FileName);
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                return "File was deleted.";
            }
            return "File doesn't exist.";
        }
        public string CreateJsonFile()
        {
            using FileStream file = new(FileName, FileMode.Create, FileAccess.Write);
            byte[] array = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(InputPerson));
            file.Write(array, 0, array.Length);
            return "File was created";
        }

        public string ReadJsonFile()
        {
            try
            {
                using FileStream file = new(FileName, FileMode.Open, FileAccess.Read);
                byte[] array = new byte[file.Length];
                file.Read(array, 0, array.Length);
                var person = JsonSerializer.Deserialize<Person>(array);
                return person?.ToString() ?? "No data found";
            }
            catch (FileNotFoundException)
            {
                return "File doesn't exist.";
            }
            catch (JsonException)
            {
                return "The file contains an incorrect structure of JSON...";
            }
        }
        public void JsonFilesHandling()
        {
            string? fileName = FileNameInput("Third.json");
            using (FileStream file = new(fileName, FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.Serialize(file, InputPerson);
                Console.WriteLine("Object was serialized. Press any button...");
            }
            Console.ReadKey();
            try
            {
                using FileStream file = new(fileName, FileMode.Open, FileAccess.Read);
                Person? restoredPerson = JsonSerializer.Deserialize<Person>(file) ?? throw new Exception();
                Console.WriteLine(@$"Object was deserialized.
                        Firstname: {restoredPerson.Firstname}
                        Lastname: {restoredPerson.Lastname}
                        Age: {restoredPerson.Age}
                        Country: {restoredPerson.Country}
                        City: {restoredPerson.City}.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Something went wrong. Possibly, file was deleted or moved.");
            }
            catch (JsonException)
            {
                Console.WriteLine("The file contains an incorrect structure of JSON...");
            }
            finally
            {
                Console.WriteLine("Press any button...");
                Console.ReadKey();
                FileInfo fileInfo = new(fileName);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                    Console.WriteLine("File was deleted.");
                }
            }
        }
        public void XmlFilesHandling()
        {
            FileName = FileNameInput("Fourth.xml");
            XmlSerializer xmlSerializer = new(typeof(Person));
            using (FileStream file = new(FileName, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(file, InputPerson);
                Console.WriteLine("Object was serialized. Press any button...");
            }
            Console.ReadKey();
            try
            {
                using FileStream file = new(FileName, FileMode.Open, FileAccess.Read);
                Person? restoredPerson = xmlSerializer.Deserialize(file) as Person ?? throw new Exception();
                Console.WriteLine(@$"Object was deserialized.
                        Firstname: {restoredPerson.Firstname}
                        Lastname: {restoredPerson.Lastname}
                        Age: {restoredPerson.Age}
                        Country: {restoredPerson.Country}
                        City: {restoredPerson.City}.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Something went wrong. Possibly, file was deleted or moved.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The file contains an incorrect structure of Xml...");
            }
            finally
            {
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                FileInfo fileInfo = new(FileName);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                    Console.WriteLine("File was deleted.");
                }
            }

        }
        public void ZipFilesHandling()
        {
            FileName = FileNameInput("Fifth.zip");
            try
            {
                if (InputString is null)
                {
                    Console.WriteLine("File doesn't exist.");
                    return;
                }
                InputString = InputString.Trim('"');
                FileInfo fileInfo = new(InputString);
                string dirpath = fileInfo.DirectoryName!;
                using (var zipFile = ZipFile.Open(FileName, ZipArchiveMode.Create))
                {
                    zipFile.CreateEntryFromFile(InputString, Path.GetFileName(InputString));
                    fileInfo.Delete();
                    Console.WriteLine("File was packed. Press any button...");
                }
                Console.ReadKey();
                using (ZipArchive archive = ZipFile.OpenRead(FileName))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        Console.WriteLine(@$"Filename: {entry.Name}
                                    Size: {entry.Length}B
                                    Last-modified date: {entry.LastWriteTime}");
                    }
                }
                ZipFile.ExtractToDirectory(FileName, dirpath);
                Console.WriteLine("File was unpacked.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Something went wrong. Possibly, file was deleted or moved.");
            }
            catch (IOException)
            {
                Console.WriteLine("Something went wrong. Possibly, this file already exists.");
            }
            catch (Exception)
            {
                Console.WriteLine("Unknown error.");
            }
            finally
            {
                FileInfo fileinfo = new(FileName);
                if (fileinfo.Exists)
                {
                    fileinfo.Delete();
                }
            }
        }
        protected string FileNameInput(string def)
        {
            string type = def[def.LastIndexOf('.')..];
            if (String.IsNullOrWhiteSpace(FileName))
            {
                FileName = def;
            }
            else if (FileName.Length < type.Length || !FileName[^4..].Equals(type))
            {
                FileName += type;
            }
            return FileName!;
        }
        private string validateFileName(string fileName, string extension)
        {
            if (String.IsNullOrWhiteSpace(fileName))
            {
                return "Undefined"+extension;
            }
            if (fileName.Length < extension.Length || !fileName[^extension.Length..].Equals(extension))
            {
                return fileName + extension;
            }
            return fileName;
        }
    }
}
