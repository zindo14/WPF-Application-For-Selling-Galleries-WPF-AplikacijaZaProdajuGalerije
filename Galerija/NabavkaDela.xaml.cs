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
    /// Interaction logic for NabavkaDela.xaml
    /// </summary>
    public partial class NabavkaDela : Window
    {
        public NabavkaDela()
        {
            InitializeComponent();
            PrikaziNabavkeDela();
        }

        private void PrikaziNabavkeDela()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM [NabavkaDela]";
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("NabavkaDela");
            dataAdapter.Fill(dataTable);

            DataGridNabavkaDela.ItemsSource = dataTable.DefaultView;
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                txtBrojNabavke.Text = dr["BrojNabavke"].ToString();
                DatumNabavke.Text = dr["DatumNabavke"].ToString();
                txtCenaNabavke.Text = dr["CenaNabavke"].ToString();
                txtDelaID.Text = dr["DelaID"].ToString();
                txtKlijentID.Text = dr["KlijentID"].ToString();
            }
        }

        private void ponistiUnosTxt()
        {
            txtBrojNabavke.Text = "";
            DatumNabavke.Text = "";
            txtCenaNabavke.Text = "";
            txtDelaID.Text = "";
            txtKlijentID.Text = "";
        }

        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtBrojNabavke.Text != "" && DatumNabavke.Text != "" && txtCenaNabavke.Text != "" && txtDelaID.Text != "" && txtKlijentID.Text != "")
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
                    connection.Open();
                    DateTime datumpp = Convert.ToDateTime(DatumNabavke.Text);
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "INSERT INTO [NabavkaDela] (BrojNabavke,DatumNabavke,CenaNabavke,DelaID,KlijentID) VALUES (@BrojNabavke,@DatumNabavke,@CenaNabavke,@DelaID,@KlijentID)";
                    command.Parameters.AddWithValue("@BrojNabavke", txtBrojNabavke.Text);
                    command.Parameters.AddWithValue("@DatumNabavke", datumpp);
                    command.Parameters.AddWithValue("@CenaNabavke", txtCenaNabavke.Text);
                    command.Parameters.AddWithValue("@DelaID", txtDelaID.Text);
                    command.Parameters.AddWithValue("@KlijentID", txtKlijentID.Text);
                    command.Connection = connection;
                    int provera = command.ExecuteNonQuery();
                    if (provera == 1)
                    {
                        MessageBox.Show("Podaci o nabavki delova su uspešno upisani");
                        PrikaziNabavkeDela();
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
            DateTime datumpp = Convert.ToDateTime(DatumNabavke.Text);
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE [NabavkaDela] SET BrojNabavke = @BrojNabavke,DatumNabavke = @DatumNabavke,CenaNabavke = @CenaNabavke,DelaID = @DelaID,KlijentID = @KlijentID WHERE BrojNabavke = @BrojNabavke";
            command.Parameters.AddWithValue("@BrojNabavke", txtBrojNabavke.Text);
            command.Parameters.AddWithValue("@DatumNabavke", datumpp);
            command.Parameters.AddWithValue("@CenaNabavke", txtCenaNabavke.Text);
            command.Parameters.AddWithValue("@DelaID", txtDelaID.Text);
            command.Parameters.AddWithValue("@KlijentID", txtKlijentID.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o nabavki delova su uspešno izmenjeni");
                PrikaziNabavkeDela();
            }
            ponistiUnosTxt();
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtBrojNabavke.Text != "")
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "DELETE FROM [NabavkaDela] WHERE BrojNabavke = @BrojNabavke";
                    command.Parameters.AddWithValue("@BrojNabavke", txtBrojNabavke.Text);
                    command.Connection = connection;
                    int provera = command.ExecuteNonQuery();
                    if (provera == 1)
                    {
                        MessageBox.Show("Podaci o nabavki delova su uspešno obrisani");
                        PrikaziNabavkeDela();
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

        private void txtDelaID_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand commandCb = new SqlCommand();
            commandCb.CommandText = "SELECT * FROM [Dela] ORDER BY DelaID";
            commandCb.Connection = connection;
            SqlDataAdapter dataAdapterCb = new SqlDataAdapter(commandCb);
            DataTable dataTableCb = new DataTable("Dela");
            dataAdapterCb.Fill(dataTableCb);

            for (int i = 0; i < dataTableCb.Rows.Count; i++)
            {
                txtDelaID.Items.Add(dataTableCb.Rows[i]["DelaID"]);
            }
        }

        private void txtKlijentID_Loaded(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand commandCb = new SqlCommand();
            commandCb.CommandText = "SELECT * FROM [Klijenti] ORDER BY KlijentID";
            commandCb.Connection = connection;
            SqlDataAdapter dataAdapterCb = new SqlDataAdapter(commandCb);
            DataTable dataTableCb = new DataTable("Klijenti");
            dataAdapterCb.Fill(dataTableCb);

            for (int i = 0; i < dataTableCb.Rows.Count; i++)
            {
                txtKlijentID.Items.Add(dataTableCb.Rows[i]["KlijentID"]);
            }
        }
    }
}
