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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Galerija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dela dela = new Dela();
            dela.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tehnike tehnika = new Tehnike();
            tehnika.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Autori autor = new Autori();
            autor.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ProdajaDela prodajadela = new ProdajaDela();
            prodajadela.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            NabavkaDela nabavkadela = new NabavkaDela();
            nabavkadela.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Klijenti klijenti = new Klijenti();
            klijenti.Show();
        }
    }
}
