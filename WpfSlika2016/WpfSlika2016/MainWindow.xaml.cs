using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSlika2016
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OsobaDal oDal = new OsobaDal();
        private string slikaIzvor = "";
        private void prikazi()
        {
            dataGrid1.Items.Clear();
            List<Osoba> listaOsoba = oDal.VratiOsobe();
            foreach (Osoba o in listaOsoba)
            {
                dataGrid1.Items.Add(o);
            }
            //dataGrid1.Items.Refresh();
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            prikazi();
        }
        private void resetuj()//metoda za resetovanje korisnickog interface-a
        {

            TextBoxId.Clear();
            TextBoxIme.Clear();
            TextBoxPrezime.Clear();
            RadioMale.IsChecked = true;
            image1.Source = null;
            dataGrid1.SelectedIndex = -1;
            slikaIzvor = "";//ponistava se izvor slike sa kojom smoranije radili
        }

        private void ButtonOdaberi_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
            if (openDlg.ShowDialog() == true)
            {
                slikaIzvor = openDlg.FileName;
                Uri adresa = new Uri(slikaIzvor, UriKind.Absolute);
                BitmapImage slika = new BitmapImage(adresa);
                image1.Source = slika;
            }
        }

        private void ButtonNovi_Click(object sender, RoutedEventArgs e)
        {
            resetuj();
        }

        private void ButtonUbaci_Click(object sender, RoutedEventArgs e)
        {
            if (!Validacija())
            {
                return;
            }
            //mora se i slika odabrati
            if (string.IsNullOrWhiteSpace(slikaIzvor))
            {
                MessageBox.Show("Morate odabrati sliku");
                return;
            }
            string slikaOdrediste = KreirajOdrediste(slikaIzvor);
            Osoba os = new Osoba();
            os.Ime = TextBoxIme.Text;
            os.Prezime = TextBoxPrezime.Text;
            os.Pol = RadioFMale.IsChecked.Value;
            os.Slika = System.IO.Path.GetFileName(slikaOdrediste);
            int rez = oDal.UbaciOsobu(os);
            if (rez == 0)
            {
                File.Copy(slikaIzvor, slikaOdrediste);
                prikazi();
                dataGrid1.Focus();
                int indeks = dataGrid1.Items.Count - 1;
                dataGrid1.SelectedIndex = indeks;
                dataGrid1.ScrollIntoView(dataGrid1.Items[indeks]);
                slikaIzvor = "";
                MessageBox.Show("Ubacena nova osoba");
            }
        }

        private void ButtonPromijeni_Click(object sender, RoutedEventArgs e)
        {
            int indeks = dataGrid1.SelectedIndex;
            if (indeks < 0)
            {
                return;
            }
            if (!Validacija())
            {
                return;
            }
            Osoba os = (Osoba)dataGrid1.SelectedItem;
            os.Ime = TextBoxIme.Text;
            os.Prezime = TextBoxPrezime.Text;
            os.Pol = RadioFMale.IsChecked.Value;
            string slikaOdrediste = "";
            if (slikaIzvor != "")
            {
                // menjamo sliku
                slikaOdrediste = KreirajOdrediste(slikaIzvor);
                os.Slika = System.IO.Path.GetFileName(slikaOdrediste);
            }
            int rez = oDal.PromeniOsobu(os);
            if (rez == 0)
            {
                if (slikaIzvor != "")
                {
                    // promenjena slika
                    File.Copy(slikaIzvor, slikaOdrediste);
                }
                prikazi();
                dataGrid1.Focus();
                dataGrid1.SelectedIndex = indeks;
                dataGrid1.ScrollIntoView(dataGrid1.Items[indeks]);
                slikaIzvor = "";
                MessageBox.Show("Podaci promenjeni");
            }
            else
            {
                MessageBox.Show("Greska pri promeni");
            }
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            int indeks = dataGrid1.SelectedIndex;
            if (indeks < 0)
            {
                return;
            }
            Osoba os = (Osoba)dataGrid1.SelectedItem;
            int rez = oDal.ObrisiOsobu(os);
            if (rez == 0)
            {
                prikazi();
                resetuj();
                MessageBox.Show("Osoba obrisana");
                string slika = VratiPutanju(os.Slika);
                try
                {
                    File.Delete(slika);
                }
                catch (Exception xcp)
                {
                    MessageBox.Show(xcp.Message);
                }
            }
        }

        public bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(TextBoxIme.Text))
            {
                MessageBox.Show("Morate uneti ime");
                TextBoxIme.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(TextBoxPrezime.Text))
            {
                MessageBox.Show("Morate uneti prezime");
                TextBoxIme.Focus();
                return false;
            }
            return true;
        }
        public string VratiPutanju(string slika)
        {
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory());
            DirectoryInfo root = di.Parent.Parent;
            return System.IO.Path.Combine(root.FullName, "Slike", slika);
        }
        public string KreirajOdrediste(string slikaIzvor)
        {
            string Slika1 = System.IO.Path.GetFileName(slikaIzvor);
            string slikaOdrediste = VratiPutanju(Slika1);
            string imeBezEkstenzije = System.IO.Path.GetFileNameWithoutExtension(slikaOdrediste);
            string ekstenzija = System.IO.Path.GetExtension(slikaOdrediste);
            int brojac = 0;
            //ako postoji slika sa istim imenom:
            while (File.Exists(slikaOdrediste))
            {
                brojac++;
                slikaOdrediste = VratiPutanju(imeBezEkstenzije + brojac + ekstenzija);
            }
            return slikaOdrediste;
        }


        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid1.SelectedIndex > -1)
            {
                slikaIzvor = "";
                Osoba o = (Osoba)dataGrid1.SelectedItem;
                TextBoxId.Text = o.OsobaId.ToString();
                TextBoxIme.Text = o.Ime;
                TextBoxPrezime.Text = o.Prezime;

                if (o.Pol)
                {
                    RadioFMale.IsChecked = true;
                }
                else
                {
                    RadioMale.IsChecked = true;
                }
                string slikaOdrediste = VratiPutanju(o.Slika);
                Uri adresa = new Uri(slikaOdrediste, UriKind.Absolute);
                BitmapImage slika = new BitmapImage(adresa);
                image1.Source = slika;
            }
        }

    }
}
