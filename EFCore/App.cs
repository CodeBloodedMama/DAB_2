using System.ComponentModel.DataAnnotations;
using EFCore.data;
using EFCore.Controllers;
using EFCore.Model;
using EFCore.UI;
using Microsoft.EntityFrameworkCore;

namespace EFCore;

public class App
{
    private Ui _ui = new();
    private Context _context;
    private FacilityController _facilityController;
    private CommandCtrl _commandCtrl;
    private bool _running = false;

    public App()
    {
        _context = new Context();
        _facilityController = new FacilityController(_context);
        _commandCtrl = new CommandCtrl(_ui, _facilityController);
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
                OnAdd();
                break;
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
            case "get all":
            {
                OnGetAll();
                break;
            }
            default:
                _ui.Display("Unrecognized command\n");
                break;
        }
    }


    private void OnAdd()
    {
        string table = _ui.GetTable();
        switch (table)
        {
            case "f":
            case "Facility":
            case "facility":
            {
                _commandCtrl.UserEnterFacility();
                break;
            }
            default:
                _ui.Display("No such table exists!\n");
                break;
        }
    }
    private void OnGetAll()
    {
        string table = _ui.GetTable();
        switch (table)
        {
            case "f":
            case "Facility":
            case "facility":
            {
                DisplayFacilities();
                break;
            }
            default:
                _ui.Display("No such table exists!\n");
                break;
        }
    }


    private void DisplayFacilities()
    {
        var facilities = _facilityController.GetAll();
        string formatted = "";
        foreach (Facility f in facilities)
        {
            string line = "";
            line += "Name: " + f.FacName;
            while (line.Length < 40)
            {
                line += ' ';
            }

            line += "C. Address: " + f.FacClosestAdr;
            formatted += line + "\n";
        }
        _ui.Display(formatted);
    }
}