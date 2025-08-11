using System;

abstract class Activity
{
    private DateTime _date;
    private double _lengthMinutes;

    public Activity(DateTime date, double lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public DateTime Date => _date;
    public double LengthMinutes => _lengthMinutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {this.GetType().Name} ({LengthMinutes} min): " +
               $"Distance {GetDistance():F1}, Speed {GetSpeed():F1}, Pace: {GetPace():F2} min per unit";
    }
}
