using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Limberger_Buchbeispiel
{
    class Buch: IComparable<Buch>
    {
        public string Autor { get; set; }
        public string Titel { get; set; }
        public Verlag Verlag { get; set; }
        public int Jahr { get; set; }
        public string ISBNNummer { get; set; }
        public double Preis { get; set; }

        public Buch(string Autor, string Titel, int Jahr, string ISBNNummer, Verlag Verlag, int Preis)
        {
            this.Autor = Autor;
            this.Titel = Titel;
            this.Jahr = Jahr;
            this.ISBNNummer = ISBNNummer;
            this.Verlag = Verlag;
            this.Preis = Preis;
        }

        public int CompareTo(Buch buch)
        {
            if (buch == null) return 1;
            return Titel.CompareTo(buch.Titel);
        }

        public override string ToString()
        {
            return String.Format("Autor : " + Autor + ", Titel : " + Titel + ", Verlag : " + Verlag + ", Jahr : " + Jahr + ", ISB-Nummer : " + ISBNNummer);
        }

        public bool CheckISBNNummber(string ISBNNummer)
        {
            string regextext = ISBNNummer;
            string RegexSearchISBN = "^(97[8-9]-[0-9]-[0-9]{2,4}-[0-9]{2,6}-[0-9]{1})$";
            Regex re = new Regex(@RegexSearchISBN);

            if (re.IsMatch(ISBNNummer))
            {
                return CheckPruefziffer(ISBNNummer);
            }
            return false;
        }

        public void CheckISBN()
        {
            if (CheckISBNNummber(ISBNNummer))
            {
            }
            else
            {
                InvalidISBNException IIEx = new InvalidISBNException(ISBNNummer);
                throw (IIEx);
            }
        }

        public bool CheckPruefziffer(string ISBNNummer)
        {
            int summe = 0;
            int ziffer = 0;

            ISBNNummer = Regex.Replace(ISBNNummer, "-", "");
            ISBNNummer = ISBNNummer;

            for (int i = 0; i < ISBNNummer.Length - 1; i++)
            {
                if (ISBNNummer[i] != '-' && ISBNNummer[i] != ' ')
                {
                    ziffer = Convert.ToInt32(Char.GetNumericValue(ISBNNummer, i));
                    if (i % 2 == 0)
                    {
                        summe += ziffer * 1;
                    }
                    else
                    {
                        summe += ziffer * 3;
                    }
                }
            }

            int pruefziffer = Convert.ToInt32(Char.GetNumericValue(ISBNNummer, ISBNNummer.Length - 1));

            //Console.WriteLine(((10 - (summe % 10)) % 10).ToString() + " / " + pruefziffer );

            int berechnung = ((10 - (summe % 10)) % 10);


            if (berechnung == pruefziffer)
            {
                return true;
            }

            return false;
        }
    }
}

