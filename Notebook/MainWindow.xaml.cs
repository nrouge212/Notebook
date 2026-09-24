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
    }
}