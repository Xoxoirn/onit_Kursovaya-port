using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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

namespace Kursovaya_ONIT_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ContentRendered += TCPConnectionsView_ContentRendered;
            this.ContentRendered += TCPListenersView_ContentRendered;
        }


        private void TCPConnectionsView_ContentRendered(object sender, EventArgs e)
        {
            var TCPConnections = new ObservableCollection<ModelTCPConnect>();
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            var tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            foreach (var item in tcpConnInfoArray)
            {
                TCPConnections.Add(new ModelTCPConnect(item.LocalEndPoint.Address.ToString(), item.LocalEndPoint.Port.ToString(), item.RemoteEndPoint.Address.ToString(), item.RemoteEndPoint.Port.ToString()));
            }
            gridTCPConnections.ItemsSource = TCPConnections;
            gridTCPConnections.Columns[0].Width = 150;
            gridTCPConnections.Columns[0].IsReadOnly = true;
            gridTCPConnections.Columns[1].Width = 80;
            gridTCPConnections.Columns[1].IsReadOnly = true;

            gridTCPConnections.Columns[2].Width = 150;
            gridTCPConnections.Columns[2].IsReadOnly = true;
            gridTCPConnections.Columns[3].Width = 80;
            gridTCPConnections.Columns[3].IsReadOnly = true;
        }
        private void TCPListenersView_ContentRendered(object sender, EventArgs e)
        {
            IPEndPoint[] tcpConnInfoArray;
            var TCPListeners = new ObservableCollection<ModelTCPListener>();
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
       
            
            tcpConnInfoArray = ipGlobalProperties.GetActiveTcpListeners();
           
            foreach (var item in tcpConnInfoArray)
            {
                TCPListeners.Add(new ModelTCPListener(item.Address.ToString(), item.Port.ToString()));
            }
            gridTCPListener.ItemsSource = TCPListeners;
            gridTCPListener.Columns[0].Width = 150;
            gridTCPListener.Columns[0].IsReadOnly = true;
            gridTCPListener.Columns[1].Width = 80;
            gridTCPListener.Columns[1].IsReadOnly = true;
            tcpConnInfoArray = ipGlobalProperties.GetActiveUdpListeners();
            var UDPListeners = new ObservableCollection<ModelTCPListener>();
            foreach (var item in tcpConnInfoArray)
            {
                UDPListeners.Add(new ModelTCPListener(item.Address.ToString(), item.Port.ToString()));
            }
            gridUDPListener.ItemsSource = UDPListeners;
            gridUDPListener.Columns[0].Width = 150;
            gridUDPListener.Columns[0].IsReadOnly = true;
            gridUDPListener.Columns[1].Width = 80;
            gridUDPListener.Columns[1].IsReadOnly = true;
        }
    }
}
