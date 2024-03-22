namespace File_Assistant
{
    internal class View: IView
    {
        public string? GetCommand() 
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
            return command;
        }
        public Person PromptForPerson()
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
        public void ShowPerson(Person? restoredPerson)
        {
            if (restoredPerson is not null)
            { 
                Console.WriteLine(@$"Object was deserialized.
                        Firstname: {restoredPerson.Firstname}
                        Lastname: {restoredPerson.Lastname}
                        Age: {restoredPerson.Age}
                        Country: {restoredPerson.Country}
                        City: {restoredPerson.City}.");
            }
            else
            {
                Console.WriteLine("The object was not deserialized.");
            }
        }
        public void ShowResult(string message)
        {
            Console.WriteLine(message);
        }
        public string ReadLine(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine() ?? "The text was not entered";
        }
        public string? GetFileCommand()
        {
            Console.WriteLine(@"Please, choose required file action.
                        1 - Create empty file.
                        2 - Create file with data.
                        3 - Insert data in existing file.
                        4 - Read file.
                        5 - Delete file.
                        0 - Exit.");
            string? command = Console.ReadLine();
            return command;
        }
    }
}
