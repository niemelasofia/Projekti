using System;
namespace Projekti
{
    public class Aamupala

    {
        private string otsikkoAamupala;
        private string aineksetAamupala;
        private string kuvausAamupala;

        public Aamupala(string otsikkoAamupala)
        {
            this.otsikkoAamupala = otsikkoAamupala;
        }

        public string GetOtsikkoAamupala()
        {
            return otsikkoAamupala;
        }

    }
}
