using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.Model;

namespace EFCore.UI
{
    public class Ui
    {
        public string GetCommand()
        {
            Console.WriteLine("Enter command: ");
            string command = "";
            command += Console.ReadLine();
            return command;
        }

        public void DisplayHelp()
        {
            Display("Available commands: \n");
            Display("[get f] : display all facility names and addresses\n");
            Display("[get f ordered] : display facilities ordered by type\n");
            Display("[get reservations] : display all reservations with facility name, user name and timeslot");
            Display("[q, quit] : quit application\n");
            Display("\nAdditional commands:\n");
            Display("[s, show] : show database tables\n");
            Display("[a, add] : add entry to the database\n");
            Display("[g, get] : get an entry from the database\n");
            Display("[h, help] : show this message\n");
        }

        public void Display(string text)
        {
            Console.Write(text);
        }

        public string GetTable()
        {
            Display("Enter table name: \n");
            string table = Console.ReadLine();
            return table;
        }

        public string GetLine(string text = "")
        {
            Console.WriteLine(text);
            string line = Console.ReadLine();
            return line;
        }
    }
}
