using System;
using System.Collections.Generic;

namespace Logic
{
    public class Notebook
    {
        private List<Unit> units = new List<Unit>();

        public Unit[] ListUnits()
        {
            return units.ToArray();
        }

        public void AddUnit(Unit unit)
        {
            units.Add(unit);
        }

        public void RemoveUnit(Unit unit)
        {
            units.Remove(unit);
        }
    }
}