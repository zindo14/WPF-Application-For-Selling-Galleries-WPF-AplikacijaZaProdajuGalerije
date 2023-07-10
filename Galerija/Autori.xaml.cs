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
    /// Interaction logic for Autori.xaml
    /// </summary>
    public partial class Autori : Window
    {
        public Autori()
        {
            InitializeComponent();
            PrikaziAutora();
        }

        private void PrikaziAutora()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM [Autori]";
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("Autori");
            dataAdapter.Fill(dataTable);

            DataGridIzlozba.ItemsSource = dataTable.DefaultView;
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                txtAutorID.Text = dr["AutorID"].ToString();
                txtIme.Text = dr["Ime"].ToString();
                txtPrezime.Text = dr["Prezime"].ToString();
                GodinaRodjenja.Text = dr["GodinaRodjenja"].ToString();
                GodinaSmrti.Text = dr["GodinaSmrti"].ToString();
                txtBiografija.Text = dr["Biografija"].ToString();
            }
        }

        private void ponistiUnosTxt()
        {
            txtAutorID.Text = "";
            txtIme.Text = "";
            txtPrezime.Text = "";
            GodinaRodjenja.Text = "";
            GodinaSmrti.Text = "";
            txtBiografija.Text = "";
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAutorID.Text != "" && txtIme.Text != "" && txtPrezime.Text != "" && GodinaRodjenja.Text != "" && GodinaSmrti.Text != "" && txtBiografija.Text != "")
                {
                    SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            DateTime datumR = Convert.ToDateTime(GodinaRodjenja.Text);
            DateTime datumS = Convert.ToDateTime(GodinaSmrti.Text);
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO [Autori] (AutorID, Ime, Prezime, GodinaRodjenja, GodinaSmrti, Biografija) VALUES (@AutorID, @Ime, @Prezime, @GodinaRodjenja, @GodinaSmrti, @Biografija)";
            command.Parameters.AddWithValue("@AutorID", txtAutorID.Text);
            command.Parameters.AddWithValue("@Ime", txtIme.Text);
            command.Parameters.AddWithValue("@Prezime", txtPrezime.Text);
            command.Parameters.AddWithValue("@GodinaRodjenja", datumR);
            command.Parameters.AddWithValue("@GodinaSmrti", datumS);
            command.Parameters.AddWithValue("@Biografija", txtBiografija.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o autoru su uspešno uneti");
                PrikaziAutora();
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
            DateTime datumR = Convert.ToDateTime(GodinaRodjenja.Text);
            DateTime datumS = Convert.ToDateTime(GodinaSmrti.Text);
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE [Autori] SET AutorID = @AutorID, Ime = @Ime, Prezime = @Prezime, GodinaRodjenja = @GodinaRodjenja, GodinaSmrti = @GodinaSmrti, Biografija = @Biografija WHERE AutorID = @AutorID";
            command.Parameters.AddWithValue("@AutorID", txtAutorID.Text);
            command.Parameters.AddWithValue("@Ime", txtIme.Text);
            command.Parameters.AddWithValue("@Prezime", txtPrezime.Text);
            command.Parameters.AddWithValue("@GodinaRodjenja", datumR);
            command.Parameters.AddWithValue("@GodinaSmrti", datumS);
            command.Parameters.AddWithValue("@Biografija", txtBiografija.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o autoru su uspešno izmenjeni");
                PrikaziAutora();
            }
            ponistiUnosTxt();
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAutorID.Text != "")
                {
                    SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM [Autori] WHERE AutorID = @AutorID";
            command.Parameters.AddWithValue("@AutorID", txtAutorID.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o autoru su uspešno izbrisani");
                PrikaziAutora();
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
