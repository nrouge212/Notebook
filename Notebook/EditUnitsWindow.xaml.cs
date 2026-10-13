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

        // --- GESTION DES MODULES ---

        // AJOUTER UN MODULE (Partie 6 du TP)
        private void AddModule(object sender, RoutedEventArgs e)
        {
            try
            {
                // Vérifier qu'une Unité est bien sélectionnée à gauche avant d'ajouter un module
                if (units.SelectedItem is Unit unitSelectionnee)
                {
                    Module newModule = new Module();
                    EditElementWindow fenetreModule = new EditElementWindow(newModule);

                    if (fenetreModule.ShowDialog() == true)
                    {
                        unitSelectionnee.AddModule(newModule); // Ajoute au métier
                        DrawModules(); // Met à jour l'affichage
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner une Unité avant d'ajouter un module.");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void EditModule(object sender, MouseButtonEventArgs e)
        {
            if (modules.SelectedItem is Module m)
            {
                EditElementWindow fenetreModule = new EditElementWindow(m);
                if (fenetreModule.ShowDialog() == true)
                {
                    DrawModules(); 
                }
            }
        }

        private void RemoveModule(object sender, RoutedEventArgs e)
        {
            try
            {
                if (units.SelectedItem is Unit unitSelectionnee && modules.SelectedItem is Module moduleSelectionne)
                {
                    unitSelectionnee.RemoveModule(moduleSelectionne); // Supprime du métier
                    DrawModules(); // Met à jour l'affichage
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}