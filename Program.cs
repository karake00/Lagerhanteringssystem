namespace Lagerhanteringssystem
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Testade med några skapade objekt
            Produkt produkt1 = new Produkt("torrfoder", 50, 70, true);
            Produkt produkt2 = new Produkt("blötmat", 50, 50, true);
            Produkt produkt3 = new Produkt("kattsand", 100, 50, true);
            Produkt produkt4 = new Produkt("klösträd", 10, 2000, true);
            Produkt produkt5 = new Produkt("kattbädd", 3, 300, false);
            VisaMeny();
        }

        //METODER
        //Visa meny
        public static void VisaMeny()
        {
            //Behöver skapa en string för att kunna använda den i do-while loopen.
            string val;
            do
            {
                Console.WriteLine("=== LAGERHANTERINGSSYSTEM ===\n");

                Console.WriteLine("MENY:\n" +
                    "1. Visa alla produkter.\n" +
                    "2. Lägg till ny produkt.\n" +
                    "3. Sök produkt.\n" +
                    "4. Ändra lagersaldo.\n" +
                    "5. Ta bort produkt.\n" +
                    "6. Avsluta.\n");

                Console.Write("Välj mellan (1-6): ");
                val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        VisaAllaProdukter();
                        break;
                    case "2":
                        LäggTillProdukt();
                        break;
                    case "3":
                        SökProdukt();
                        break;
                    case "4":
                        ÄndraLagersaldo();
                        break;
                    case "5":
                        TaBortProdukt();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Avslutar...");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("FEL: Felaktikt val, kan bara välja mellan (1-6) i siffror.");
                        break;
                }

            } while (val != "6");
            Console.WriteLine("Tryck på valfri knapp sedan enter för att avsluta...");
            Console.ReadKey(true);

        }

        //Visar alla produkter
        public static void VisaAllaProdukter()
        {
            Console.Clear();
            Console.WriteLine("=== VISA ALLA PRODUKTER ===\n");

            //Om listan med produkter skulle vara tom, så visas ett meddelande istället. Annars om det finns, körs resten av metoden.
            if (Produkt.produkter.Count < 1)
            {
                Console.WriteLine("FEL: Finns inga produkter att visa.");
            }
            else
            {
                Console.WriteLine($"Namn:{"",-6}| Antal:{"",1} | Pris:{"",2} | Tillgänglig: |");
                Console.WriteLine(new string('-', 47));
                foreach (var produkt in Produkt.produkter)
                {
                    Console.WriteLine(produkt);
                    Console.WriteLine(new string('-', 47));
                }
            }
            Console.WriteLine("\nTryck på valfri knapp för att återgå till menyn...");
            Console.ReadKey(true);
            Console.Clear();
        }

        //Lägg till ny produkt
        public static void LäggTillProdukt()
        {
            Console.Clear();
            Console.WriteLine("=== LÄGG TILL PRODUKT ===");

            Console.WriteLine("Mata in alla egenskaperna nedan för att lägga till en ny produkt.\n");

            Console.Write("Namn: ");
            string nyttnamn = Console.ReadLine().ToLower();
            while (string.IsNullOrWhiteSpace(nyttnamn))
            {
                Console.Write("FEL: Namn kan inte vara tomt: ");
                nyttnamn = Console.ReadLine().ToLower();
            }

            Console.Write("Antal: ");
            int nyttantal;
            while (!int.TryParse(Console.ReadLine(), out nyttantal) || nyttantal < 1)
            {
                Console.Write("FEL: Antal måste skrivas i siffror och får inte vara under 1: ");
            }

            Console.Write("Pris: ");
            int nyttpris;
            while (!int.TryParse(Console.ReadLine(), out nyttpris) || nyttpris < 1)
            {
                Console.Write("FEL: Pris måste skrivas i siffror och får inte vara under 1: ");
            }

            Console.Write("Tillgänglig (JA/NEJ): ");
            bool nytillgänglig;
            string input;
            while (true)
            {
                input = Console.ReadLine().ToLower();
                if (input == "ja")
                {
                    nytillgänglig = true;
                    break;
                }
                else if (input == "nej")
                {
                    nytillgänglig = false;
                    break;
                }
                else
                {
                    Console.Write("FEL: Du kan bara skriva \"Ja\" eller \"Nej\": ");
                }
            }
            //Skapar ett nytt objekt med dem alla nya värderna jag har fått av användaren.
            Produkt nyProdukt = new Produkt(nyttnamn, nyttantal, nyttpris, nytillgänglig);

            Console.WriteLine($"\nLYCKADES: Ny produkt är nu tillagd:\n");
            Console.WriteLine($"Namn:{"",-6}| Antal:{"",1} | Pris:{"",2} | Tillgänglig: |");
            Console.WriteLine(new string('-', 47));
            Console.WriteLine(nyProdukt);
            Console.WriteLine(new string('-', 47));


            Console.WriteLine("Tryck på valfri knapp för att återgå till menyn...");
            Console.ReadKey(true);
            Console.Clear();

        }

        //Sök produkt
        public static void SökProdukt()
        {
            Console.Clear();
            Console.WriteLine("=== SÖK PRODUKT ===\n");

            if (Produkt.produkter.Count < 1)
            {
                Console.WriteLine("FEL: Finns inga produkter att visa.");
            }
            else
            {

                Console.Write("Sök efter namn på produkten: ");
                string söknamn = Console.ReadLine().ToLower();

                //Om det redan finns ett objekt med namnet som användaren har matat in så får detta objekt samma värden och egenskaper.
                var sökProdukt = Produkt.produkter.FirstOrDefault(x => x.Namn == söknamn);
                //Men om det inte fanns ett objekt med det namnet användaren har matat in så visas bara ett meddelande.
                if (sökProdukt == null)
                {
                    Console.WriteLine("FEL: Hittade ingen produkt med det namnet.");
                }
                else
                {
                    Console.WriteLine($"\nNamn:{"",-6}| Antal:{"",1} | Pris:{"",2} | Tillgänglig: |");
                    Console.WriteLine(new string('-', 47));
                    Console.WriteLine(sökProdukt);
                    Console.WriteLine(new string('-', 47));
                }
            }
            Console.WriteLine("\nTryck på valfri knapp för att återgå till menyn...");
            Console.ReadKey(true);
            Console.Clear();
        }

        //Ändra lagersaldo
        public static void ÄndraLagersaldo()
        {
            Console.Clear();
            Console.WriteLine("=== ÄNDRA LAGERSALDO ===\n");

            if (Produkt.produkter.Count < 1)
            {
                Console.WriteLine("FEL: Finns inga produkter att ändra.");
            }
            else
            {

                Console.Write("Vilken produkt vill du ändra lagersaldot?\nNamn på produkt: ");
                string söknamn = Console.ReadLine().ToLower();

                var sökProdukt = Produkt.produkter.FirstOrDefault(x => x.Namn == söknamn);
                if (sökProdukt == null)
                {
                    Console.WriteLine("FEL: Hittade ingen produkt med det namnet.");
                }
                else
                {
                    Console.Write("Vad vill du ändra lagersaldot till: ");
                    int nyttAntal;
                    while (!int.TryParse(Console.ReadLine(), out nyttAntal) || nyttAntal < 1)
                    {
                        Console.Write("FEL: Lagersaldot måste skrivas in i siffror och vara större än 0: ");
                    }
                    //Ändrar värdet av egenskapen "Antal".
                    sökProdukt.Antal = nyttAntal;
                    Console.WriteLine("Ändring av lagersaldo lyckades!");
                }
            }
            Console.WriteLine("\nTryck på valfri knapp för att återgå till menyn...");
            Console.ReadKey(true);
            Console.Clear();
        }

        //Ta bort produkt
        public static void TaBortProdukt()
        {
            Console.Clear();
            Console.WriteLine("=== TA BORT PRODUKT ===\n");

            if (Produkt.produkter.Count < 1)
            {
                Console.WriteLine("FEL: Finns inga produkter att ta bort.");
            }
            else
            {

                Console.Write("Sök efter namn på produkten: ");
                string söknamn = Console.ReadLine().ToLower();

                var sökProdukt = Produkt.produkter.FirstOrDefault(x => x.Namn == söknamn);
                if (sökProdukt == null)
                {
                    Console.WriteLine("FEL: Hittade ingen produkt med det namnet.");
                }
                else
                {
                    Console.WriteLine("Hittade produkt:");
                    Console.WriteLine($"\nNamn:{"",-6}| Antal:{"",1} | Pris:{"",2} | Tillgänglig: |");
                    Console.WriteLine(new string('-', 47));
                    Console.WriteLine(sökProdukt);
                    Console.WriteLine(new string('-', 47));

                    //Frågar användaren extra gång om man forfarande vill ta bort eller om man har ångrat sig.
                    Console.Write("\nÄr det säkert att du vill ta bort denna produkt?: ");
                    string svar;
                    while (true)
                    {
                        svar = Console.ReadLine().ToLower();
                        if (svar == "ja")
                        {
                            Produkt.produkter.Remove(sökProdukt);
                            Console.WriteLine("Produkten är nu borttagen.\n");
                            break;
                        }
                        else if (svar == "nej")
                        {
                            Console.WriteLine("ingen produkt har tagits bort.\n");
                            break;
                        }
                        else
                        {
                            Console.Write("FEL: Du kan bara skriva \"Ja\" eller \"Nej\": ");
                        }
                    }
                }
            }
            Console.WriteLine("\nTryck på valfri knapp för att återgå till menyn...");
            Console.ReadKey(true);
            Console.Clear();
        }
    }

    //KLASS
    //Produkt
    public class Produkt
    {
        //LISTA
        //För lagring av produkter
        public static List<Produkt> produkter = new List<Produkt>();

        //PROPERTIES
        //Namn på produkt
        public string Namn { get; set; }
        //Antal på produkt
        public int Antal { get; set; }
        //Pris på produkt
        public int Pris { get; set; }
        //Tillgänglig till försäjning
        public bool Tillgänglig { get; set; }



        //KONSTRUKOTR
        public Produkt(string namn, int antal, int pris, bool tillgänglig)
        {
            Namn = namn;
            Antal = antal;
            Pris = pris;
            Tillgänglig = tillgänglig;
            //Lägger till det skapade objektet i listan produkter.
            produkter.Add(this);
        }

        //Gör en override så det blir lättare att skriva ut produkten till användaren. 
        public override string ToString()
        {
            return $"{Namn,-10} |{Antal,5} st |{Pris,5} kr | {(Tillgänglig ? "Ja" : "Nej"),-12} |";
        }
    }
}
