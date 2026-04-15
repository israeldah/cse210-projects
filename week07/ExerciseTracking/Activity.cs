// Base class shared by all activity types
class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected int Minutes => _minutes;

    // Derived classes override these three calculation methods
    public virtual double GetDistance() => 0;
    public virtual double GetSpeed()    => (GetDistance() / _minutes) * 60;
    public virtual double GetPace()     => _minutes / GetDistance();

    public virtual string GetSummary()
    {
        string dateStr = _date.ToString("dd MMM yyyy");
        string type    = GetType().Name;
        return $"{dateStr} {type} ({_minutes} min) - Distance: {GetDistance():0.0} miles, " +
               $"Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
