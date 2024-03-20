namespace File_Assistant
{
    internal class View
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
        public void ShowResult(string message)
        {
            Console.WriteLine(message);
        }
        public string? ReadLine(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
