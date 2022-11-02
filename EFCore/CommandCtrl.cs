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
    public void SetDummyData()
    {
        Facility f1 = new Facility()
        {
            FacClosestAdr = "Hans Hansen Street 22",
            FacType = "Playground",
            FacItems = "Bench",
            FacName = "The fun playground",
            FacRules = "No fire"
        };
        Facility f2 = new Facility()
        {
            FacClosestAdr = "Jens Jensen Street 33",
            FacType = "Shelter",
            FacItems = "Fire pit",
            FacName = "Shelter by Aarhus",
            FacRules = "Only one overnight stay"
        };
        Facility f3 = new Facility()
        {
            FacClosestAdr = "Main Street 44",
            FacType = "Playground",
            FacItems = "Toilets",
            FacName = "The playground at Main Street",
            FacRules = "No fire"
        };
        Facility f4 = new Facility()
        {
            FacClosestAdr = "Jens Juuls Street 55",
            FacType = "Tennis court",
            FacItems = "Balls",
            FacName = "The land of tennis",
            FacRules = "No food"
        };
        _facilityController.Add(f1);
        _facilityController.Add(f2);
        _facilityController.Add(f3);
        _facilityController.Add(f4);

        User u1 = new User()
        {
            CPRNumber = 1111200011,
            Email = "simon@live.com",
            Name = "Simon",
            PhoneNumber = 22334455,
            CVR = 1234
        };
        User u2 = new User()
        {
            CPRNumber = 2202952020,
            Email = "sara@live.com",
            Name = "Sara",
            PhoneNumber = 21233435,
            CVR = 5678
        };
        User u3 = new User()
        {
            CPRNumber = 2010900135,
            Email = "rasmus@live.com",
            Name = "Rasmus",
            PhoneNumber = 92384961,
            CVR = 9012
        };
        _userController.Add(u1);
        _userController.Add(u2);
        _userController.Add(u3);

        Reservation r1 = new Reservation()
        {
            Start = new DateTime(2022, 2, 7, 12, 00, 00),
            End = new DateTime(2022, 2, 7, 14, 00, 00),
            User = u1,
            Facility = f1
        };
        Reservation r2 = new Reservation()
        {
            Start = new DateTime(2022, 4, 5, 10, 30, 00),
            End = new DateTime(2022, 4, 5, 12, 15, 00),
            User = u3,
            Facility = f4
        };
        _reservationController.Add(r1);
        _reservationController.Add(r2);

    }
}