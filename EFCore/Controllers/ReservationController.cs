using EFCore.data;
using EFCore.Model;


namespace EFCore.DbController;

public class ReservationController : IController<Reservation>
{
    private readonly Context _context;

    public ReservationController(Context context)
    {
        _context = context;
    }

    public Reservation Get(long id)
    {
        throw new NotImplementedException();
    }

    public List<Reservation> GetAll()
    {
        List<Reservation> reservations = _context.Reservations.ToList();
        return reservations;
    }

    public bool Add(Reservation reservation)
    {
        try
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        return true;
    }

    public bool Delete(long id)
    {
        throw new NotImplementedException();
    }
}
