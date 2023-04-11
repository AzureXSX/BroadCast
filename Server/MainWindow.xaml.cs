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

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimpleTcpServer server = new SimpleTcpServer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            server.Start(5000);
            Sport.IsChecked = true;
        }

        private void Button_GotMouseCapture(object sender, MouseEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() => {
                if (Sport.IsChecked == true)
                {
                    server.Broadcast(TXT.Text + " (Sport)");
                    return;
                }
                if (Food.IsChecked == true)
                {
                    server.Broadcast(TXT.Text + " (Food)");
                    return;
                }
                if (Furniture.IsChecked == true)
                {
                    server.Broadcast(TXT.Text + " (Furniture)");
                    return;
                }
            }));

            TXT.Text = "";
        }
    }
}
