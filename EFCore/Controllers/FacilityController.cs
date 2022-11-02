using EFCore.data;
using EFCore.Model;

namespace EFCore.DbController;

public class FacilityController : IController<Facility>
{
    private readonly Context _context;

    public FacilityController(Context context)
    {
        _context = context;
    }

    public Facility Get(long id)
    {
        throw new NotImplementedException();
    }

    public List<Facility> GetAll()
    {
        List<Facility> facilities = _context.Facilities.ToList();
        return facilities;
    }

    public bool Add(Facility facility)
    {
        try
        {
            _context.Facilities.Add(facility);
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