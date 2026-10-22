using System;
using System.Collections.Generic;

namespace Logic
{
    public class Notebook
    {
        private List<Unit> units = new List<Unit>();

        private List<Exam> exams = new List<Exam>();

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

        public Module[] ListModules()
        {
            List<Module> allModules = new List<Module>();
            foreach (Unit u in units)
            {
                allModules.AddRange(u.ListModules());
            }
            return allModules.ToArray();
        }

        public void AddExam(Exam exam)
        {
            exams.Add(exam);
        }

        public Exam[] ListExams()
        {
            return exams.ToArray();
        }

        public AvgScore[] ComputeScores()
        {
            List<AvgScore> allScores = new List<AvgScore>();
            Exam[] allExams = ListExams();

            float generalSum = 0;
            float generalCoef = 0;
            bool hasAnyExam = false;

            foreach (Unit u in units)
            {
                allScores.AddRange(u.ComputeAverages(allExams));

                float unitSum = 0;
                float unitCoef = 0;
                bool unitHasExams = false;

                List<Module> unitModules = new List<Module>(u.ListModules());

                foreach (Exam e in allExams)
                {
                    if (unitModules.Contains(e.Module))
                    {
                        unitSum += e.Note * e.Coef;
                        unitCoef += e.Coef;

                        generalSum += e.Note * e.Coef;
                        generalCoef += e.Coef;

                        unitHasExams = true;
                        hasAnyExam = true;
                    }
                }

                if (unitHasExams && unitCoef > 0)
                {
                    allScores.Add(new AvgScore(unitSum / unitCoef, u));
                }
            }

            if (hasAnyExam && generalCoef > 0)
            {
                Unit generalElement = new Unit();
                generalElement.Name = "MOYENNE GÉNÉRALE";
                generalElement.Coef = 1;

                allScores.Add(new AvgScore(generalSum / generalCoef, generalElement));
            }

            return allScores.ToArray();
        }
    }
}