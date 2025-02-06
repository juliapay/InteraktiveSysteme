using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    { //hier erzeugt der compiler eine klasse
        public delegate void GreetingDelegate(string firstName);
        public delegate void HelloDelegate(string Anrede,string firstName);
        public delegate void HelloDelegateMitInt(string Anrede,string firstName, int x);
        // Delegate mit zwei string-Parametern
        public delegate void WochentagDelegate(string wochentag, string nachricht);

        static void Main(string[] args)
        {
            HelloFirstName("Ajla");
          //  int a = 12;
            //hier wird zugerufen und nicht aufgerufen! Deswegen ohne ()
            GreetingDelegate myHello = HelloFirstName;

            //hier passiert der Aufruf
            myHello("Ajla");
            Hello("Ich", "Chrisi");
            HelloDelegate myHello2=Hello;
            Hello("Ich", "Chrisi");
            Action<string> a1 = HelloFirstName;
            Action<string,string> a2 = Hello;
            a1("Hans");
            a2("du", "hans");
            HalloMitLogik(Hello, "ich", "jj");
            HalloMitLogik(HelloMitBindestrich, "ich", "jj");
            HalloMitLogik(HelloMitStrichpunkt, "ich", "jj");
            HalloMitLogik((an, vor) =>{ Console.WriteLine(an + "__" + vor);
            
            }, "ich","undweg");

            // Beispielmethoden für den Delegate
            WochentagDelegate wochentagMessage = WochentagMitFarbe;

            // Methode mit Logik aufrufen
            WochentagMitFarbe(wochentagMessage, "Montag", "Schöne Woche!");
            WochentagMitFarbe(wochentagMessage, "Freitag", "Schönes Wochenende!");
            WochentagMitFarbe(wochentagMessage, "Donnerstag", "Schöne Woche!");


            Ausgabe(() =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Schönes Wochenedne");
            }, 4);
            Ausgabe(() =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Bis Donnerstag");
            }, 3);

            Console.ReadLine();
            //Start 
            Console.WriteLine("Hello from the console");
        }

        public static void Ausgabe(Action myFunctionWithoutArgs, int wieOft)
        {
            for (int i = 0; i < wieOft; i++)
            {
                myFunctionWithoutArgs() ;
            }
        }

        // Logik, die je nach Wochentag eine Farbe setzt
        public static void WochentagMitFarbe(string wochentag, string nachricht)
        {
            switch (wochentag.ToLower())
            {
                case "montag":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "dienstag":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "mittwoch":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "donnerstag":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "freitag":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "samstag":
                case "sonntag":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            // Nachricht ausgeben
            Console.WriteLine($"{wochentag}: {nachricht}");

            // Zurücksetzen der Farbe
            Console.ResetColor();
        }

        // Flexible Methode mit einem Delegate
        public static void WochentagMitFarbe(WochentagDelegate myAction, string wochentag, string nachricht)
        {
            myAction(wochentag, nachricht);
        }


        public static void HalloMitLogik(Action<String,string> myAction, string anrede, string vorname)
        {
            myAction(anrede, vorname);
        }
        public static void HelloFirstName(string firstName)
        {
            Console.WriteLine("Hell0 "+firstName);
        }
        public static void Hello(String anrede, string firstname)
        {
            Console.WriteLine(anrede+" "+firstname);
        }
 
        public static void HelloMitBindestrich(String anrede, string firstname)
        {
            Console.WriteLine(anrede + "-" + firstname);
        }
        public static void HelloMitStrichpunkt(String anrede, string firstname)
        {
            Console.WriteLine(anrede + ";" + firstname);
        }

    }
}
