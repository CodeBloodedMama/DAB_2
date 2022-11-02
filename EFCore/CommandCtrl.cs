using EFCore.Controllers;
using EFCore.data;
using EFCore.Model;
using EFCore.UI;
using Microsoft.EntityFrameworkCore;

namespace EFCore;

public class CommandCtrl
{
    private Ui _ui;
    private FacilityController _facilityController;
    private Context _context;

    public CommandCtrl(Ui ui, FacilityController fctrl, Context context)
    {
        _ui = ui;
        _facilityController = fctrl;
        _context = context;
    }
    public void UserEnterFacility()
    {
        Facility f = new Facility();
        f.FacName = _ui.GetLine("Enter name:");
        f.FacClosestAdr = _ui.GetLine("Enter address:");
        _facilityController.Add(f);
        _ui.Display("Command succesful\n");
    }

    public void GetReservations()
    {
        List<Reservation> reservations = _context.Reservations.ToList();
      
        foreach (var r in reservations)
        {
            _context.Entry(r).Reference(res => res.Facility).Load();
            _context.Entry(r).Reference(res => res.User).Load();

            string formatted = "";
    
            string line = "";
            line += "Fac Name: " + r.Facility.FacName;
            while (line.Length < 20) {
                    line += ' ';
            } 
            line += "Username: " + r.User.Name;
            while (line.Length < 50)
            { 
                line += ' ';
            }
            line += "Time start: " + r.Start + " end: " + r.End;
            formatted += line + "\n";
            
            _ui.Display(formatted);
        }

    }


    public void GetFacilitiesOrderByKind()
    {
        List<Facility> facilities = _context.Facilities.
            OrderBy(f => f.FacType)
            .ToList();
        string formatted = "";
        foreach (Facility f in facilities)
        {
            string line = "";
            line += "Kind: " + f.FacType;
            while (line.Length < 20)
            {
                line += ' ';
            }
            line += "Name: " + f.FacName;
            while (line.Length < 50)
            { 
                line += ' ';
            }
            line += "C. Address: " + f.FacClosestAdr;
            formatted += line + "\n";
        }
        _ui.Display(formatted);
    }

    
}