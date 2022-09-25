using System;
using System.Collections.Generic;


namespace bmiLaskin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> bmiLista = new List<double> {}; //Lista, johon laskut tallentuu ohjelman päällä olemisen ajan
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
            Console.WriteLine("Palaa alkuun painamalla ENTER tai ihan mitä vain katsoaksesi BMI-historian");

            //Jos painetaan ENTER, mennään takaisin ohjelman alkuun. Muuten ihan mitä vain painamalla näytetään lista ja sen sisältö. 
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                goto pituus;
            }else
            {
                Console.Clear();
                foreach (double bmi in bmiLista)
                {
                    Console.WriteLine($"BMI: {bmi}\n");
                }
            }
        }
    }
}
