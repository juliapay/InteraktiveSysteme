using System;
using System.ComponentModel;
using System.Windows.Media;

namespace MyCampus02WPFApp
{
    /// <summary>
    /// Die Klasse "Staat" implementiert das Interface "INotifyPropertyChanged",
    /// damit Änderungen an den Eigenschaften von WPF erkannt und in der UI reflektiert werden.
    /// </summary>
    public class Staat : INotifyPropertyChanged
    {
        // Private Felder zur Speicherung der Werte
        private int glückszahl;              // Speichert die aktuelle Glückszahl
        private Brush glückszahlFarbe;       // Speichert die Farbe der Glückszahl (Rot oder Grün)
        private string glückszahlBewertung;  // Speichert den Bewertungstext ("Gute Glückszahl" oder "Schlechte Glückszahl")
        private int bevölkerung;
        private string staatsKategorie;
        private string staatsBildPfad;
        // Öffentliche Eigenschaften für verschiedene Merkmale eines Staates
        public string Name { get; set; }
        public string Sprache { get; set; }

        public bool EuMitglied { get; set; }  //automatic Proberty!!
        public int Bevölkerung
        {
            get => bevölkerung;
            set
            {
                if (bevölkerung != value)
                {
                    bevölkerung = value;
                    OnPropertyChanged(nameof(Bevölkerung));

                    // Kategorisierung setzen
                    if (bevölkerung < 335057301)
                    {
                        StaatsBildPfad = "/Images/kitten.jpg";
                        StaatsKategorie = "Zwergenstaat";
                    }
                    else if(bevölkerung > 335057301 && bevölkerung < 762069575)
                        {
                        StaatsBildPfad = "/Images/normalCat.jpg";
                        StaatsKategorie = "Mittelgroßerstaat";
                    }
                    else if(bevölkerung > 762069575)
                    {
                        StaatsBildPfad = "/Images/bigCat.jpg";
                        StaatsKategorie = "Riesenstaat";
                    }

                    OnPropertyChanged(nameof(StaatsBildPfad));
                }
            }
        }
        public string StaatsKategorie
        {
            get => staatsKategorie;
            private set
            {
                staatsKategorie = value;
                OnPropertyChanged(nameof(StaatsKategorie));
            }
        }

        public string StaatsBildPfad
        {
            get => staatsBildPfad;
            private set
            {
                staatsBildPfad = value;
                OnPropertyChanged(nameof(StaatsBildPfad));
            }
        }
        /// <summary>
        /// Die Glückszahl des Staates, die von einem Zufallsgenerator gesetzt wird.
        /// Ändert sich die Glückszahl, wird das UI darüber informiert.
        /// </summary>
        public int Glückszahl
        {
            get => glückszahl;
            set
            {
                // Nur wenn sich der Wert tatsächlich ändert, wird die Aktualisierung ausgeführt
                if (glückszahl != value)
                {
                    glückszahl = value; 
                    OnPropertyChanged(nameof(Glückszahl));

                    GlückszahlFarbe = glückszahl < 50 ? Brushes.Red : Brushes.Green;
                    //geht auch mit if - else!!!
                    // Bewertungstext entsprechend der Glückszahl anpassen
                    GlückszahlBewertung = glückszahl < 50 ? "Schlechte Glückszahl" : "Gute Glückszahl";
                    // OnPropertyChanged(nameof(GlückszahlBewertung)); // UI über die Änderung informieren
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GlückszahlBewertung)));
                }
            }
        }
        /// <summary>
        /// Farbe der Glückszahl, die im UI angezeigt wird.
        /// Die Farbe ist entweder Rot (bei einer niedrigen Glückszahl) oder Grün (bei einer hohen Glückszahl).
        /// </summary>
        public Brush GlückszahlFarbe
        {
            get => glückszahlFarbe;
            private set
            {
                glückszahlFarbe = value; 
                // OnPropertyChanged(nameof(GlückszahlFarbe)); 

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GlückszahlFarbe)));
            }
        }

        /// <summary>
        /// Bewertungstext, der anzeigt, ob die Glückszahl gut oder schlecht ist.
        /// Wird automatisch angepasst, wenn sich die Glückszahl ändert.
        /// </summary>
        public string GlückszahlBewertung
        {
            get => glückszahlBewertung;
            private set
            {
                glückszahlBewertung = value;
                // OnPropertyChanged(nameof(GlückszahlBewertung)); // UI über die Textänderung informieren
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(GlückszahlBewertung));
            }
        }

        /// <summary>
        /// Event, das ausgelöst wird, wenn eine Eigenschaft geändert wurde.
        /// Wird für das UI-Update benötigt.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Methode zum Auslösen des PropertyChanged-Events.
        /// Diese Methode informiert das UI darüber, dass eine bestimmte Eigenschaft geändert wurde.
        /// </summary>
        /// <param name="propertyName">Der Name der Eigenschaft, die sich geändert hat</param>
        protected void OnPropertyChanged(string propertyName)
        {
            // Falls es Abonnenten für das Event gibt, wird das Event ausgelöst
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
