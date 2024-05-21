using System;

public class Rectangle : Shape {
    protected double _length;
    protected double _width;

    public Rectangle(string color, double legnth, double width) : base (color){
        _length = legnth;
        _width = width;
    }

    public override double GetArea(){
        return _length = _width;
    }
}