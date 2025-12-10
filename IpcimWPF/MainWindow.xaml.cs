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
                string ipAddress = darabok[0];

                domainok.Add(new Domain(domainName, ipAddress));
            }

            dataGrid.ItemsSource = domainok;
        }
    }
}