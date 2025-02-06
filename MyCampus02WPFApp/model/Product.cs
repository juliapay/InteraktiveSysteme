using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCampus02WPFApp.model
{
    internal class Product : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler ProbertyCanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private int _ProduktID;

        public int ProduktID
        {
            get { return _ProduktID; }
            set
            {
                _ProduktID = value;
                informGui("ProduktID");
            }
        }

        private void informGui(string propName)
        {
            if (this.PropertyChanged != null)
            {
                ProbertyCanged(this, new PropertyChangedEventArgs(nameof(propName)));
            }
        }

        private string _Bezeichnung;

        public string Bezeichnung
        {
            get { return _Bezeichnung; }
            set { _Bezeichnung = value;
                informGui("Bezeichnung");
            }
        }

        private string _Kategorie;

        public string Kategorie
        {
            get { return _Kategorie; }
            set { _Kategorie = value;
                informGui("Kategorie");
            }
        }

        private bool _AufLager;

        public bool Auflager
        {
            get { return _AufLager; }
            set { _AufLager = value; 
                informGui("Auflager");
            }
        }

        private double _Preis;

        public double Preis
        {
            get { return _Preis; }
            set { _Preis = value;
                informGui("Preis");
            }
        }







    }
}
