namespace File_Assistant
{
    public interface IModel
    {
        public string InputString { get; set; }
        public Person InputPerson { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string FileSystemInfo();
        public string CreateTextFile();
        public string InsertTextFile();
        public string ReadTextFile();
        public string DeleteFile();
        public string CreateJsonFile();
        public string ReadJsonFile();
        public string CreateXmlFile();
        public string ReadXmlFile();
        public void ZipFilesHandling();
    }
}