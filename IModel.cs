namespace File_Assistant
{
    public interface IModel
    {
        public string? InputString { protected get; set; }
        public Person? InputPerson { get; set; }
        public string? FileName { get; set; }
        public string FileSystemInfo();
        public void TextFilesHandling();
        public void JsonFilesHandling();
        public void XmlFilesHandling();
        public void ZipFilesHandling();
    }
}