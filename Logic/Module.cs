namespace Logic
{
    public class Module : EducationalElement
    {
        public AvgScore ComputeAverage(Exam[] exams)
        {
            float sum = 0;
            float coefSum = 0;
            bool hasExams = false;

            foreach (Exam exam in exams)
            {
                // On ne prend que les examens liés à CE module[cite: 34]
                if (exam.Module == this)
                {
                    sum += exam.Note * exam.Coef;
                    coefSum += exam.Coef;
                    hasExams = true;
                }
            }

            // Si aucun examen n'existe, la moyenne n'est pas calculable[cite: 34]
            if (!hasExams || coefSum == 0) return null;

            return new AvgScore(sum / coefSum, this);
        }
    }
}