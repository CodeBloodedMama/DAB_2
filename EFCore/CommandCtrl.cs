using EFCore.Controllers;
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
        f.FacName = _ui.GetLine("Enter name:");
        f.FacClosestAdr = _ui.GetLine("Enter address:");
        _facilityController.Add(f);
        _ui.Display("Command succesful\n");
    }

}