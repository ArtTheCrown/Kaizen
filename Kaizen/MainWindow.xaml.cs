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

namespace Kaizen
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

        //===============================================================================================================
        // _   _ _____  ______                _   _                   _ _ _           _____           _   _             
        //| | | |_   _| |  ___|              | | (_)                 | (_) |         /  ___|         | | (_)            
        //| | | | | |   | |_ _   _ _ __   ___| |_ _  ___  _ __   __ _| |_| |_ _   _  \ `--.  ___  ___| |_ _  ___  _ __  
        //| | | | | |   |  _| | | | '_ \ / __| __| |/ _ \| '_ \ / _` | | | __| | | |  `--. \/ _ \/ __| __| |/ _ \| '_ \ 
        //| |_| |_| |_  | | | |_| | | | | (__| |_| | (_) | | | | (_| | | | |_| |_| | /\__/ /  __/ (__| |_| | (_) | | | |
        // \___/ \___/  \_|  \__,_|_| |_|\___|\__|_|\___/|_| |_|\__,_|_|_|\__|\__, | \____/ \___|\___|\__|_|\___/|_| |_|
        //                                                                     __/ |                                    
        //                                                                    |___/                                     
        //===============================================================================================================

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Minimize_Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
