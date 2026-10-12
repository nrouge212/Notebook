using System;
using System.Windows;
using Logic; // Pour utiliser EducationalElement

namespace Notebook
{
    public partial class EditElementWindow : Window
    {
        private EducationalElement element;

        public EditElementWindow(EducationalElement elt)
        {
            InitializeComponent();
            element = elt;

            // On remplit les champs avec les valeurs actuelles
            name.Text = element.Name;
            coef.Text = element.Coef.ToString();
        }

        private void Validate(object sender, RoutedEventArgs e)
        {
            try
            {
                // On met à jour l'élément avec ce que l'utilisateur a tapé
                element.Name = name.Text;
                element.Coef = (float)Convert.ToDouble(coef.Text);

                // On ferme la fenêtre en indiquant que c'est un succès
                DialogResult = true;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Erreur de saisie");
            }
        }
    }
}