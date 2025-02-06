using MyCampus02WPFApp.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampus02WPFApp.ViewModels
{
    internal class ProductListViewModels:INotifyPropertyChanged
    {
       
        //List<Produkte> ....keine changeNotification


        public ObservableCollection<Product> ProductList { get; set; }

        private int _ProduktAnzahl;

        public event PropertyChangedEventHandler PropertyChanged;

        public int ProduktAnzahl
        {
            get { return _ProduktAnzahl; }
            set { _ProduktAnzahl = value;
                informGui("ProduktAnzahl");
            }
        }

        private void informGui(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(propName)));
            }
        }


        public void AddProdukt(Product neuesProduct)
        {
            //Automatische changeNotification weil ObserverableCollection
            ProductList.Add(neuesProduct);
            ProduktAnzahl=ProductList.Count;
        }   
    }
}
