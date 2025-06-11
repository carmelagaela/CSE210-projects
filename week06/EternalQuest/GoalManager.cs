class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private HashSet<string> _badges = new HashSet<string>();

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void ShowGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].Name}");
        }
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int earned = _goals[index].RecordEvent();
            _score += earned;
            Console.WriteLine($"You earned {earned} points!");
            CheckForBadges();
        }
    }

    public int GetScore() => _score;

    public int GetLevel() => (_score / 500) + 1;

    // Check for badge achievements
    public void CheckForBadges()
    {
        if (_score >= 1000 && !_badges.Contains("Point Master"))
        {
            _badges.Add("Point Master");
            Console.WriteLine("🏅 Badge unlocked: Point Master!");
        }

        if (_goals.Count(g => g.IsComplete()) >= 5 && !_badges.Contains("Finisher"))
        {
            _badges.Add("Finisher");
            Console.WriteLine("🏅 Badge unlocked: Finisher!");
        }

        if (_goals.Any(g => g is ChecklistGoal cg && cg.IsComplete()) && !_badges.Contains("Checklist Champ"))
        {
            _badges.Add("Checklist Champ");
            Console.WriteLine("🏅 Badge unlocked: Checklist Champ!");
        }
    }

    public void ShowBadges()
    {
        Console.WriteLine("\n🎖️ Badges:");
        if (_badges.Count == 0)
            Console.WriteLine("(None yet)");
        foreach (string b in _badges)
            Console.WriteLine(" - " + b);
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(string.Join(",", _badges));
            foreach (Goal g in _goals)
                writer.WriteLine(g.Serialize());
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename)) return;

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _badges = new HashSet<string>(lines[1].Split(',', StringSplitOptions.RemoveEmptyEntries));

        _goals.Clear();
        for (int i = 2; i < lines.Length; i++)
            _goals.Add(ParseGoal(lines[i]));
    }

    private Goal ParseGoal(string line)
    {
        string[] parts = line.Split("|");
        switch (parts[0])
        {
            case "SimpleGoal": return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "EternalGoal": return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            case "ChecklistGoal": return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
            default: throw new Exception("Unknown goal type");
        }
    }
}