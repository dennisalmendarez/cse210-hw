using System;

public class Squared : Shape{
    protected double _side;

    public Squared(string color, double side) : base(color){
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}