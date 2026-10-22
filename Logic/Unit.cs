using System.Collections.Generic;

namespace Logic
{
    public class Unit : EducationalElement
    {
        private List<Module> modules = new List<Module>();

        public List<Module> ListModules()
        {
            return new List<Module>(modules);
        }
        public void AddModule(Module module)
        {
            modules.Add(module);
        }

        public void RemoveModule(Module module)
        {
            modules.Remove(module);
        }

        public AvgScore[] ComputeAverages(Exam[] exams)
        {
            List<AvgScore> scores = new List<AvgScore>();

            foreach (Module m in modules)
            {
                AvgScore avg = m.ComputeAverage(exams);
                // Si la moyenne du module existe, on l'ajoute
                if (avg != null)
                {
                    scores.Add(avg);
                }
            }
            return scores.ToArray();
        }
    }
}