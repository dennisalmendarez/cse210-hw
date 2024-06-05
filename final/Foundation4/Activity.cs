using System;

public abstract class Activity{

    private string _date;
    private int _lengthInMinutes;

    public Activity(string date, int lengthInMinutes){
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    public virtual double GetDistance(){
        return 0.0;
    }
    public virtual double GetSpeed(){
        return 0.0;
    }
    public virtual double GetPace(){
        return 0.0;
    }
     public string GetSummary()
    {
        return $"{_date} Activity ({_lengthInMinutes} min): Distance {GetDistance():F2} miles, Speed {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }

    protected int GetLengthInMinutes()
    {
        return _lengthInMinutes;
    }

}