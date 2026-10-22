using System.Windows;
using Logic;

namespace Notebook
{
    public partial class ListExamsWindow : Window
    {
        private Logic.Notebook notebook;

        public ListExamsWindow(Logic.Notebook nb)
        {
            InitializeComponent();
            notebook = nb;
            DrawExams();
        }

        private void DrawExams()
        {
            exams.Items.Clear();
            foreach (Exam e in notebook.ListExams())
            {
                exams.Items.Add(e);
            }

            scores.Items.Clear();
            foreach (AvgScore avg in notebook.ComputeScores())
            {
                scores.Items.Add(avg);
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}