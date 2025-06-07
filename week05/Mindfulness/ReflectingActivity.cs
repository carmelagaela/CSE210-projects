class ReflectingActivity : Activity
{
    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private string _prompt = "Think of a time when you helped someone in need.\nThink of a time when you did something truly selfless.";

    public ReflectingActivity() 
        : base("Reflecting Activity", "This activity helps you reflect on times you've been selfless or helped others.") { }

    public override void Run()
    {
        DisplayStartMessage();
        int duration = GetDurationFromUser();

        Console.WriteLine($"\n{_prompt}\n");
        Console.WriteLine("Reflect on the following questions:\n");

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        Random rand = new Random();

        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine(question);
            Spinner(5); // Pause for reflection
            Console.WriteLine();
        }

        DisplayEndMessage();
    }
}