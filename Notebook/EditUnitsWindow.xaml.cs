using System;
using System.Windows;
using System.Windows.Input;
using Logic;

namespace Notebook
{
    public partial class EditUnitsWindow : Window
    {
        private Logic.Notebook notebook;

        public EditUnitsWindow(Logic.Notebook nb)
        {
            InitializeComponent();
            notebook = nb;
            DrawUnits();
        }

        private void DrawUnits()
        {
            var list = notebook.ListUnits();
            units.Items.Clear();
            foreach (var item in list)
            {
                units.Items.Add(item);
            }
        }

        // MODIFIER
        private void EditUnit(object sender, MouseButtonEventArgs e)
        {
            if (units.SelectedItem is Unit u)
            {
                EditElementWindow third = new EditElementWindow(u);
                if (third.ShowDialog() == true)
                {
                    DrawUnits();
                }
            }
        }

        // AJOUTER
        private void AddUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                Unit newUnit = new Unit();
                EditElementWindow third = new EditElementWindow(newUnit);

                if (third.ShowDialog() == true)
                {
                    notebook.AddUnit(newUnit);
                    DrawUnits();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        // SUPPRIMER
        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            try
            {
                if (units.SelectedItem is Unit unit)
                {
                    notebook.RemoveUnit(unit);
                    DrawUnits();
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void DrawModules()
        {
            if (units.SelectedItem is Unit unit)
            {
                var list = unit.ListModules();
                modules.Items.Clear();

                foreach (Module m in list)
                {
                    modules.Items.Add(m);
                }
            }
        }

        private void SelectUnit(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DrawModules();
        }
    }
}