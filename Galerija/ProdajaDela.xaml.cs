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
    /// Interaction logic for ProdajaDela.xaml
    /// </summary>
    public partial class ProdajaDela : Window
    {
        public ProdajaDela()
        {
            InitializeComponent();
            PrikaziProdajeDela();
        }
        private void PrikaziProdajeDela()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM [ProdajaDela]";
            command.Connection = connection;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable("ProdajaDela");
            dataAdapter.Fill(dataTable);

            DataGridProdajaDela.ItemsSource = dataTable.DefaultView;
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                BrojProdaje.Text = dr["BrojProdaje"].ToString();
                DatumProdaje.Text = dr["DatumProdaje"].ToString();
                CenaProdaje.Text = dr["CenaProdaje"].ToString();
                txtDelaID.Text = dr["DelaID"].ToString();
                KlijentID.Text = dr["KlijentID"].ToString();
            }
        }

        private void ponistiUnosTxt()
        {
            BrojProdaje.Text = "";
            DatumProdaje.Text = "";
            CenaProdaje.Text = "";
            txtDelaID.Text = "";
            KlijentID.Text = "";
        }


        private void ButtonDodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BrojProdaje.Text != "" && DatumProdaje.Text != "" && CenaProdaje.Text != "" && txtDelaID.Text != "" && KlijentID.Text != "")
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
                    connection.Open();
                    DateTime datumpp = Convert.ToDateTime(DatumProdaje.Text);
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "INSERT INTO [ProdajaDela] (BrojProdaje,DatumProdaje,CenaProdaje,DelaID,KlijentID) VALUES (@BrojProdaje,@DatumProdaje,@CenaProdaje,@DelaID,@KlijentID)";
                    command.Parameters.AddWithValue("@BrojProdaje", BrojProdaje.Text);
                    command.Parameters.AddWithValue("@DatumProdaje", datumpp);
                    command.Parameters.AddWithValue("@CenaProdaje", CenaProdaje.Text);
                    command.Parameters.AddWithValue("@DelaID", txtDelaID.Text);
                    command.Parameters.AddWithValue("@KlijentID", KlijentID.Text);
                    command.Connection = connection;
                    int provera = command.ExecuteNonQuery();
                    if (provera == 1)
                    {
                        MessageBox.Show("Podaci o prodaji delova su uspešno upisani");
                        PrikaziProdajeDela();
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
            DateTime datumpp = Convert.ToDateTime(DatumProdaje.Text);
            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE [ProdajaDela] SET BrojProdaje = @BrojProdaje,DatumProdaje = @DatumProdaje,CenaProdaje = @CenaProdaje,DelaID = @DelaID,KlijentID = @KlijentID WHERE BrojProdaje = @BrojProdaje";
            command.Parameters.AddWithValue("@BrojProdaje", BrojProdaje.Text);
            command.Parameters.AddWithValue("@DatumProdaje", datumpp);
            command.Parameters.AddWithValue("@CenaProdaje", CenaProdaje.Text);
            command.Parameters.AddWithValue("@DelaID", txtDelaID.Text);
            command.Parameters.AddWithValue("@KlijentID", KlijentID.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o prodaji delova su uspešno izmenjeni");
                PrikaziProdajeDela();
            }
            ponistiUnosTxt();
        }

        private void ButtonObrisi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (BrojProdaje.Text != "")
                {
                    SqlConnection connection = new SqlConnection();
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["connGalerija"].ConnectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "DELETE FROM [ProdajaDela] WHERE BrojProdaje = @BrojProdaje";
            command.Parameters.AddWithValue("@BrojProdaje", BrojProdaje.Text);
            command.Connection = connection;
            int provera = command.ExecuteNonQuery();
            if (provera == 1)
            {
                MessageBox.Show("Podaci o prodaji delova su uspešno obrisani");
                PrikaziProdajeDela();
            }
            ponistiUnosTxt();
            }
                else
            { MessageBox.Show("Popunite ID polje!"); }
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

        private void KlijentID_Loaded(object sender, RoutedEventArgs e)
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
                KlijentID.Items.Add(dataTableCb.Rows[i]["KlijentID"]);
            }
        }
    }
}
