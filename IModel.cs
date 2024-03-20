namespace File_Assistant
{
    public interface IModel
    {
        public string InputString { get; set; }
        public Person InputPerson { get; set; }
        public string FileName { get; set; }
        public string FileSystemInfo();
        //public void TextFilesHandling();
        public string CreateTextFile();
        public void JsonFilesHandling();
        public void XmlFilesHandling();
        public void ZipFilesHandling();
    }
}