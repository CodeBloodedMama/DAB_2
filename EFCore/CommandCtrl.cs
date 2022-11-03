using System.Security.Cryptography;
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
        if (!ContextContainsData())
        {
            SeedDummyData();
        }
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

            line += "Lat: " + f.GPS_lat;
            line += "Lon: " + f.GPS_lon;
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
            line += "Lat: " + f.GPS_lat;
            line += "Lon: " + f.GPS_lon;
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

    public void SeedDummyData()
    {
        Facility f1 = new Facility()
        {
            GPS_lat = 20.01,
            GPS_lon = 50.31,
            FacType = "Playground",
            FacItems = "Bench",
            FacName = "The fun playground",
            FacRules = "No fire",
        };

        Facility f2 = new Facility()
        {
            GPS_lat = 50.01,
            GPS_lon = 121.3123,
            FacType = "Shelter",
            FacItems = "Fire pit",
            FacName = "Shelter by Aarhus",
            FacRules = "Only one overnight stay"
        };
        Facility f3 = new Facility()
        {
            GPS_lat = 42.02,
            GPS_lon = 55.451,
            FacType = "Playground",
            FacItems = "Toilets",
            FacName = "The playground at Main Street",
            FacRules = "No fire"
        };
        Facility f4 = new Facility()
        {
            GPS_lat = 68.0131,
            GPS_lon = 13.2314,
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
            Facility = f1,
            Participants = new List<Participant>()
            {
                new Participant(){CPRNumber = 1941491231}
            }
        };

        var p1 = _context.Participants.Find((long)1941491231);
        var par = new List<Participant>()
        {
            new Participant() { CPRNumber = 2020200222 },
            new Participant() { CPRNumber = 3004894242 }
        };
        if (p1 != null)
        {
            par.Add(p1);
        }
        Reservation r2 = new Reservation()
        {
            Start = new DateTime(2022, 4, 5, 10, 30, 00),
            End = new DateTime(2022, 4, 5, 12, 15, 00),
            User = u3,
            Facility = f4,
            Participants = par
        };
        _reservationController.Add(r1);
        _reservationController.Add(r2);
        BusinessUser b1 = new BusinessUser()
        {
            CPRNumber = 1234567890,
            Email = "Jysk@jysk.dk",
            PhoneNumber = 12345678,
            BusinessCVR = 12345678,
            Name = "Jysk Sengetøjslager",
        };
        BusinessUser b2 = new BusinessUser()
        {
            CPRNumber = 98765432,
            Email = "McD@mcd.dk",
            PhoneNumber = 12345678,
            BusinessCVR = 12345678,
            Name = "MaCDonalds",
        };
        
        
        BusinessUser b3 = new BusinessUser()
        {
            CPRNumber = 75645279,
            Email = "Harald Nyborg@hn.dk",
            PhoneNumber = 12345678,
            BusinessCVR = 12345678,
            Name = "Harald Nyborg",
        };
        _userController.Add(b1);
        _userController.Add(b2);
        _userController.Add(b3);

        MaintenanceIntervention m1 = new MaintenanceIntervention()
        {
            Facility = f1,
            StartDate = new DateTime(2020, 4, 10),
            TechnicianName = "Thomas Wayne"
        };

        _context.MaintenanceInterventions.Add(m1);
        _context.SaveChanges();
    }
}