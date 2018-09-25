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
using System.Collections.ObjectModel;
using System.IO;

namespace BabyNames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IList<BabyName> babynameCollection;
        string LineRead;

        public MainWindow()
        {
            InitializeComponent();
            babynameCollection = new ObservableCollection<BabyName>();
            lbxBabyNames.ItemsSource = babynameCollection;
            Loaded += Window_Loaded;


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(@"..\..\babynames.txt", FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs, Encoding.Default);

                for (int i = 0; i < 10; i++)
                {
                    LineRead = sr.ReadLine();
                    babynameCollection.Add(new BabyName(LineRead));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured during file IO");
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
        }
    }
}

