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
    static void Main()
    {
        Console.Clear();
        bool Dmenu = false;

        do
        {
            Console.WriteLine("Hauptmenü: Wählen sie einer der Optionen in dem sie die zugehörige Zahl eintippen:\n" +
            "1. Automanagement-Menü\n" +
            "2. Kundenmanagement-Menü\n" +
            "3. Programm Beenden");
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
    static void Automanagement()
    {
        Console.Clear();
        bool DAmenu = false;

        do
        {
            Console.WriteLine("Automanagement-Menü: Wählen sie einer der Optionen in dem sie die zugehörige Zahl eintippen:\n" +
            "1. Auto vermieten\n" +
            "2. Auto zurückgeben\n" +
            "3. Auto hinzufügen\n" +
            "4. Auto bearbeiten\n" +
            "5. Auto entfernen\n" +
            "6. Hauptmenü\n" +
            "7. Programm beenden\n");
            var Amenu = Console.ReadLine();
            switch (Amenu)
            {
                case "1":
                    vermieten();
                    break;
                case "2":
                    zuruckgeben();
                    break;
                case "3":
                    newAuto();
                    break;
                case "4":
                    editAuto();
                    break;
                case "5":
                    removeAuto();
                    break;
                case "6":
                    Main();
                    break;
                case "7":
                    Console.WriteLine("Anwendung wird beendet.");
                    return;
                default:
                    Console.WriteLine("Ungültige Option. Bitte wählen Sie erneut.");
                    DAmenu = true;
                    break;
            }
        } while (DAmenu);

        static void vermieten()
        {
            using (var dbContext = new AutovermietungsContext())
            {
                // Kundeninformationen abfragen
                Console.WriteLine("Bitte geben Sie die Kunden-ID ein:");
                int kundenId = Convert.ToInt32(Console.ReadLine());

                // Kunden in der Datenbank suchen
                var kunde = dbContext.Kunden.FirstOrDefault(k => k.Id == kundenId);

                if (kunde == null)
                {
                    Console.WriteLine("Kunde nicht gefunden.");
                    return;
                }

                // Auto auswählen, das dem Kunden zugewiesen werden soll
                Console.WriteLine("Bitte geben Sie die ID des Autos ein, das dem Kunden zugewiesen werden soll:");
                int autoId = Convert.ToInt32(Console.ReadLine());

                // Auto in der Datenbank suchen
                var auto = dbContext.Autos.FirstOrDefault(a => a.Id == autoId);

                if (auto == null)
                {
                    Console.WriteLine("Auto nicht gefunden.");
                    return;
                }

                // Kunden-ID im Statusfeld des Autos speichern
                auto.Status = Convert.ToString(kundenId);

                // Änderungen in der Datenbank speichern
                dbContext.SaveChanges();

                Console.WriteLine($"Das Auto mit der ID {autoId} wurde erfolgreich dem Kunden mit der ID {kundenId} zugewiesen.");
            }
        }

        static void zuruckgeben()
        {
            bool back = false;
            do
            {
                using (var context = new AutovermietungsContext())
                {
                    Console.WriteLine("Geben Sie die ID des zurückzugebenden Autos ein:");
                    if (int.TryParse(Console.ReadLine(), out int autoId))
                    {
                        var auto = context.Autos.FirstOrDefault(a => a.Id == autoId);
                        if (auto != null)
                        {
                            auto.Status = "Bereit";
                            context.SaveChanges();
                            Console.WriteLine("Auto wurde erfolgreich zurückgegeben und der Status wurde auf 'Bereit' gesetzt.");
                        }
                        else
                        {
                            Console.WriteLine("Das angegebene Auto wurde nicht gefunden.");
                            back = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige ID ein.");
                        back = true;
                    }
                }
            } while (back);
        }

        static void newAuto()
        {
            using (var dbContext = new AutovermietungsContext())
            {
                // Nutzereingaben abfragen
                Console.WriteLine("Bitte geben Sie die Karosserieform ein:");
                string karosserieForm = Console.ReadLine();

                Console.WriteLine("Bitte geben Sie das Getriebe ein:");
                string getriebe = Console.ReadLine();

                Console.WriteLine("Bitte geben Sie den Kraftstoff ein:");
                string kraftstoff = Console.ReadLine();

                Console.WriteLine("Bitte geben Sie die Marke ein:");
                string marke = Console.ReadLine();

                Console.WriteLine("Bitte geben Sie das Modell ein:");
                string modell = Console.ReadLine();

                Console.WriteLine("Bitte geben Sie die Erstzulassung ein:");
                string erstzulassung = Console.ReadLine();

                Console.WriteLine("Bitte geben Sie das Kennzeichen ein:");
                string kennzeichen = Console.ReadLine();

                Console.WriteLine("Bitte geben Sie den Status ein (true/false):");
                string status = Console.ReadLine();

                // Autoobjekt erstellen
                var auto = new Auto
                {
                    Karosserieform = karosserieForm,
                    Getriebe = getriebe,
                    Kraftstoff = kraftstoff,
                    Marke = marke,
                    Model = modell,
                    Erstzulassung = erstzulassung,
                    Kennzeichen = kennzeichen,
                    Status = status
                };

                // Auto zur Datenbank hinzufügen
                dbContext.Autos.Add(auto);
                dbContext.SaveChanges();

                Console.WriteLine("Auto erfolgreich zur Datenbank hinzugefügt.");
            }
        }
        static void editAuto()
        {
            bool back = false;
            do
            {
                using (var context = new AutovermietungsContext())
                {
                    Console.WriteLine("Geben Sie die ID des zu bearbeitenden Autos ein:");
                    if (int.TryParse(Console.ReadLine(), out int autoId))
                    {
                        var auto = context.Autos.FirstOrDefault(a => a.Id == autoId);
                        if (auto != null)
                        {
                            Console.WriteLine("Geben Sie die neuen Informationen für das Auto ein:");
                            // Hier können Sie die Eigenschaften des Autos aktualisieren, z.B. Marke, Modell usw.
                            context.SaveChanges();
                            Console.WriteLine("Auto wurde erfolgreich bearbeitet.");
                        }
                        else
                        {
                            Console.WriteLine("Das angegebene Auto wurde nicht gefunden.");
                            back = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige ID ein.");
                        back = true;
                    }
                }
            }while (back);
        }

        static void removeAuto()
        {
            bool back = false;
            do
            {
                using (var context = new AutovermietungsContext())
                {
                    Console.WriteLine("Geben Sie die ID des zu entfernenden Autos ein:");
                    if (int.TryParse(Console.ReadLine(), out int autoId))
                    {
                        var auto = context.Autos.FirstOrDefault(a => a.Id == autoId);
                        if (auto != null)
                        {
                            context.Autos.Remove(auto);
                            context.SaveChanges();
                            Console.WriteLine("Auto wurde erfolgreich entfernt.");
                        }
                        else
                        {
                            Console.WriteLine("Das angegebene Auto wurde nicht gefunden.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige ID ein.");
                    }
                }
            } while (back);
        }
    }
    static void Kundenmanagement()
    {
        Console.Clear();
        bool DKmenu = false;

        do
        {
            Console.WriteLine("Kundenmanagement-Menü: Wählen sie einer der Optionen in dem sie die zugehörige Zahl eintippen:\n" +
            "1. Neukunden anlegen\n" +
            "2. Kundeninformationen bearbeiten\n" +
            "3. Kunde löschen\n" +
            "4. Hauptmenü\n" +
            "5. Programm beenden");
            var Kmenu = Console.ReadLine();
            switch (Kmenu)
            {
                case "1":
                    Console.WriteLine("bye");
                    break;
                case "2":
                    Console.WriteLine("hey");
                    break;
                case "3":
                    Console.WriteLine("hey");
                    break;
                case "4":
                    Main();
                    break;
                case "5":
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
