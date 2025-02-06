using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyCampus02WPFApp
{
    /// <summary>
    /// Interaction logic for MyLVWindow.xaml
    /// </summary>
    public partial class MyLVWindow : Window
    {
        public MyLVWindow()
        {
            InitializeComponent();

            //Datenkontext
            Lv myLv = new Lv();
            myLv.Bezeichnung = "ISY";
            myLv.Stunden = 32;
            myLv.Abgeschlossen = false;
            myLv.Level = "Green";
            //Wichtig muss gesetzt werden!!
            this.DataContext = myLv;

            //Staat Sprache Bevölkerunggröße slider oder Textbox   ToogleButton isChecked Eu
        }
    }
}
