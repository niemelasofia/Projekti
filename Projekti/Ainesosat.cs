using System;
namespace Projekti
{
    public class Ainesosat
    {
        private double _maara;
        private string _yksikko;
        private string _ainesosa;

        public Ainesosat(double maara, string yksikko, string ainesosa)
        {
            _maara = maara;
            _yksikko = yksikko;
            _ainesosa = ainesosa;
        }

        public double GetMaara()
        {
            return _maara;
        }

        public string GetYksikko()
        {
            return _yksikko;
        }

        public string GetAinesosa()
        {
            return _ainesosa;
        }
    }
}
