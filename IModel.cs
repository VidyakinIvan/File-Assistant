namespace File_Assistant
{
    public interface IModel
    {
        public string InputString { get; set; }
        public Person InputPerson { get; set; }
        public string FileName { get; set; }
        public string FileSystemInfo();
        public string CreateTextFile();
        public string InsertTextFile();
        public string DeleteTextFile();
        public void JsonFilesHandling();
        public void XmlFilesHandling();
        public void ZipFilesHandling();
    }
}