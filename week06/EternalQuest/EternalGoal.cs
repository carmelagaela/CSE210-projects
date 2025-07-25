class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => _points;

    public override bool IsComplete() => false;

    public override string GetStatus() => "[∞]";

    public override string Serialize() => $"EternalGoal|{_name}|{_description}|{_points}";
}