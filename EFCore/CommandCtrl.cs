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
    private ReservationController _reservationController;
    private UserController _userController;
    private Context _context;

    public CommandCtrl(Ui ui)
    {
        _ui = ui;
        _context = new Context();
        _facilityController = new FacilityController(_context);
        _reservationController = new ReservationController(_context);
        _userController = new UserController(_context);
    }
    public void UserEnterFacility()
    {
        Facility f = new Facility();
        f.FacName = _ui.GetLine("Enter name:");
        f.FacClosestAdr = _ui.GetLine("Enter address:");
        _facilityController.Add(f);
        _ui.Display("Command succesful\n");
    }


    public void GetAllFacilitiesWAddress()
    {
        var facilities = _context.Facilities.ToList();
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

    private bool ContextContainsData()
    {
        var f = _context.Facilities.FirstOrDefault();
        var r = _context.Reservations.FirstOrDefault();
        var u = _context.Users.FirstOrDefault();
        if (f != null || r != null || u != null)
        {
            return true;
        }

        return false;
    }

    // Useful for testing
    public void DeleteAllData()
    {
        var f = _facilityController.GetAll();
        var r = _reservationController.GetAll();
        var u = _userController.GetAll();
        foreach (var facility in f)
        {
            _facilityController.Delete(facility.Id);
        }
        foreach (var reservation in r)
        {
            _reservationController.Delete(reservation.Id);
        }
        foreach (var user in u)
        {
            _userController.Delete(user.CPRNumber);
        }
    }
}