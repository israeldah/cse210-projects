// Exceeds requirements: NegativeGoal — tracks bad habits to break.
// Recording this goal deducts points from the score as a penalty.
class NegativeGoal : Goal
{
    public NegativeGoal(string shortName, string description, int penalty)
        : base(shortName, description, penalty) { }

    // Returns a negative value so the manager deducts it from the score
    public override int RecordEvent() => -_points;

    public override bool IsComplete() => false;

    public override string GetDisplayString()
    {
        return $"[!] {_shortName} ({_description}) -- Penalty: -{_points} pts each time";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{_points}";
    }
}
