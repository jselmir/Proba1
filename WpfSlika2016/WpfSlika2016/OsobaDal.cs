using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace WpfSlika2016
{
    class OsobaDal
    {
        public List<Osoba>VratiOsobe()
        {
            List<Osoba> listaOsoba = new List<Osoba>();
            SqlConnection konekcija = Konekcija.kreirajKonekciju();
            SqlCommand komanda = new SqlCommand("SELECT * FROM Osoba", konekcija);

            try
            {
                konekcija.Open();
                SqlDataReader dr = komanda.ExecuteReader();
                while (dr.Read())
                {
                    Osoba o = new Osoba();
                    o.OsobaId = dr.GetInt32(0);
                    o.Ime = dr.GetString(1);
                    o.Prezime = dr.GetString(2);
                    o.Pol = dr.GetBoolean(3);
                    o.Slika = dr.GetString(4);
                    listaOsoba.Add(o);
                }
                return listaOsoba;
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return null;
            }
            finally
            {
                konekcija.Close();
            }
        }

        public int UbaciOsobu(Osoba o)
        {
            SqlConnection konekcija = Konekcija.kreirajKonekciju();
            string upit = "INSERT INTO Osoba VALUES (@Ime, @Prezime, @Pol, @Slika)";
            SqlCommand komanda = new SqlCommand(upit, konekcija);
            komanda.Parameters.AddWithValue("@Ime", o.Ime);
            komanda.Parameters.AddWithValue("@Prezime", o.Prezime);
            komanda.Parameters.AddWithValue("@Pol", o.Pol);
            komanda.Parameters.AddWithValue("@Slika", o.Slika);
            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();
                return 0;
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return -1;
            }
            finally
            {
                konekcija.Close();
            }
        }

        public int PromeniOsobu(Osoba o)
        {
            SqlConnection konekcija = Konekcija.kreirajKonekciju();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("UPDATE Osoba");
            sb.AppendLine("SET Ime=@Ime,");
            sb.AppendLine("Prezime=@Prezime,");
            sb.AppendLine("Pol=@Pol,");
            sb.AppendLine("Slika=@Slika");
            sb.AppendLine("WHERE (OsobaId=@OsobaId)");
            SqlCommand komanda = new SqlCommand(sb.ToString(), konekcija);
            komanda.Parameters.AddWithValue("@Ime", o.Ime);
            komanda.Parameters.AddWithValue("@Prezime", o.Prezime);
            komanda.Parameters.AddWithValue("@Pol", o.Pol);
            komanda.Parameters.AddWithValue("@Slika", o.Slika);
            komanda.Parameters.AddWithValue("@OsobaId", o.OsobaId);
            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();
                return 0;
            }
            catch (Exception xcp)
            {
                MessageBox.Show(xcp.Message);
                return -1;
            }
            finally
            {
                konekcija.Close();
            }
        }

        public int ObrisiOsobu(Osoba o)
        {
            SqlConnection konekcija = Konekcija.kreirajKonekciju();
            SqlCommand komanda = new SqlCommand("DELETE FROM Osoba WHERE OsobaId=@OsobaId", konekcija);
            komanda.Parameters.AddWithValue("@OsobaId", o.OsobaId);
            try
            {
                konekcija.Open();
                komanda.ExecuteNonQuery();
                return 0;
            }
            catch
            {
                return -1;
            }
            finally
            {
                konekcija.Close();
            }

        }
    }
}
