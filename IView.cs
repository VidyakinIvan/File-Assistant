using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Assistant
{
    public interface IView
    {
        public string? GetCommand();
        public Person PromptForPerson();
        public void ShowPerson(Person? restoredPerson);
        public void ShowResult(string message);
        public string ReadLine(string message);
        public string? GetFileCommand();
    }
}
