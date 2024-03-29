using System;
using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Targets;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public abstract class BaseAddressee
{
    private readonly ILogger _logger;
    private Message? _currentMessage;
    protected BaseAddressee(ConfidentialityLevels confLevelAccess, ILogger logger)
    {
        ConfidentialityLevelAccess = confLevelAccess;
        _logger = logger;
    }

    public Message? CurrentMessage
    {
        get
        {
            return _currentMessage;
        }
        set
        {
            if (value is null)
                throw new ArgumentException("Message you've tried to pass to addressee is null");
            if (value.ConfidentialityLevel > ConfidentialityLevelAccess)
            {
                _logger.LogOneMessage("This addressee does not have right to read this message");
            }
            else
            {
                _currentMessage = value;
                _logger.LogOneMessage("Addressee with got a message");
            }
        }
    }

    public ConfidentialityLevels ConfidentialityLevelAccess { get; private set; }

    protected IRecieve? Target { get; set; }

    public abstract void Send();
}