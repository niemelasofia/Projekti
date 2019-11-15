using System;
using System.IO;
using System.Collections.Generic;
using Npgsql;

namespace Projekti
{
    class Program
    {

        static void Main(string[] args)
        {

            
            // yhdistetään tietokantaan:
            var connString = "Host=localhost;Username=postgres;Password=Soofi522;Database=Reseptiarkisto";

            // kun halutaan hakea tietokannasta tietoa:
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open(); // Here we open connection
                             // Here we define our SQL query
                // using (var cmd = new NpgsqlCommand("SELECT * FROM \"reseptit\"", conn)) using (var reader = cmd.ExecuteReader())
                    // Let's loop through all fetched rows
                    // while (reader.Read()) 
                // Let's get the string value in the field 1 Console.WriteLine;(reader.GetString(1));
                // Console.WriteLine(reader.GetString(1));
                // Console.WriteLine();
                // Insert some data
                // using (var cmd = new NpgsqlCommand("INSERT INTO \"reseptit\" (otsikko) VALUES ('Kaalilaatikko')", conn))

                // cmd.ExecuteNonQuery();
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("-------------- RESEPTIARKISTO --------------");
            Console.WriteLine();
            Console.ResetColor();

            int vastaus; // muuttuja vatsuksesta, jotta saadaan se if-lausekkeeseen
            List<Resepti> reseptiLista = new List<Resepti>(); // tehdään resepteistä lista

            do // toistorakenne, jotta saadaan syötettyä useampia reseptejä tai näytettyä reseptit
            {



                Console.WriteLine();
                Console.WriteLine("1 - Syötä resepti"); // valitaan tehtävä toiminto
                Console.WriteLine("2 - Näytä kaikki reseptit");
                Console.WriteLine("3 - Näytä kasvisreseptit");
                Console.WriteLine("4 - Näytä lihareseptit");
                Console.WriteLine("0 - Lopeta");

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Syötä numero: ");
                Console.ResetColor();
                vastaus = int.Parse(Console.ReadLine()); //parsitaan vastaus, jotta voidaan käyttää sitä if-rakenteessa

                if (vastaus == 1) // jos käyttäjä syöttää 1, syötetään reseptin tiedot
                {

                    // Console.Write("Syötä reseptin id: ");
                    // int id = int.Parse(Console.ReadLine());

                    // kun halutaan hakea tietokannasta tietoa:
                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open(); // Here we open connection
                                     // Here we define our SQL query
                                     // using (var cmd = new NpgsqlCommand("SELECT * FROM \"reseptit\"", conn)) using (var reader = cmd.ExecuteReader())
                                     // Let's loop through all fetched rows
                                     // while (reader.Read()) 
                                     // Let's get the string value in the field 1 Console.WriteLine;(reader.GetString(1));
                                     // Console.WriteLine(reader.GetString(1));
                                     // Console.WriteLine();
                                     // Insert some data
                                     // using (var cmd = new NpgsqlCommand("INSERT INTO \"reseptit\" (otsikko) VALUES ('Kaalilaatikko')", conn))

                        // cmd.ExecuteNonQuery();
                    }

                    Console.WriteLine();
                    Console.Write("Syötä reseptin otsikko: ");
                    string otsikko = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Seuraavaksi syötä reseptin ainesosat: määrä, yksikkö ja ainesosa");

                    // kysytään käyttäjältä kaikki reseptiin tarvittavat ainesosat
                    // voi syöttää uuden ainesosan tai siirtyä syöttämään valmistusohjeita
                    int vastaus2;
                    //luodaan lista ainesosista
                    List<Ainesosat> ainesosaLista = new List<Ainesosat>();

                    do  // toistorakenne, jotta voidaan syöttää useampia ainesosia
                    {


                        Console.WriteLine();
                        Console.WriteLine("1 - Lisää uusi ainesosa");
                        Console.WriteLine("2 - Siirry syöttämään valmistusohjeet");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Syötä numero: ");
                        Console.ResetColor();
                        vastaus2 = int.Parse(Console.ReadLine()); //valitaan syötetäänkö uusi ainesosa vai siirrytäänkö syöttämään valmistusohjeet

                        if (vastaus2 == 1)
                        {

                            Console.WriteLine();
                            Console.Write("Syötä ainesosa: ");
                            string ainesosa = Console.ReadLine();

                            Console.Write("Syötä ainesosan määrä: ");
                            double maara = double.Parse(Console.ReadLine());

                            Console.Write("Syötä ainesosan määrän yksikkö: ");
                            string yksikko = Console.ReadLine();

                            Ainesosat uusiAinesosa = new Ainesosat(maara, yksikko, ainesosa);

                            ainesosaLista.Add(uusiAinesosa);

                        }
                        else if (vastaus2 > 2)

                        {
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Virheellinen arvo, syötä uudestaan");
                            Console.ResetColor();
                        }


                    } while (vastaus2 == 1 || vastaus2 > 2); // ohjelma toistetaan aina, jos vastaus on 1, eli käyttäjä haluaa syöttää vielä uuden ainesosan

                    Console.WriteLine();
                    Console.Write("Syötä reseptin valmistusohjeet: ");
                    string valmistusohjeet = Console.ReadLine();

                    Console.Write("Syötä valmistusaika minuutteina: ");
                    int valmistusaika = int.Parse(Console.ReadLine());

                    Console.Write("Syötä reseptin tyyppi (aamupala, välipala, lounas, päivällinen, jälkiruoka, leivonnainen): ");
                    string tyyppi = Console.ReadLine();

                    Console.Write("Syötä reseptin annosmäärä: ");
                    int annokset = int.Parse(Console.ReadLine());

                    Console.Write("Onko resepti kasvisruoka (true/false): ");
                    bool kasvisruoka = bool.Parse(Console.ReadLine());
                    Console.WriteLine();

                    Resepti uusiResepti = new Resepti(otsikko, valmistusohjeet, valmistusaika, tyyppi, annokset, kasvisruoka);

                    reseptiLista.Add(uusiResepti);

                    Console.WriteLine($"Uusi resepti { uusiResepti.GetOtsikko() } luotu.");
                    Console.WriteLine();

                }
                else if (vastaus == 2)

                {


                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine();
                    Console.WriteLine("----------------- RESEPTIT -----------------");
                    Console.WriteLine();
                    Console.ResetColor();

                    // Console.WriteLine(item.GetOtsikko());
                    // Console.WriteLine();


                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open(); // avataan yhteys
                        // määritellään SQL haku
                        using (var cmd = new NpgsqlCommand("SELECT * FROM \"reseptit\"", conn)) using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        Console.WriteLine(reader.GetString(1));
                        Console.WriteLine();
                    }

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("--------------------------------------------");
                    Console.ResetColor();

                }

