using System;
using System.Collections.Generic;

namespace Logic
{
    public class Notebook
    {
        private List<Unit> units = new List<Unit>();

        //Liste des examens (tous les examens de toutes les unités)
        private List<Exam> exams = new List<Exam>();

        // --- GESTION DES UNITES ---
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

        // --- GESTION DES EXAMENS ET MODULES ---

        // Fournit un tableau listant tous les modules (quelle que soit leur UE)
        public Module[] ListModules()
        {
            List<Module> allModules = new List<Module>();
            foreach (Unit u in units)
            {
                allModules.AddRange(u.ListModules());
            }
            return allModules.ToArray();
        }

        // Ajoute un examen à la liste
        public void AddExam(Exam exam)
        {
            exams.Add(exam);
        }

        public Exam[] ListExams()
        {
            return exams.ToArray();
        }
    }
}