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
using System.Windows.Forms;
using TmxTool.BaseFunctionalities;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
using System.Collections.ObjectModel;
using TmxTool.Model;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TmxTool
{

    public partial class  MainWindow : INotifyPropertyChanged
    {
        
        public ObservableCollection<TmxRow> FilterBaseCollection;

        private ObservableCollection<TmxRow> mainCollection;
        public ObservableCollection<TmxRow> MainCollection
        {
            get { return mainCollection; }
            set
            {
                if (value == mainCollection)
                    return;
                mainCollection = value;
                OnPropertyChanged("MainCollection");
            }
        }

        private string selectedPath;
        public string SelectedPath
        {
            get { return selectedPath; }
            set {
                if (value == selectedPath)
                    return;
                selectedPath = value;
                OnPropertyChanged("SelectedPath");                
            }
        }

        private bool regexSearchMethod;
        public bool RegexSearchMethod
        {
            get { return regexSearchMethod; }
            set { regexSearchMethod = value;
                OnPropertyChanged("RegexSearchMethod");
            }
        }

        private string sourceFilterString = "";
        public string SourceFilterString
        {
            get { return sourceFilterString; }
            set
            {
                if (value == sourceFilterString)
                    return;
                sourceFilterString = value;
                OnPropertyChanged("SourceFilterString");
            }
        }

        private string targetFilterString = "";
        public string TargetFilterString
        {
            get { return targetFilterString; }
            set
            {
                if (value == targetFilterString)
                    return;
                targetFilterString = value;
                OnPropertyChanged("TargetFilterString");
            }
        }
        

        public MainWindow()
        {
            InitializeComponent();
            LoadButton.IsEnabled=false;
        }
        
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedPath = FileManager.BrowseFolderPath();            
        }
        
        private async void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> newList;
            try
            {
               newList = TmxHandler.GetFileList(SelectedPath);
            }
            catch (Exception)
            {

                return;
            }

            await Task.Run(() => MainCollection = TmxHandler.ReadTmxData(newList));                
            FilterBaseCollection = MainCollection;
            
        }
        

        private void DataGridView_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();           
        }           
        
        
        private void SourceFilter_TextChanged(object sender, TextChangedEventArgs e)
        {            
            if(RegexSearchMethod == true && (!TmxHandler.IsValidRegex(SourceFilterString) || !TmxHandler.IsValidRegex(TargetFilterString)))
            {
                return;
            }
            var workingCollection = FilterBaseCollection;
            MainCollection = TmxHandler.FilterCollection(workingCollection, SourceFilterString, TargetFilterString, RegexSearchMethod);
        }

        private void TargetFilter_TextChanged(object sender, TextChangedEventArgs e)
        {            
            if (RegexSearchMethod == true && (!TmxHandler.IsValidRegex(SourceFilterString) || !TmxHandler.IsValidRegex(TargetFilterString)))
            {
                return;
            }
            var workingCollection = FilterBaseCollection;
            MainCollection = TmxHandler.FilterCollection(workingCollection, SourceFilterString, TargetFilterString, RegexSearchMethod);
        }

        private void FolderPath_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SelectedPath != null)
            {
                LoadButton.IsEnabled = true;
            }
           if (SelectedPath == "")
            {
                LoadButton.IsEnabled = false;
            }            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
