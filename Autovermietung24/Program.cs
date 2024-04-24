using System;
using System.Net.WebSockets;
using System.Threading;
using Autovermietung24.Daten;
using Autovermietung24.Modell;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

class Program
{
    public static void Main()
    {
        Console.Clear();
        bool Dmenu = false;

        do
        {
            Console.WriteLine("Hauptmenü: Wählen sie einer der Optionen in dem sie die zugehörige Zahl eintippen:\n" +
            "1. Automanagement\n" +
            "2. Kundenmanagement\n" +
            "3. Beenden");
            var menu = Console.ReadLine();
            switch (menu)
            {
                case "1":
                    Automanagement();
                    break;
                case "2":
                    Kundenmanagement();
                    break;
                case "3":
                    Console.WriteLine("Anwendung wird beendet.");
                    return;
                default:
                    Console.WriteLine("Ungültige Option. Bitte wählen Sie erneut.");
                    Dmenu = true;
                    break;
            }
        }while (Dmenu);


    }
    public static void Automanagement()
    {
        Console.Clear();
        bool DAmenu = false;

        do
        {
            Console.WriteLine("Automanagement-Menü: Wählen sie einer der Optionen in dem sie die zugehörige Zahl eintippen:\n" +
            "1. \n" +
            "2. \n" +
            "3. ");
            var Amenu = Console.ReadLine();
            switch (Amenu)
            {
                case "1":
                    Console.WriteLine("hi");
                    break;
                case "2":
                    Console.WriteLine("hey");
                    break;
                case "3":
                    Console.WriteLine("Anwendung wird beendet.");
                    return;
                default:
                    Console.WriteLine("Ungültige Option. Bitte wählen Sie erneut.");
                    DAmenu = true;
                    break;
            }
        } while (DAmenu);
    }
    public static void Kundenmanagement()
    {
        Console.Clear();
        bool DKmenu = false;

        do
        {
            Console.WriteLine("Kundenmanagement-Menü: Wählen sie einer der Optionen in dem sie die zugehörige Zahl eintippen:\n" +
            "1. \n" +
            "2. \n" +
            "3. ");
            var Kmenu = Console.ReadLine();
            switch (Kmenu)
            {
                case "1":
                    Console.WriteLine("bye");
                    break;
                case "2":
                    Main();
                    break;
                case "3":
                    Console.WriteLine("Anwendung wird beendet.");
                    return;
                default:
                    Console.WriteLine("Ungültige Option. Bitte wählen Sie erneut.");
                    DKmenu = true;
                    break;
            }
        } while (DKmenu);
    }
}
