using System;
using System.Windows;

namespace MyCampus02WPFApp
{
    /// <summary>
    /// Code-Behind Datei für das Fenster "MyStaatWindow.xaml".
    /// Diese Klasse steuert das Verhalten der Benutzeroberfläche und verwaltet die Interaktion mit dem Benutzer.
    /// </summary>
    public partial class MyStaatWindow : Window
    {
        // Private Felder für das Fenster
        private Random random;   // Zufallszahlengenerator für die Glückszahl
        private Staat myStaat;   // Instanz der "Staat"-Klasse, die als Datenquelle für die UI dient

        /// <summary>
        /// Konstruktor für das MyStaatWindow.
        /// Initialisiert das Fenster, erstellt das Staat-Objekt und setzt den Datenkontext.
        /// </summary>
        public MyStaatWindow()
        {
            InitializeComponent(); // Lädt die Benutzeroberfläche aus der XAML-Datei

            // Erstelle eine neue Instanz der Random-Klasse zur Generierung von Zufallszahlen
            random = new Random();

            // Erstelle eine neue Instanz der "Staat"-Klasse mit Standardwerten
            myStaat = new Staat
            {
                Name = "Austria",            
                Sprache = "Deutsch",          
                Bevölkerung = 9000000,        
                EuMitglied = true,            
                Glückszahl = random.Next(1, 101) 
            };

            // Setzt den Datenkontext des Fensters auf das "myStaat"-Objekt.
            // Dadurch werden alle UI-Elemente automatisch mit den Daten des "Staat"-Objekts verbunden.
            this.DataContext = myStaat;
        }

        /// <summary>
        /// Event-Handler für den Klick auf den Button "Neue Glückszahl generieren".
        /// Diese Methode generiert eine neue Zufallszahl zwischen 1 und 100 und aktualisiert die Glückszahl.
        /// </summary>
        /// <param name="sender">Das UI-Element, das das Event ausgelöst hat (der Button).</param>
        /// <param name="e">Event-Daten, die weitere Informationen über das Event enthalten.</param>
        private void GenerateNewGlückszahl(object sender, RoutedEventArgs e)
        {
            // Generiere eine neue Zufallszahl zwischen 1 und 100 und speichere sie im "Staat"-Objekt.
            // Dadurch wird automatisch die UI aktualisiert, da "INotifyPropertyChanged" verwendet wird.
            myStaat.Glückszahl = random.Next(1, 101);
        }

    }
}
