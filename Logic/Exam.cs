using System;

namespace Logic
{
    public class Exam
    {
        private string teacher = "";
        private DateTime date = DateTime.Now;
        private float coef = 1.0f;
        private float note = 0.0f;
        private bool isAbsent = true;
        private Module module; // Lien vers le module de l'examen

        public Module Module
        {
            get => module;
            set
            {
                if (value == null)
                    throw new Exception("Le module ne peut pas être nul");
                module = value;
            }
        }

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
                if (isAbsent) note = 0; // Si absent la note = 0
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
}