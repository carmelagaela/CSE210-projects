using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public string Name
    {
        get { return _name; }
    }

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent(); // Each goal defines how points are recorded
    public abstract bool IsComplete();
    public abstract string GetStatus();
    public abstract string Serialize(); // For saving
}