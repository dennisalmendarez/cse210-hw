using System;
using System.Diagnostics;

public class Swimming : Activity{
    
    private int _laps;
    private const double LapLengthInMiles = 0.0311; // 50/1000

    public Swimming(string date, int lengthInMinutes, int laps) : base(date, lengthInMinutes){

        _laps = laps;
    }

    public override double GetDistance(){
        return _laps * LapLengthInMiles;
    }
    public override double GetSpeed(){
        return GetDistance() / (GetLengthInMinutes() / 60.0);
    }
    public override double GetPace(){
        return GetLengthInMinutes() / GetDistance();
    }

}