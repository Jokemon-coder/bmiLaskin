using System;
using System.Collections.Generic;


namespace bmiLaskin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> bmiLista = new List<double> {}; //Lista, johon laskut tallentuu ohjelman päällä olemisen ajan
        alku:
            Console.Clear();
            Console.WriteLine("Tervetuloa BMI-laskuriin!");
            Console.WriteLine("Valitse 1, jos haluat päästä laskuriin.");
            Console.WriteLine("Valitse 2, jos haluat päästä historiaan.");
            Console.WriteLine("Lisää valitsemasi luku ja paina ENTER:");
            string luku = Console.ReadLine(); //Pitää saada toimimaan järkevästi niin, että ottaa vastaan vain 1 tai 2 ja muut heittää alkuun!!
                         
            if (luku == "1")
            {
                Console.Clear();
                goto pituus;
            }
            else if (luku == "2")
            {
                Console.Clear();
                goto historia;
            }
            else
            {
                goto alku;
            }

        pituus:
            Console.Clear();
            Console.WriteLine("BMI-indeksin laskuri");
            Console.WriteLine("Pituutesi metreinä:");
            string pituus = Console.ReadLine();
            //Kokeillaan muuttaa annettu luku oikeaan muotoon ja jos ei toimi, viesti ja paluu
            try
            {
                double pituusLuku = Convert.ToDouble(pituus);
            }
            catch
            {
                Console.WriteLine("Lisäsit väärän arvon");
                goto pituus;
            }
            paino:
            Console.WriteLine("Ja painosi kiloina");
            string paino = Console.ReadLine();
            //Kokeillaan muuttaa annettu luku oikeaan muotoon ja jos ei toimi, viesti ja paluu
            try
            {
                double painoLuku = Convert.ToDouble(paino);
            }
            catch
            {
                Console.WriteLine("Lisäsit väärän arvon");
                goto paino;
            }
            //Muunnettaan annetut luvut uudestaan erikseen, koska TRY-CATCHin sisällä ne ovat itsekseen omassa tilassaan
            double pituusLasku = Convert.ToDouble(pituus);
            double painoLasku = Convert.ToDouble(paino);

            //Luodaan luku, jonka arvo on BMI-laskun tulos. Valmis luku lisätään listan perälle
            double bmiLuku = painoLasku / (pituusLasku * pituusLasku);
            bmiLista.Add(bmiLuku);

            Console.Clear();
            Console.WriteLine($"Sinun BMI-indeksisi on {bmiLuku}");
        historia:
            Console.WriteLine("Palaa alkuun painamalla ESC tai ENTER katsoaksesi BMI-laskujen historian. Voit myös sulkea ohjelman painamalla mitä vain muuta.");

            //Jos painetaan ENTER, mennään takaisin ohjelman alkuun. Muuten ihan mitä vain painamalla näytetään lista ja sen sisältö. 
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                goto alku;
            }
            else if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                if (bmiLista.Count == 0)
                {
                    Console.WriteLine("Et voi katsoa historiaa, koska sitä ei vielä ole. Paina ESC palataksesi alkuun!");
                    Console.ReadKey(Console.ReadKey().Key == ConsoleKey.Escape);
                    goto alku;
                }
                else
                {
                bmilista:
                    Console.Clear();
                    foreach (double bmi in bmiLista)
                    {
                        Console.WriteLine(bmiLista.IndexOf(bmi) + " " + $"BMI: {bmi}\n");
                    }
                    Console.WriteLine("Voit poistaa laskuja historiasta kirjoittamalla niiden ID-luvun ja painamalla ENTER. Voit poistua takaisin alkuuen painamalla ESC.");      
                    //Lisää myös alkuun mahdollisuus katsoa historiaa. Pitää päästä alkuun. Hoidettu
                    //Try-Catch antaa väärä arvo viestin, vaikka olisi oikein ja menee vasta seuraavalla yrityksellä läpi. Selvitä!!
                    /*Jostain syystä lisää samanarvoiset BMI-arvot samoilla indekseillä listassa ja ne näkyy samana lukuna konsolissa. Pitää korjata. Tämä kun tapahtuu niin sanoo että väärä arvo on lisätty, vaikka olisi oikea.
                     *En tiedä mistä johtuu, mutta arvaisin sen liittyvän try-catchiin ja goto-lausekkeisiin. Pitää selvittää!!

                    */
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        goto alku;
                    }
                muutto:
                    int bmiID;
                    try
                    {
                        bmiID = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Syötit väärän arvon, yritä uudelleen:");
                        goto muutto;
                    }
                    Console.Clear();
                    foreach (double bmi in bmiLista)
                    {
                        Console.WriteLine(bmiLista.IndexOf(bmi) + " " + $"BMI: {bmi}\n");
                    }
                    try
                    {
                        bmiLista.RemoveAt(bmiID);
                    }
                    catch
                    {
                        Console.WriteLine("Antamaasi arvoa ei löydy listalta, yritä uudelleen:");
                        goto muutto;
                    }
                    goto bmilista;
                    /*Console.Clear();
                    foreach (double bmi in bmiLista)
                    {
                        Console.WriteLine(bmiLista.IndexOf(bmi) + " " + $"BMI: {bmi}\n");
                    }*/

                }
            }

            
        }
    }
}
