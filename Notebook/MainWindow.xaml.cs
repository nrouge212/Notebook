using System.Windows;

namespace Notebook
{
    public partial class MainWindow : Window
    {
        private Logic.Notebook notebook;

        public MainWindow()
        {
            InitializeComponent();
            notebook = new Logic.Notebook();
        }
        private void GoEditUnits(object sender, RoutedEventArgs e)
        {

            EditUnitsWindow second = new EditUnitsWindow(notebook);
            second.Show(); // On l'affiche
        }
    }
}