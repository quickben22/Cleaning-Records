using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CleaningRecords.Moduli
{
    /// <summary>
    /// Interaction logic for OnlyThisShiftDlg.xaml
    /// </summary>
    public partial class OnlyThisShiftDlg : Window
    {
        public OnlyThisShiftDlg()
        {
            InitializeComponent();
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
