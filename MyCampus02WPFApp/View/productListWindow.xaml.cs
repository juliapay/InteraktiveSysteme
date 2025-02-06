using MyCampus02WPFApp.ViewModels;
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

namespace MyCampus02WPFApp.View
{
    /// <summary>
    /// Interaction logic for productListWindow.xaml
    /// </summary>
    public partial class productListWindow : Window
    {

        public productListWindow()
        {
            InitializeComponent();
            ProductListViewModels vm = new ProductListViewModels();
            vm.ProductList= new System.Collections.ObjectModel.ObservableCollection<model.Product>();
            vm.AddProdukt(new model.Product
            {
                ProduktID = 1,
                Bezeichnung = "Produkt1",
                Kategorie ="Blue",
                Auflager=false,
                Preis=0.0
            }) ;
            vm.AddProdukt(new model.Product
            {
                ProduktID = 2,
                Bezeichnung = "Produkt2",
                Kategorie = "Yellow",
                Auflager = true,
                Preis = 10.0
            });

            this.DataContext = vm;

        }


        private void NeueseProductHinzufügen(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as ProductListViewModels;
            if(vm != null)
            {
                vm.AddProdukt(new model.Product
                {
                    ProduktID = vm.ProductList.Count + 1,
                    Bezeichnung = "Neues Produkt",
                    Kategorie = "Unbekannt",
                    Auflager = false,
                    Preis = 0.0
                });
            }
       
        }
    }
}
