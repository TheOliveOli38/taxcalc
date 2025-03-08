using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    { 
        static void Main(string[] args)
        {
            double Verdienst;
            Verdienst = 0;
            string input = String.Empty;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            // ASCII Art
            Console.WriteLine("");
            Console.WriteLine(" #######                #####                       ");
            Console.WriteLine("    #      ##   #    # #     #   ##   #       ####  ");
            Console.WriteLine("    #     #  #   #  #  #        #  #  #      #    # ");
            Console.WriteLine("    #    #    #   ##   #       #    # #      #      ");
            Console.WriteLine("    #    ######   ##   #       ###### #      #      ");
            Console.WriteLine("    #    #    #  #  #  #     # #    # #      #    # ");
            Console.WriteLine("    #    #    # #    #  #####  #    # ######  ####  ");
            Console.WriteLine("");
            Console.WriteLine(" Das Steuerberechnungsprogramm!");
            Console.WriteLine(" Made in 2 days by TheOliveOli :3");
            Console.WriteLine(" Powered by .NET C#");
            Console.WriteLine("");
            Console.WriteLine(" Info: TaxCalc berechnet die Einkommensteuer mit einer Annäherungsfunktion. Ergebnisse sind nur teilweise akkurat.");
            Console.WriteLine("");
            Console.Write(" Zum Fortfahren Enter drücken: ");
            input = Console.ReadLine();
            bool debugMode = false;
            if (input == "d")
            {
                input = String.Empty;
                debugMode = true;
                Console.WriteLine(" ");
                Console.WriteLine(" Debug Mode On!");
                Console.Write(" Zum Fortfahren Enter drücken: ");
                input = Console.ReadLine();
                input = String.Empty;
            }
            input = String.Empty;

            // Fancy first stage UI stuff
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" ---------------------------------------------------------");
            Console.WriteLine(" TaxCalc");
            Console.WriteLine(" ------------------(O)--------------()--------------()");
            Console.WriteLine("             Einkommensteuer  Kapitalsteuer    Endergebnis");
            Console.WriteLine("");
            Console.WriteLine(" Fangen wir mit der Einkommenssteuer an. Bitte den Brutto-Gehalt (jährlich) in Euro angeben.");
            Console.WriteLine("");

            // User Input code & Conversion to Int (because computers are dumb)
            Console.Write(" Bruttogehalt: ");
            input = Console.ReadLine();
            Verdienst = Convert.ToInt32(input);
            input = String.Empty;
            double calcTaxMoney = 0;

            if(Verdienst<12097)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(" ---------------------------------------------------------");
                Console.WriteLine(" TaxCalc");
                Console.WriteLine(" ------------------(-)--------------()--------------()");
                Console.WriteLine("             Einkommensteuer  Kapitalsteuer    Endergebnis");
                Console.WriteLine("");
                Console.WriteLine(" Da das Bruttogehalt weniger als 12,097 EUR beträgt, muss die Einkommensteuer nicht bezahlt werden.");
                Console.WriteLine("");
                Console.Write(" Zum Fortfahren Enter drücken: ");
                input = Console.ReadLine();
                input = String.Empty;
            }
            else if (Verdienst >= 12097)
            {
                // Calculate amount to deduce 1st taxes (Einkommens-/Lohnsteuer) from
                double firstTaxReduxAmnt;
                firstTaxReduxAmnt = Verdienst - 12096;
                
                // Tax reduction for amnts between 12,907€ and 68,481€ (Stage 1 & 2)
                if(Verdienst < 68481)
                {
                    int i = 12097;
                    double taxMoney = 0;
                    while (i <= Verdienst)
                    {
                        double a = 0.1677 * Math.Pow(i, 0.4965);
                        double b = a / 100;
                        double c = 1 - b;
                        if(debugMode == true)
                        {
                            Console.WriteLine(" " + c + " - " + i);
                        }
                        taxMoney = taxMoney + c;
                        i = i + 1;
                    }
                    double taxMoneyRd = Math.Round(taxMoney, 2);
                    calcTaxMoney = taxMoneyRd + 12096;
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(" ----------------------------------------------------------");
                    Console.WriteLine(" TaxCalc");
                    Console.WriteLine(" ------------------(-)--------------()--------------()");
                    Console.WriteLine("             Einkommensteuer  Kapitalsteuer    Endergebnis");
                    Console.WriteLine("");
                    Console.WriteLine(" Nach den Einkommensteuerabzügen verbleiben noch " + calcTaxMoney + " EUR");
                    Console.WriteLine("");
                    Console.Write(" Zum Fortfahren Enter drücken: ");
                    input = Console.ReadLine();
                    input = String.Empty;
                }

                // Tax reduction for amnts between 68,481€ and 277,826€ (Stage 3)
                if (Verdienst >= 68481 && Verdienst < 277826)
                {
                    // Tax calculation for Stg. 1 & 2
                    int i = 12097;
                    double taxMoneyPart1 = 0;
                    while (i < 68481)
                    {
                        double a = 0.1677 * Math.Pow(i, 0.4965);
                        double b = a / 100;
                        double c = 1 - b;
                        if (debugMode == true)
                        {
                            Console.WriteLine(" " + c + " - " + i);
                        }
                        taxMoneyPart1 = taxMoneyPart1 + c;
                        i = i + 1;
                    }

                    // Tax calculation for Stg. 3
                    double taxMoneyPart2 = 0;
                    int j = 68481;
                    while (j <= Verdienst)
                    {
                        double d = 1 - 0.42;
                        if (debugMode == true)
                        {
                            Console.WriteLine(" " + d + " - " + j);
                        }
                        taxMoneyPart2 = taxMoneyPart2 + d;
                        j = j + 1;
                    }

                    // Final money amnt post first tax reduction calculation
                    double taxMoneyPart1Rnd = Math.Round(taxMoneyPart1, 2);
                    double taxMoneyPart2Rnd = Math.Round(taxMoneyPart2, 2);
                    calcTaxMoney = taxMoneyPart1Rnd + taxMoneyPart2Rnd + 12096;
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(" ----------------------------------------------------------");
                    Console.WriteLine(" TaxCalc");
                    Console.WriteLine(" ------------------(-)--------------()--------------()");
                    Console.WriteLine("             Einkommensteuer  Kapitalsteuer    Endergebnis");
                    Console.WriteLine("");
                    Console.WriteLine(" Nach den Einkommensteuerabzügen verbleiben noch " + calcTaxMoney + " EUR.");
                    Console.WriteLine("");
                    Console.Write(" Zum Fortfahren Enter drücken: ");
                    input = Console.ReadLine();
                    input = String.Empty;
                }

                if (Verdienst >= 277826)
                {
                    // Tax calculation for Stg. 1 & 2
                    int i = 12097;
                    double taxMoneyPart1 = 0;
                    while (i < 68481)
                    {
                        double a = 0.1677 * Math.Pow(i, 0.4965);
                        double b = a / 100;
                        double c = 1 - b;
                        if(debugMode == true)
                        {
                            Console.WriteLine(" " + c + " - " + i);
                        }
                        taxMoneyPart1 = taxMoneyPart1 + c;
                        i = i + 1;
                    }

                    // Tax calculation for Stg. 3
                    double taxMoneyPart2 = 0;
                    int j = 68481;
                    while (j < 277826)
                    {
                        double d = 1 - 0.42;
                        if (debugMode == true)
                        {
                            Console.WriteLine(" " + d + " - " + j);
                        }
                        taxMoneyPart2 = taxMoneyPart2 + d;
                        j = j + 1;
                    }

                    // Tax calculation for Stg. 4
                    double taxMoneyPart3 = 0;
                    int k = 277826;
                    while (k <= Verdienst)
                    {
                        double e = 1 - 0.45;
                        if(debugMode == true)
                        {
                            Console.WriteLine(" " + e + " - " + k);
                        }
                        taxMoneyPart3 = taxMoneyPart3 + e;
                        k = k + 1;
                    }


                    // Rounding & Displaying values
                    double taxMoneyPart1Rnd = Math.Round(taxMoneyPart1, 2);
                    double taxMoneyPart2Rnd = Math.Round(taxMoneyPart2, 2);
                    double taxMoneyPart3Rnd = Math.Round(taxMoneyPart3, 2);
                    calcTaxMoney = taxMoneyPart1Rnd + taxMoneyPart2Rnd + taxMoneyPart3Rnd + 12096;
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(" ----------------------------------------------------------");
                    Console.WriteLine(" TaxCalc");
                    Console.WriteLine(" ------------------(-)--------------()--------------()");
                    Console.WriteLine("             Einkommensteuer  Kapitalsteuer    Endergebnis");
                    Console.WriteLine("");
                    Console.WriteLine(" Nach den Einkommensteuerabzügen verbleiben noch " + calcTaxMoney + " EUR.");
                    Console.WriteLine("");
                    Console.Write(" Zum Fortfahren Enter drücken: ");
                    input = Console.ReadLine();
                    input = String.Empty;
                }
            }
            KapErt:
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" ----------------------------------------------------------");
            Console.WriteLine(" TaxCalc");
            Console.WriteLine(" ------------------(-)--------------(O)--------------()");
            Console.WriteLine("             Einkommensteuer   Kapitalsteuer    Endergebnis");
            Console.WriteLine("");
            Console.WriteLine(" Als nächstes wird die Kapitalsteuer berechnet.");
            Console.WriteLine(" Zur Kapitalsteuer zählen Gewinne durch bspw. den Aktienmarkt. (Aktienverkauf, Dividenden usw.)");
            Console.WriteLine("");
            Console.Write(" Sind Kapitalerträge vorhanden? (J/N): ");
            input = Console.ReadLine();

            double kapitalErtrag = 0;
            double kapitalErtragPostAbzug = 0;
            if (input == "J")
            {
                // Note: Kapitalertragssteuer: 25% ab 1000€
                input = String.Empty;
                Console.Write(" Verdiente Anzahl an Geld durch Kapitalerträge? ");
                input = Console.ReadLine();
                kapitalErtrag = Convert.ToInt32(input);
                input = String.Empty;
                if (kapitalErtrag < 1001)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(" ----------------------------------------------------------");
                    Console.WriteLine(" TaxCalc");
                    Console.WriteLine(" ------------------(-)--------------(-)--------------()");
                    Console.WriteLine("             Einkommensteuer   Kapitalsteuer    Endergebnis");
                    Console.WriteLine("");
                    Console.WriteLine(" Da weniger als 1001 EUR verdient wurden, sind keine Kapitalertragssteuerabzüge nötig.");
                    Console.WriteLine("");
                    Console.Write(" Zum Fortfahren Enter drücken: ");
                    input = Console.ReadLine();
                    input = String.Empty;
                }
                else if (kapitalErtrag >= 1001)
                {
                    double l = 1001;
                    double taxMoney2 = 0;
                    while (l <= kapitalErtrag)
                    {
                        double f = 1 - 0.25;
                        if (debugMode == true)
                        {
                            Console.WriteLine(" " + f + " - " + l);
                        }
                        taxMoney2 = taxMoney2 + f;
                        l = l + 1;
                    }
                    double taxMoney2Final = taxMoney2 + 1000;
                    double taxMoney2FinalRd = Math.Round(taxMoney2Final, 2);
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine(" ----------------------------------------------------------");
                    Console.WriteLine(" TaxCalc");
                    Console.WriteLine(" ------------------(-)--------------(-)--------------()");
                    Console.WriteLine("             Einkommensteuer   Kapitalsteuer    Endergebnis");
                    Console.WriteLine("");
                    Console.WriteLine(" Nach den Kapitalsteuerabzügen verbleiben noch " + taxMoney2FinalRd + " EUR.");
                    Console.WriteLine("");
                    Console.Write(" Zum Fortfahren Enter drücken: ");
                    input = Console.ReadLine();
                    input = String.Empty;
                }
            }
            else if (input == "N")
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(" ----------------------------------------------------------");
                Console.WriteLine(" TaxCalc");
                Console.WriteLine(" ------------------(-)--------------(-)--------------()");
                Console.WriteLine("             Einkommensteuer   Kapitalsteuer    Endergebnis");
                Console.WriteLine("");
                Console.WriteLine(" Keine Kapitalsteuerabzüge nötig.");
                Console.WriteLine("");
                Console.Write(" Zum Fortfahren Enter drücken: ");
                input = Console.ReadLine();
                input = String.Empty;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(" ----------------------------------------------------------");
                Console.WriteLine(" TaxCalc");
                Console.WriteLine(" ------------------(-)--------------(X)--------------()");
                Console.WriteLine("             Einkommensteuer   Kapitalsteuer    Endergebnis");
                Console.WriteLine("");
                Console.WriteLine(" Dies ist eine ungültige Antwort. Bitte nur 'J' oder 'N' angeben.");
                Console.WriteLine("");
                Console.Write(" Zum Fortfahren Enter drücken: ");
                input = Console.ReadLine();
                input = String.Empty;
                goto KapErt;
            }
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" ----------------------------------------------------------");
            Console.WriteLine(" TaxCalc");
            Console.WriteLine(" ------------------(-)--------------(-)--------------(O)");
            Console.WriteLine("             Einkommensteuer   Kapitalsteuer    Endergebnis");
            Console.WriteLine("");
            Console.WriteLine(" Steuern berechnet! Von den " + Verdienst + " EUR Bruttolohn sowie " + kapitalErtrag + " EUR Kapitalertrag bleiben " + (calcTaxMoney + kapitalErtragPostAbzug) + " EUR übrig.");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" ----------");

            Random random = new Random();
            int easterEggNum = random.Next(1, 5);

            if(easterEggNum == 1)
            {
                Console.WriteLine(" All Done!");
                Console.WriteLine(" ----------");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }

            if (easterEggNum == 2)
            {
                Console.WriteLine(" Made with love and 4 Blue Screens of Death!");
                Console.WriteLine(" ----------");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }

            if (easterEggNum == 3)
            {
                Console.WriteLine(" blahaj go spinny");
                Console.WriteLine(" ----------");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }

            if (easterEggNum == 4)
            {
                Console.WriteLine(" Here we go!");
                Console.WriteLine(" ----------");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }

            if (easterEggNum == 5)
            {
                Console.WriteLine(" Say thanks on the way out!");
                Console.WriteLine(" ----------");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.Write(" Zum Beenden Enter drücken: ");
            input = Console.ReadLine();
            input = String.Empty;
        }
    }
}
