using System.ComponentModel.DataAnnotations;
using EFCore.data;
using EFCore.UI;
using Microsoft.EntityFrameworkCore;

namespace EFCore;

public class AppController
{
    private Ui _ui = new();
    private Context _context;
    private bool _running = false;

    public AppController()
    {
        _context = new Context();
    }

    public int Run()
    {
        _ui.Display("Welcome to FacilityDbManager\n" +
                    "Enter 'h' for help\n");
        _running = true;
        while (_running)
        {
            try
            {
                string command = _ui.GetCommand();
                HandleCommand(command);
            }
            catch (Exception e)
            {
                _ui.Display(e.Message + "\n");
            }
        }

        return 0;
    }

    // Command handler
    private void HandleCommand(string command)
    {
        switch (command)
        {
            case "h":
            case "help":
            {
                _ui.DisplayHelp();
                break;
            }
            case "q":
            case "quit":
            {
                _ui.Display("Exiting application\n");
                _running = false;
                break;
            }
            case "a":
            case "add":
            {
                throw new NotImplementedException();
            }
            case "g":
            case "get":
            {
                throw new NotImplementedException();
            }
            case "s":
            case "show":
            {
                throw new NotImplementedException();
            }
            default:
                _ui.Display("Unrecognized command\n");
                break;
        }
    }
}