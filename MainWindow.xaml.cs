using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace gyak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<String> atmerok = new List<String>() { "R10", "R12", "R13", "R14", "R15", "R16", "R17", "R18" };
        ObservableCollection<Tetel> tetelek = new ObservableCollection<Tetel>();

        public MainWindow()
        {
            InitializeComponent();


            dgTetelek.ItemsSource = tetelek;
            cbAtmero.ItemsSource = atmerok;     // a cbAtmérot így  kötjük össze az atmerok listaval 
            cbAtmero.SelectedIndex = 5;         // az atmerok között kivalasztom az R16 alapértelmezett
                                                // elemet, ami a sorban   0-tól az 5. ... ezért lett 5.
            
            FelveszAdatokat();

           
        }

        private void FelveszAdatokat()
        {
           tetelek.Add(new Tetel("nyári", 205, 55, "R16", 4));
            tetelek.Add(new Tetel("Téli", 300, 55, "R14", 8));
            tetelek.Add(new Tetel("Nyári", 200, 55, "R14", 6));
            tbMennyi.Text = tetelek.Sum(x => x.Darab) + "db";
        }

        private void btnIgeny_Click(object sender, RoutedEventArgs e)

        {
            bool hibasMennyiseg = false;

            int mennyiseg = 0;



            try
            {
                mennyiseg = Convert.ToInt32(txtDarab.Text);
            }
            catch (Exception)
            {
                hibasMennyiseg = true;
            }
            if (hibasMennyiseg || mennyiseg == 0)

            {
                MessageBox.Show("Nem adott meg mennyiséget");
                txtDarab.Focus();   // explicit fókuszbeállítás ... FONTOS SOR!!!!
                return;
            }
            string tipus;
            if (rbNyari.IsChecked == true)
            {
                tipus = "Nyári";
            }
            else if (rbTeli.IsChecked == true)
            {
                tipus = "Téli";

            }
            else
            {
                tipus = "Négyévszak";
            }

            tetelek.Add(new Tetel(tipus, (int)sliSzelesseg.Value, int.Parse(txtMagassag.Text),
                cbAtmero.SelectedItem.ToString(), int.Parse(txtDarab.Text)));


            /*    catch (Exception ex)
                {
                    MessageBox.Show($"Hiba történt :{ex.Message}", "Hiba!", MessageBoxButton.OK);

                }  */
            tbMennyi.Text = tetelek.Sum(x => x.Darab) + "db";
        }


        // Egy elem törlése:
        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            if (dgTetelek.SelectedIndex < 0)   // így is lehet: (dgTetelek.SelectedIndex == -1)
            {
                MessageBox.Show("Nem jelölt ki elemet");
                return;
                
            }
            tetelek.RemoveAt(dgTetelek.SelectedIndex);
            tbMennyi.Text = tetelek.Sum(x => x.Darab) + "db";
        }


         // Összes adat törlése:     
        private void btnUrites_Click_1(object sender, RoutedEventArgs e)
        {
            tetelek.Clear();
           tbMennyi.Text = tetelek.Sum(x => x.Darab) + "db";        
        }

        private void btnmentes_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("gumirendelés.txt");

            foreach (var adat in tetelek)
            {
                sw.WriteLine($"{adat.Tipus};{adat.Szelesseg};{adat.Magassag};{adat.Atmero};{adat.Darab}");
            }
            sw.Close();

            MessageBox.Show("A gumiabroncs listja mentésre került!");
        }
    }
}
