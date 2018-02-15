using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Net;

namespace TMS_Servers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       
        public string TMSinput;
        public string ColumsInput;
        public IEnumerable<XElement> TmsFileList;
        public IEnumerable<XElement> ColumnFileList;
        
        int ColorIndex = 0;
        



        public MainWindow()
        {
            InitializeComponent();
            
           
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            this.TmsFileList = ReadReference.ReadFile("TMS_Servers.Reference.TMS_list.xml", "//tms");
            this.Entry.ItemsSource = AutocompleteBoxSourceCreator.LoadList(this.TmsFileList); 
            
            ColumnFileList = ReadReference.ReadFile("TMS_Servers.Reference.SQLTables.xml", "//column");
            this.Entry2.ItemsSource = AutocompleteBoxSourceCreator.LoadList(this.ColumnFileList);
          
        }
        
        private  void Entry_DropDownClosed(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            
            if (Entry.SelectedItem == null)
            { return; }
            TMSinput = Entry.SelectedItem.ToString();
            
            XElement item = this.TmsFileList.Single(ele => ele.Element("name").Value.Equals(this.TMSinput, StringComparison.InvariantCultureIgnoreCase));
            
            Database.Content = (item.Element("database").Value).Replace("_", "__");
            URL.Content = (item.Element("url").Value);
            SQL.Content = (item.Element("sql").Value);
            SERVER.Content = (item.Element("server").Value);
            if (item.Element("server2") != null)
            {
                SERVER2.Content = item.Element("server2").Value;
            }
            else
            {
                SERVER2.Content = "N/A";
            }
            
            GetTmsVersion((item.Element("url").Value));
          


        }

        
        public  void  GetTmsVersion(string item)
        {
            string textFromFile = (new WebClient()).DownloadString(item);
            Regex pat = new Regex(@"(<div .*?build-info.*?><\/span>)(.*?)(<\/div>)");
            Match MatchVer = pat.Match(textFromFile);
            if (MatchVer.Success)
            {
                string Version = MatchVer.Groups[2].Value;
                Match m = Regex.Match(Version, @"(.*?)\.(.*?)\.(.*?)\.(.*)");

                TMSVersion.Content = m.Groups[1].Value + "." + m.Groups[2].Value + "." + m.Groups[4].Value;
            }
            else { TMSVersion.Content = "N/A"; }
        }
            

      
        
        //when Column Item selected from DDlist
        private void Entry2_DropDownClosed(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            if (Entry2.SelectedItem == null)
            {
                return;
            }
            ColumsInput = Entry2.SelectedItem.ToString();

            XElement item2 = this.ColumnFileList.Single(col => col.Element("name").Value.Equals(this.ColumsInput, StringComparison.InvariantCultureIgnoreCase));
            
            string Tpattern = "(<table>)(.*?)(</table>)";
            string TableList = null;
            foreach (Match Tmatch in Regex.Matches(item2.ToString(), Tpattern, RegexOptions.IgnoreCase))
            {
                string SearchResult = Tmatch.Groups[2].Value.ToString();
                TableList += SearchResult;
                TableList += "\r";
            }
            TBlock.Text = TableList;
            TableList = null;
            
        }
       


        private void Entry2_DropDownOpened(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            Entry2.SelectedItem = null;
        }
       
        private void Entry_DropDownOpened(object sender, RoutedPropertyChangedEventArgs<bool> e)
        {
            Entry.SelectedItem = null;
        }


        private void Database_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(Database.Content.ToString().Replace("__", "_"));
        }

        private void URL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(URL.Content.ToString());
        }

        private void SQL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(SQL.Content.ToString());
        }
        private void TMSVersion_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(TMSVersion.Content.ToString());
        }

        private void SERVER2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(SERVER2.Content.ToString());
        }
        private void SERVER_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(SERVER.Content.ToString());
        }

      

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

            var changer = new SkinChanger(this);
            if (ColorIndex == 0)
            {

                changer.ChangeSkin(Colors.Gray, Colors.DarkGray);
                
            }
            else if (ColorIndex == 1)
            {
                changer.ChangeSkin(Colors.Blue, Colors.DarkBlue);

            }
            else if (ColorIndex == 2)
            {
                changer.ChangeSkin(Colors.Green, Colors.DarkGreen);

            }
            else if (ColorIndex == 3)
            {
                changer.ChangeSkin(Colors.Red, Colors.DarkRed);

            }
            else if (ColorIndex == 4)
            {
                changer.ChangeSkin(Colors.Goldenrod, Colors.DarkGoldenrod);
            }
            else if (ColorIndex == 5)
            {
                changer.ChangeSkin(Colors.DarkSlateGray, Colors.Black);

            }
            this.ColorIndex++;
            if (this.ColorIndex == 6)
            {
                this.ColorIndex = 0;
            }


        }
        private void Image_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

       
        private void BGD_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void BGD1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        
    }
}
    
