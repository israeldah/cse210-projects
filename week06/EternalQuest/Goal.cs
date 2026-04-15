// Abstract base class for all goal types
abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string ShortName => _shortName;

    // Records the event and returns the points earned (can be negative for NegativeGoal)
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    // Returns a formatted display string showing completion status
    public abstract string GetDisplayString();

    // Returns a string used for saving to file (type:field1,field2,...)
    public abstract string GetStringRepresentation();
}
