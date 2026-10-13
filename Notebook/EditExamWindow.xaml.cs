using System;
using System.Windows;
using Logic;

namespace Notebook
{
    public partial class EditExamWindow : Window
    {
        private Logic.Notebook notebook;
        private Exam newExam;

        public EditExamWindow(Logic.Notebook nb)
        {
            InitializeComponent();
            notebook = nb;
            newExam = new Exam(); // Le constructeur crée un objet Exam

            // On initialise l'interface avec les valeurs par défaut de l'objet
            datePicker.SelectedDate = newExam.Date;
            absentCheck.IsChecked = newExam.IsAbsent;
            scoreText.Text = newExam.Note.ToString();
            // Si absent par défaut, on grise la case de la note
            scoreText.IsEnabled = !newExam.IsAbsent;

            DrawModules(); //Le constructeur appelle DrawModules()
        }

        private void DrawModules()
        {
            // Appelle la méthode ListModules() du notebook
            var list = notebook.ListModules();
            moduleCombo.Items.Clear();

            // Place les modules reçus dans la ComboBox
            foreach (Module m in list)
            {
                moduleCombo.Items.Add(m);
            }
            if (moduleCombo.Items.Count > 0)
            {
                moduleCombo.SelectedIndex = 0; // Sélectionne le premier par défaut
            }
        }

        // Active/Désactive la saisie de note selon si l'élève est absent
        private void CheckAbsent(object sender, RoutedEventArgs e)
        {
            scoreText.IsEnabled = !(absentCheck.IsChecked == true);
        }

        // L'opération "Validate" reliée au bouton[cite: 50]
        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                // Modifie les propriétés de l'objet Exam associé
                newExam.Module = moduleCombo.SelectedItem as Module;
                newExam.Teacher = teacherText.Text;

                if (datePicker.SelectedDate.HasValue)
                {
                    newExam.Date = datePicker.SelectedDate.Value;
                }

                newExam.IsAbsent = absentCheck.IsChecked == true;

                if (!newExam.IsAbsent)
                {
                    newExam.Note = (float)Convert.ToDouble(scoreText.Text);
                }

                // 8. Le notebook ajoute l'examen ainsi créé dans sa liste
                notebook.AddExam(newExam);

                // Ferme la fenêtre
                this.DialogResult = true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Erreur");
            }
        }

        // L'opération "Cancel" ne fait que fermer la fenêtre
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}