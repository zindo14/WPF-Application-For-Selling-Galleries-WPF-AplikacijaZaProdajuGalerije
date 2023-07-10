using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace Galerija
{
    /// <summary>
    /// Interaction logic for Klijenti.xaml
    /// </summary>
    public partial class Klijenti : Window
    {
        public Klijenti()
        {
            InitializeComponent();
            PrikaziKlijenta();
        }

        private void PrikaziKlijenta()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM [Klijenti]";
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("Klijenti");
            dataAdapter.Fill(dataTable);

            DataGridKlijenti.ItemsSource = dataTable.DefaultView;
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                txtKlijentID.Text = dr["KlijentID"].ToString();
                txtKlijentKupac.Text = dr["KlijentKupac"].ToString();
                txtKlijentProdavac.Text = dr["KlijentProdavac"].ToString();
                txtnaziv.Text = dr["Naziv"].ToString();
                txtIme.Text = dr["Ime"].ToString();
                txtPrezime.Text = dr["Prezime"].ToString();
                txtAdresa.Text = dr["Adresa"].ToString();
                txtTelefon.Text = dr["Telefon"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtNapomena.Text = dr["Napomena"].ToString();
            }
        }

        private void ponistiUnosTxt()
        {
            txtKlijentID.Text = "";
            txtKlijentKupac.Text = "";
            txtKlijentProdavac.Text = "";
            txtnaziv.Text = "";
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtAdresa.Text = "";
            txtTelefon.Text = "";
            txtEmail.Text = "";
            txtNapomena.Text = "";
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtKlijentID.Text != "" && txtKlijentKupac.Text != "" && txtKlijentProdavac.Text != "" && txtnaziv.Text != "" && txtIme.Text != "" && txtPrezime.Text != "" && txtAdresa.Text != "" && txtTelefon.Text != "" && txtEmail.Text != "" && txtNapomena.Text != "")
                {
                    SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO [Klijenti] (KlijentID,KlijentKupac,KlijentProdavac,Naziv,Ime,Prezime,Adresa,Telefon,Email,Napomena) VALUES (@KlijentID,@KlijentKupac,@KlijentProdavac,@Naziv,@Ime,@Prezime,@Adresa,@Telefon,@Email,@Napomena)";
            command.Parameters.AddWithValue("@KlijentID", txtKlijentID.Text);
            command.Parameters.AddWithValue("@KlijentKupac", txtKlijentKupac.Text);
            command.Parameters.AddWithValue("@KlijentProdavac", txtKlijentProdavac.Text);
            command.Parameters.AddWithValue("@Naziv", txtnaziv.Text);
            command.Parameters.AddWithValue("@Ime", txtIme.Text);
            command.Parameters.AddWithValue("@Prezime", txtPrezime.Text);
            command.Parameters.AddWithValue("@Adresa", txtAdresa.Text);
            command.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
            command.Parameters.AddWithValue("@Email", txtEmail.Text);
            command.Parameters.AddWithValue("@Napomena", txtNapomena.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o klijentu su uspešno upisani");
                PrikaziKlijenta();
            }
            ponistiUnosTxt();
                }
                else
                { MessageBox.Show("Popunite sva polja!"); }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 1062 || ex.Number == 1064)
                    MessageBox.Show("Sifra vec postoji");
                else
                    MessageBox.Show("Greska");
            }
        }

        private void ButtonIzmeni_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE [Klijenti] SET KlijentID = @KlijentID,KlijentKupac = @KlijentKupac,KlijentProdavac = @KlijentProdavac,Naziv = @Naziv,Ime = @Ime,Prezime = @Prezime,Adresa = @Adresa,Telefon = @Telefon,Email = @Email,Napomena = @Napomena WHERE KlijentID = KlijentID";
            command.Parameters.AddWithValue("@KlijentID", txtKlijentID.Text);
            command.Parameters.AddWithValue("@KlijentKupac", txtKlijentKupac.Text);
            command.Parameters.AddWithValue("@KlijentProdavac", txtKlijentProdavac.Text);
            command.Parameters.AddWithValue("@Naziv", txtnaziv.Text);
            command.Parameters.AddWithValue("@Ime", txtIme.Text);
            command.Parameters.AddWithValue("@Prezime", txtPrezime.Text);
            command.Parameters.AddWithValue("@Adresa", txtAdresa.Text);
            command.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
            command.Parameters.AddWithValue("@Email", txtEmail.Text);
            command.Parameters.AddWithValue("@Napomena", txtNapomena.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o klijentu su uspešno izmenjeni");
                PrikaziKlijenta();
            }
            ponistiUnosTxt();
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtKlijentID.Text != "")
                {
                    SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM [Klijenti] WHERE KlijentID = KlijentID";
            command.Parameters.AddWithValue("@KlijentID", txtKlijentID.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o klijentu su uspešno obrisani");
                PrikaziKlijenta();
            }
            ponistiUnosTxt();
        }
                else
                { MessageBox.Show("Popunite sva polja!"); }
}
            catch (SqlException ex)
{
    if (ex.Number == 1062 || ex.Number == 1064)
        MessageBox.Show("Sifra vec postoji");
    else
        MessageBox.Show("Greska");
}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
