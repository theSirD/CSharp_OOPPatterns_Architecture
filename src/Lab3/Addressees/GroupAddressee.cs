using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class GroupAddressee : BaseAddressee
{
    private List<BaseAddressee> _addresseesList;

    public GroupAddressee(ConfidentialityLevels confLevelAccess)
        : base(confLevelAccess)
    {
        _addresseesList = new();
    }

    public void AddNewAddressee(BaseAddressee addressee) => _addresseesList.Add(addressee);

    public override void Send()
    {
        if (CurrentMessage is null)
            throw new ArgumentException("Addressee does not contain a message");

        bool anyAddresseeHasNoRightToReadMessage = _addresseesList.Any(
            addressee => CurrentMessage.ConfidentialityLevel > addressee.ConfidentialityLevelAccess);

        if (!anyAddresseeHasNoRightToReadMessage)
        {
            foreach (BaseAddressee addressee in _addresseesList)
            {
                addressee.Send();
            }
        }
        else
        {
            throw new ArgumentException("One of given addresses does not have a right to read this message");
        }
    }
}