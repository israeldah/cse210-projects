class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    // 50 meters per lap → km → miles
    public override double GetDistance() => _laps * 50.0 / 1000 * 0.62;
}
