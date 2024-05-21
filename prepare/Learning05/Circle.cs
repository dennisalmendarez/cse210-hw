using System;

public class Circle : Shape {
    protected double _radius;

    public Circle(string color, double radius) : base (color){
        _radius = radius;
    }

    public override double GetArea(){
        return _radius * _radius * Math.PI;
    }
}