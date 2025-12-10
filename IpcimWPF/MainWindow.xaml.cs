using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IpcimWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public class Domain
    {
        public string domainNev { get; set; }
        public string ipCim { get; set; }

        public Domain(string domainNev, string ipCim)
        {
            this.domainNev = domainNev;
            this.ipCim = ipCim;
        }
    }

    public partial class MainWindow : Window
    {
        

        List<Domain> domainok = new List<Domain>();
        public MainWindow()
        {
            var sorok = File.ReadAllLines("csudh.txt").Skip(0);

            InitializeComponent();
            foreach (string sor in sorok)
            {
                string[] darabok = sor.Split(";");
                string domainName = darabok[0];
                string ipAddress = darabok[1];

                domainok.Add(new Domain(domainName, ipAddress));
            }

            dataGrid.ItemsSource = domainok;
        }

        private void bevitel(object sender, RoutedEventArgs e)
        {
            if(domainName.Text.Length > 0 && ipAddress.Text.Length > 0)
            {
                Domain newDomain = new Domain(domainName.Text, ipAddress.Text);
                domainok.Add(newDomain);
                dataGrid.Items.Refresh();
                domainName.Text = "";
                ipAddress.Text = "";
            }
            else
            {
                MessageBox.Show("Mindkét mező kitöltése kötelező!","Hiba",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void mentes(object sender, RoutedEventArgs e)
        {
            if (domainok == null)
            {
                MessageBox.Show("Nincsenek domainok.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string file = "";
            foreach (var d in domainok)
            {
                file += d.domainNev + ";" + d.ipCim + "\n";
            }
            try
            {
                File.WriteAllText("csudh.txt", file);
                MessageBox.Show("Sikeres mentés.", "Mentés", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hiba történt a fájlba írás során. " +ex.Message,"Hiba",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}