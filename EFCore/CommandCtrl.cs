using EFCore.DbController;
using EFCore.Model;
using EFCore.UI;

namespace EFCore;

public class CommandCtrl
{
    private Ui _ui;
    private FacilityController _facilityController;

    public CommandCtrl(Ui ui, FacilityController fctrl)
    {
        _ui = ui;
        _facilityController = fctrl;
    }
    public void UserEnterFacility()
    {
        Facility f = new Facility();
        f.Fac_Name = _ui.GetLine("Enter name:");
        f.Fac_ClosestAdr = _ui.GetLine("Enter address:");
        _facilityController.Add(f);
        _ui.Display("Command succesful\n");
    }

    public void UserListFacilities()
    {
        List<Facility> facilities = _facilityController.GetAll();
        foreach (Facility f in facilities)
        {
            _ui.Display(f.Fac_Name + " " + f.Fac_ClosestAdr + "\n");
        }
    }

  

}