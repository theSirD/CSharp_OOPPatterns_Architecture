using System;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Targets;
using Itmo.ObjectOrientedProgramming.Lab3.Targets.Display;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class DisplayAddressee : BaseAddressee
{
    public DisplayAddressee(ConfidentialityLevels confLevelAccess)
        : base(confLevelAccess) { }
    public override void Send(IRecieve target)
    {
        if (target is null)
            throw new ArgumentException("Specified user is null");
        if (target is not Display)
            throw new ArgumentException("Only target for this addressee is Display");
        if (CurrentMessage is null)
            throw new ArgumentException("Addressee does not contain a message");
        target.RecieveMessage(CurrentMessage);
    }
}