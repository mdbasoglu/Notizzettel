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
    public partial class MainWindow : Window
    {
        string dosyayolu;

        public MainWindow()
        {
            InitializeComponent();
            dosyayolu = File.AppendText(path:"C:/Users/mdbas/Documents/Notizzettel/feature_Notizzettel_Unterlagen/notizen.txt");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
            textBox1.Text = "";// Nach dem Text Schreiben mach diese Zeile noch mal Text Box leer

            //dosyayı boşlatma işlemi
            File.WriteAllText(dosyayolu, string.Empty);

            //dosyayı aç ve yazmaya başla
            FileStream fileStream = new FileStream(dosyayolu, FileMode.Open, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8))
            {
                writer.WriteLine(textBox1.Text);
                writer.Close();
            }
            fileStream.Close();
        }
    }
}
