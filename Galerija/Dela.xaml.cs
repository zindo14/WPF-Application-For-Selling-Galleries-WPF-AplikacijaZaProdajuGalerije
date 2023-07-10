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
    /// Interaction logic for Dela.xaml
    /// </summary>
    public partial class Dela : Window
    {
        public Dela()
        {
            InitializeComponent();
            PrikaziDela();
        }

        private void PrikaziDela()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM [Dela]";
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("Dela");
            dataAdapter.Fill(dataTable);

            DataGridIzlozba.ItemsSource = dataTable.DefaultView;
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDelaID.Text != "" && txtNaziv.Text != "" && txtVisinaDela.Text != "" && txtSirinaDela.Text != "" && GodinaNastanka.Text != "" && txtAutor.Text != "" && txtTehnika.Text != "" && txtPotpis.Text != "" && txtPrikazDela.Text != "" && txtOpis.Text != "")
                {
                    SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            DateTime datumN = Convert.ToDateTime(GodinaNastanka.Text);
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO [Dela] (DelaID, Naziv, VisinaDela, SirinaDela, GodinaNastankaDela,AutorID,TehnikaID,Potpis,PrikazDela,Opis) VALUES (@DelaID, @Naziv, @VisinaDela, @SirinaDela, @GodinaNastankaDela, @AutorID, @TehnikaID, @Potpis, @PrikazDela, @Opis)";
            command.Parameters.AddWithValue("@DelaID", txtDelaID.Text);
            command.Parameters.AddWithValue("@Naziv", txtNaziv.Text);
            command.Parameters.AddWithValue("@VisinaDela", txtVisinaDela.Text);
            command.Parameters.AddWithValue("@SirinaDela", txtSirinaDela.Text);
            command.Parameters.AddWithValue("@GodinaNastankaDela", datumN);
            command.Parameters.AddWithValue("@AutorID", txtAutor.Text);
            command.Parameters.AddWithValue("@TehnikaID", txtTehnika.Text);
            command.Parameters.AddWithValue("@Potpis", txtPotpis.Text);
            command.Parameters.AddWithValue("@PrikazDela", txtPrikazDela.Text);
            command.Parameters.AddWithValue("@Opis", txtOpis.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o delu su uspešno upisani");
                PrikaziDela();
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

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                txtDelaID.Text = dr["DelaID"].ToString();
                txtNaziv.Text = dr["Naziv"].ToString();
                txtVisinaDela.Text = dr["VisinaDela"].ToString();
                txtSirinaDela.Text = dr["SirinaDela"].ToString();
                GodinaNastanka.Text = dr["GodinaNastankaDela"].ToString();
                txtAutor.Text = dr["AutorID"].ToString();
                txtTehnika.Text = dr["TehnikaID"].ToString();
                txtPotpis.Text = dr["Potpis"].ToString();
                txtPrikazDela.Text = dr["PrikazDela"].ToString();
                txtOpis.Text = dr["Opis"].ToString();
            }
        }
        private void ponistiUnosTxt()
        {
            txtDelaID.Text = "";
            txtNaziv.Text = "";
            txtVisinaDela.Text = "";
            txtSirinaDela.Text = "";
            GodinaNastanka.Text = "";
            txtAutor.SelectedItem = "";
            txtTehnika.SelectedItem = "";
            txtPotpis.Text = "";
            txtPrikazDela.Text = "";
            txtOpis.Text = "";
        }

        private void ButtonIzmeni_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            DateTime datumN = Convert.ToDateTime(GodinaNastanka.Text);
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE [Dela] SET DelaID = @DelaID, Naziv = @Naziv, VisinaDela = @VisinaDela, SirinaDela = @SirinaDela, GodinaNastankaDela = @GodinaNastankaDela, AutorID = @AutorID, TehnikaID = @TehnikaID, Potpis = @Potpis, PrikazDela = @PrikazDela, Opis = @Opis WHERE DelaID = @DelaID";
            command.Parameters.AddWithValue("@DelaID", txtDelaID.Text);
            command.Parameters.AddWithValue("@Naziv", txtNaziv.Text);
            command.Parameters.AddWithValue("@VisinaDela", txtVisinaDela.Text);
            command.Parameters.AddWithValue("@SirinaDela", txtSirinaDela.Text);
            command.Parameters.AddWithValue("@GodinaNastankaDela", datumN);
            command.Parameters.AddWithValue("@AutorID", txtAutor.Text);
            command.Parameters.AddWithValue("@TehnikaID", txtTehnika.Text);
            command.Parameters.AddWithValue("@Potpis", txtPotpis.Text);
            command.Parameters.AddWithValue("@PrikazDela", txtPrikazDela.Text);
            command.Parameters.AddWithValue("@Opis", txtOpis.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o delu su uspešno izmenjeni");
                PrikaziDela();
            }
            ponistiUnosTxt();
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtDelaID.Text != "")
                {
                    SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM [Dela] WHERE DelaID = @DelaID";
            command.Parameters.AddWithValue("@DelaID", txtDelaID.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o delu su uspešno obrisani");
                PrikaziDela();
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

        private void txtAutor_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand commandCb = new SqlCommand();
            commandCb.CommandText = "SELECT * FROM [Autori] ORDER BY AutorID";
            commandCb.Connection = connection;
            SqlDataAdapter dataAdapterCb = new SqlDataAdapter(commandCb);
            DataTable dataTableCb = new DataTable("Dela");
            dataAdapterCb.Fill(dataTableCb);

            for (int i = 0; i < dataTableCb.Rows.Count; i++)
            {
                txtAutor.Items.Add(dataTableCb.Rows[i]["AutorID"]);
            }
        }

        private void txtTehnika_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand commandCb = new SqlCommand();
            commandCb.CommandText = "SELECT * FROM [Tehnike] ORDER BY TehnikaID";
            commandCb.Connection = connection;
            SqlDataAdapter dataAdapterCb = new SqlDataAdapter(commandCb);
            DataTable dataTableCb = new DataTable("Dela");
            dataAdapterCb.Fill(dataTableCb);

            for (int i = 0; i < dataTableCb.Rows.Count; i++)
            {
                txtTehnika.Items.Add(dataTableCb.Rows[i]["TehnikaID"]);
            }
        }

        private void txtAutor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
