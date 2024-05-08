using System;


public class Fraction
{
    private int _Top;
    private int _Bottom;

    
    public Fraction(){
        _Top = 1;
        _Bottom = 1;
    }

    public Fraction(int wholeNumber){
        _Top = wholeNumber;
        _Bottom = 1;
    }



    public Fraction(int Top, int Bottom){
        _Top = Top;
        _Bottom = Bottom;
    }

    public string GetFractionString(){
        string text = $"{_Top}/{_Bottom}";
        return text;
    }

    public double GetDecimalValue(){
        return (double)_Top / (double)_Bottom; // use double before variable to make decimals.
    }
}