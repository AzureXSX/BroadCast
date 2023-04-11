using SimpleTCP;
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

namespace BroadCast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimpleTcpClient client = new SimpleTcpClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            client.DataReceived += (sender, e) =>
            {
                var msg = Encoding.UTF8.GetString(e.Data);
                if(msg.Split().Last() == "(Sport)")
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        if (Sport.IsChecked == true)
                        {
                            TXT.Text += msg + "\n\n";
                            return;
                        }
                       
                       

                    }));
                }
                else if(msg.Split().Last() == "(Food)")
                {
                    this.Dispatcher.Invoke(new Action(() => {
                        if (Food.IsChecked == true)
                        {
                            TXT.Text += msg + "\n\n";
                            return;
                        }
                    }));
                }
                else if(msg.Split().Last() == "(Furniture)")
                {
                    this.Dispatcher.Invoke(new Action(() => {
                        if (Furniture.IsChecked == true)
                        {
                            TXT.Text += msg + "\n\n";
                            return;
                        }
                    }));
                }
            };
            client.Connect("127.0.0.1", 5000);
        }
    }
}
