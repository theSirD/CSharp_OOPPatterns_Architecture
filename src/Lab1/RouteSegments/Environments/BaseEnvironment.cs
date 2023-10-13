using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environments;

public abstract class BaseEnvironment
{
    private readonly bool[] _isObstacleAllowed = new bool[] { false, false, false, false };

    protected BaseEnvironment(IList<int>? obstacles)
    {
        ObstaclesList = obstacles;
    }

    private IList<int>? ObstaclesList { get; set; }

    protected bool ValidateObstacles()
    {
        if (ObstaclesList is null) return false;

        for (int i = 0; i < _isObstacleAllowed.Length; i++)
        {
            if (!_isObstacleAllowed[i] && ObstaclesList[i] != 0) return false;

            if (ObstaclesList[i] < 0) return false;
        }

        return true;
    }
}