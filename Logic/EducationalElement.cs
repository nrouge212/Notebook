using System;

public abstract class EducationalElement
{
    private string name;
    private float coef;

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Le nom ne peut pas etre vide");
            name = value;
        }
    }

    public float Coef
    {
        get => coef;
        set
        {
            if (value <= 0)
                throw new Exception("Le coef doit etre >0");
            coef = value;
        }
    }

    public override string ToString()
    {
        return $"{Name} ({Coef})";
    }
}