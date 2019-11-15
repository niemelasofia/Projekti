using System;
using System.Collections.Generic;
using System.Text;

namespace Projekti
{
    public class Resepti
    {

        // resepti-luokka, josta luodaan eri reseptioliot, esim. kinkkukiusaus, marjapuuro jne

        private string _otsikko;            // reseptin otsikko
        private string _valmistusOhjeet;    // valmistusohjeet 1. tehdään näin 2. sitten näin
        private int _valmistusAika;           // miten luodaan?
        private string _tyyppi;             // aamupala, lounas, välipala, päivällinen, jälkiruoka, leivonnainen
        private int _annokset;              // kuinka monta annosta tästä reseptistä saadaan, esim. 4
        private bool _kasvisruoka;          // onko ruoka kasvisruoka, vastaus true tai false, luokitellaan reseptit tämän perusteella kasvis- ja liharuokiin


        // konstruktori, nämä arvot annetaan pääohjelman puolella, kun luodaan uusi olio:

        public Resepti(string otsikko, string valmistusOhjeet, int valmistusAika, string tyyppi, int annokset, bool kasvisruoka)
        {
            _otsikko = otsikko;
            _valmistusOhjeet = valmistusOhjeet;
            _valmistusAika = valmistusAika;
            _tyyppi = tyyppi;
            _annokset = annokset;
            _kasvisruoka = kasvisruoka;
        }

        // haetaan otsikko pääohjelmasta:

        public string GetOtsikko()
        {
            return _otsikko;
        }

        public string GetValmistusOhjeet()
        {
            return _valmistusOhjeet;
        }

        public int GetValmistusAika()
        {
            return _valmistusAika;
        }

        public string GetTyyppi()
        {
            return _tyyppi;
        }

        public int GetAnnokset()
        {
            return _annokset;
        }

        public bool GetKasvisruoka()
        {
            return _kasvisruoka;
        }
    }
}
