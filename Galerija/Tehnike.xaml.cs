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
    /// Interaction logic for Tehnike.xaml
    /// </summary>
    public partial class Tehnike : Window
    {
        public Tehnike()
        {
            InitializeComponent();
            PrikaziTehnike();
        }

        private void PrikaziTehnike()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM [Tehnike]";
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("Tehnike");
            dataAdapter.Fill(dataTable);

            DataGridTehnike.ItemsSource = dataTable.DefaultView;
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                txtTehnikaID.Text = dr["TehnikaID"].ToString();
                txtNazivTehnike.Text = dr["NazivTehnike"].ToString();
            }
        }

        private void ponistiUnosTxt()
        {
            txtTehnikaID.Text = "";
            txtNazivTehnike.Text = "";
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtTehnikaID.Text != "" && txtNazivTehnike.Text != "")
                {
                    SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO [Tehnike] (TehnikaID, NazivTehnike) VALUES (@TehnikaID, @NazivTehnike)";
            command.Parameters.AddWithValue("@TehnikaID", txtTehnikaID.Text);
            command.Parameters.AddWithValue("@NazivTehnike", txtNazivTehnike.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o tehnici su uspešno upisani");
                PrikaziTehnike();
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
            command.CommandText = "UPDATE [Tehnike] SET TehnikaID = @TehnikaID, NazivTehnike = @NazivTehnike WHERE TehnikaID = @TehnikaID";
            command.Parameters.AddWithValue("@TehnikaID", txtTehnikaID.Text);
            command.Parameters.AddWithValue("@NazivTehnike", txtNazivTehnike.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o tehnici su uspešno izmenjeni");
                PrikaziTehnike();
            }
            ponistiUnosTxt();
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtTehnikaID.Text != "")
                {
                    SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM [Tehnike] WHERE TehnikaID = @TehnikaID";
            command.Parameters.AddWithValue("@TehnikaID", txtTehnikaID.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o tehnici su uspešno obrisani");
                PrikaziTehnike();
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
