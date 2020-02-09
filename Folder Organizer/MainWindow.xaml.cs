using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FolderOrganizer.Core;

namespace Folder_Organizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void organizeFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(this, "Organizing Folder please wait.");
        }

        private void selectFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                selectedFolderPath.Text = dlg.SelectedPath;

                var folderOrganizer = new FolderOrganizer.Core.FolderOrganizer(dlg.SelectedPath);
            }
        }
    }
}
