using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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

namespace NetBus
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

        private void Caps_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("CAPS LOCK OFF");
            //if (Control.IsKeyLocked(Keys.CapsLock))
            //    SendKeys.SendWait("{CAPSLOCK}This Is An Over Capitalized Test String");
            //else
            //    SendKeys.SendWait("This Is An Over Capitalized Test String");
        }

        private void Message_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");

                tcpclnt.Connect("172.23.192.1", 8001);
                // use the ipaddress as in the server program

                Console.WriteLine("Connected");
                Console.Write("Enter the string to be transmitted : ");

                //String str = Console.ReadLine();

                String str = "Hello Neo, Welcome to the Matrix";
                
                Stream stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Console.WriteLine("Transmitting.....");

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));

                tcpclnt.Close();
            }

            catch (Exception e1)
            {
                Console.WriteLine("Error..... " + e1.StackTrace);
            }
        }
    }
}
