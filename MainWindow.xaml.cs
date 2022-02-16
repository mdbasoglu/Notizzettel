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

using System.Data.OleDb;
using System.IO;


namespace WpfApp1
{

        

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private string _dateiname = "../../../notizen.txt";
        private List<string> _notizen;

        public MainWindow()
        {
            InitializeComponent();

        }
        // Ereignismethode.
        // Das 'Loaded'-Ereignis wird ausgelöst, wenn das Steuerelement
        // (hier das Fenster) zum ersten Mal angezeigt wird.





        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(_dateiname))
            {
                // Die Datei mit den Notizen vom letzten Programmlauf einlesen.
                string[] zeilen = File.ReadAllLines(_dateiname);
                _notizen = new List<string>(zeilen);
                // Die Notizen werden der ListBox als Datenquelle bekannt gemacht.
                lbxNotizen.ItemsSource = _notizen;
            }
            else
            {
                // Eine leere Liste von Notizen anlegen.
                _notizen = new List<string>();
            }
        }





        // Ereignismethode.
        // Das 'Click'-Ereignis wird ausgelöst, wenn im selben
        // Steuerelement die Maustaste gedrückt und wieder losgelassen wird.
        // Nur ein aktivierter Button kann ein 'Click'-Ereignis auslösen.
        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            // Den eingegebenen Notiztext abrufen.
            string notiz = tbxNeueNotiz.Text;
            // Der Notiztext wird geprüft.
            if (notiz == "")
            {
                MessageBox.Show("Bitte einen Notiztext zu speichern eingeben.");
            }
            else
            {
                // Eine neue Notiz an die Liste anhängen und die ListBox aktualisieren.
                _notizen.Add(notiz);
                lbxNotizen.Items.Refresh();
                // Den Inhalt des Eingabefelds löschen.
                tbxNeueNotiz.Text = "";
            }
        }






        // Ereignismethode.
        private void btnLöschen_Click(object sender, RoutedEventArgs e)
        {
            // Die ausgewählte Notiz aus der ListBox abrufen.
            // Die 'SelectedItem' Property liefert den Datentyp 'Object'.
            // Die Referenz muss also auf den tatsächlich abgelegten
            // Datentyp (z.B. string) umgewandelt werden.
            string notiz = (string)lbxNotizen.SelectedItem;
            // Prüfen, ob eine Notiz ausgewählt worden ist.
            if (notiz == null)
            {
                MessageBox.Show("Bitte einen Notiztext zu löschen auswählen.");
            }
            else
            {
                // Die ausgewählte Notiz aus der Liste löschen
                // und die ListBox aktualisieren.
                _notizen.Remove(notiz);
                lbxNotizen.Items.Refresh();
            }
        }






        // Ereignismethode.
        // Das 'Closed'-Ereignis wird ausgeführt, wenn das Fenster
        // geschlossen wird.
        private void Window_Closed(object sender, EventArgs e)
        {
            // Den Inhalt der Liste in der Datei speichern.
            File.WriteAllLines("../../../notizen.txt", _notizen);
        }

    }
}
