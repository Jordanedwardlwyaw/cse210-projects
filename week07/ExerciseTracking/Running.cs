class Running : Activity
{
    private double _distance;  // miles or km

    public Running(DateTime date, double lengthMinutes, double distance)
        : base(date, lengthMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (_distance / LengthMinutes) * 60;

    public override double GetPace() => LengthMinutes / _distance;
}
