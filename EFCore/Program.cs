// See https://aka.ms/new-console-template for more information

using EFCore.data;
using EFCore.Model;

Console.WriteLine("Hello, World!");
bool done = false;

Context? context = null;
while (!done)
{
    if (Console.KeyAvailable)
    {
        string input = Console.ReadLine();
        if (input[0] == 'q')
        {
            done = true;
        }
        else if (input == "new")
        {
            context = new Context();
            context.Facilities.Add(new Facility()
            {
                Fac_ClosestAdr = "at home", 
                Fac_Items = "Some stuff",
                Fac_Name = "My place",
                Fac_Rules = "No rules",
                Fac_Type = "CoolCave"
            });
            await context.SaveChangesAsync();
            Console.WriteLine("Database initialized");
        }
        else if (input == "show")
        {
            if (context != null)
            {
                var f = context.Facilities.FirstOrDefault();
                Console.WriteLine(f.Fac_Name + " " + f.Fac_ClosestAdr + 
                                  "\n" + f.Fac_Items + " " + f.Fac_Rules);
            }
            
        }
    }
}
