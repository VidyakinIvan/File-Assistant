namespace File_Assistant
{
    [Serializable]
    public class Person
    {
        public string Firstname
        {
            get;
            init;
        }
        public string Lastname
        {
            get;
            init;
        }
        public int? Age
        {
            get; init;
        }
        public string Country
        {
            get;
            init;
        }
        public string City
        {
            get;
            init;
        }
        public Person()
        {
            this.Firstname = "Undefined";
            this.Lastname = "Undefined";
            this.Age = 0;
            this.Country = "Undefined";
            this.City = "Undefined";

        }
        public Person(string firstname, string lastname, int age, string country, string city)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Age = age;
            this.Country = country;
            this.City = city;
        }
    }
}
