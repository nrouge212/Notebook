using System;

public class Exam
{
    private string teacher;
    private DateTime date;
    private float coef;
    private float note;
    private bool isAbsent;

    public string Teacher
    {
        get => teacher;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Le prof ne peut pas etre vide");
            teacher = value;
        }
    }

    public DateTime Date
    {
        get => date;
        set => date = value;
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

    public bool IsAbsent
    {
        get => isAbsent;
        set
        {
            isAbsent = value;
            if (isAbsent) note = 0;
        }
    }

    public float Note
    {
        get => note;
        set
        {
            if (value < 0 || value > 20)
                throw new Exception("La note doit être comprise entre 0 et 20");

            if (IsAbsent)
                note = 0;
            else
                note = value;
        }
    }
}