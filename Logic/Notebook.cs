using System;
using System.Collections.Generic;
using System.Linq;

public class NoteBook
{
    private List<Unit> units = new List<Unit>();

    public List<Unit> ListUnits()
    {
        return new List<Unit>(units);
    }

    public void AddUnit(Unit unit)
    {
        if (units.Any(u => u.Name == unit.Name))
            throw new Exception("Ce nom existe deja");
        units.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        units.Remove(unit);
    }
}