class Cycling : Activity
{
    private double _speed;  // mph or kph

    public Cycling(DateTime date, double lengthMinutes, double speed)
        : base(date, lengthMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => _speed * (LengthMinutes / 60);

    public override double GetSpeed() => _speed;

    public override double GetPace() => 60 / _speed;
}
