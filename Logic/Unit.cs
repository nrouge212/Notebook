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
    }
}