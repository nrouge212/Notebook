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
    }
}