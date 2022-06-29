using System;
using System.Windows;
using System.Windows.Forms;
using System.IO;


namespace CopyCat1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public bool firstPathIsChecked { get; set; }
        public bool secondPathIsChecked { get; set; }
        public string inputPath { get; set; }
        public string firstOutputPath { get; set; }
        public string secondOutputPath { get; set; }
        public string fileName { get; set; }
        private void FirstPathCheck(object sender, RoutedEventArgs e)
        {
            firstPathIsChecked = true;
        }
        private void FirstPathUncheck(object sender, RoutedEventArgs e)
        {
            firstPathIsChecked = false;
        }
        private void SecondPathCheck(object sender, RoutedEventArgs e)
        {
            secondPathIsChecked = true;
        }
        private void SecondPathUncheck(object sender, RoutedEventArgs e)
        {
            secondPathIsChecked = false;
        }
        private void InputPath_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            inputPath = String.IsNullOrWhiteSpace(dialog.SelectedPath) ? inputPath : dialog.SelectedPath;
            inputPathText.Text = inputPath;
        }
        private void FirstOutputPath_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            firstOutputPath = String.IsNullOrWhiteSpace(dialog.SelectedPath) ? firstOutputPath : dialog.SelectedPath;
            firstOutputPathText.Text = firstOutputPath;
        }
        private void SecondOutputPath_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            secondOutputPath = String.IsNullOrWhiteSpace(dialog.SelectedPath) ? secondOutputPath : dialog.SelectedPath;
            secondOutputPathText.Text = secondOutputPath;
        }
        private void Go_Click(object sender, RoutedEventArgs e)
        {
            if(firstPathIsChecked)
            {
                foreach (var file in Directory.GetFiles(inputPath))
                {
                    File.Copy(file, System.IO.Path.Combine(firstOutputPath, System.IO.Path.GetFileName(file)));
                    //CopyClass.CopyCat(inputPath, firstOutputPath, fileName);
                }
            }
            if(secondPathIsChecked)
            {
                foreach (var file in Directory.GetFiles(inputPath))
                {
                    File.Copy(file, System.IO.Path.Combine(secondOutputPath, System.IO.Path.GetFileName(file)));
                }
            }
            if (!firstPathIsChecked && !secondPathIsChecked)
            {
                System.Windows.MessageBox.Show("Fehler", "So nicht", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }
    }
}