                else if (vastaus == 3)

                {


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine("-------------- KASVISRESEPTIT --------------");
                    Console.WriteLine();
                    Console.ResetColor();

                    // Console.WriteLine(item.GetOtsikko());
                    // Console.WriteLine();


                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open(); // avataan yhteys
                        // määritellään SQL haku
                        using (var cmd = new NpgsqlCommand("SELECT * FROM \"reseptit\" WHERE kasvisruoka=true", conn)) using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        Console.WriteLine(reader.GetString(1));
                        Console.WriteLine();
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("--------------------------------------------");
                    Console.ResetColor();

                }

                else if (vastaus == 4)

                {


                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("--------------- LIHARESEPTIT ---------------");
                    Console.WriteLine();
                    Console.ResetColor();

                    // Console.WriteLine(item.GetOtsikko());
                    // Console.WriteLine();


                    using (var conn = new NpgsqlConnection(connString))
                    {
                        conn.Open(); // avataan yhteys
                        // määritellään SQL haku
                        using (var cmd = new NpgsqlCommand("SELECT * FROM \"reseptit\" WHERE kasvisruoka=false", conn)) using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        Console.WriteLine(reader.GetString(1));
                        Console.WriteLine();
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("--------------------------------------------");
                    Console.ResetColor();

                }
                else

                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Virheellinen arvo, syötä uudestaan");
                    Console.ResetColor();
                }


            } while (vastaus > 0); // koko ohjelma toistetaan aina, jos vastaus on 1 tai 2 tai suurempi, ja lopetetaan jos vastaus on 0

            // ohjelma kysyy uudestaan, syötetäänkö resepti vai näytetäänkö kaikki reseptit vai lopetetaanko ohjelma
                

            
            
          






        }
    }
}
