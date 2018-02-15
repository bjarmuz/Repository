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
            WarningMessage = "";
            List<string> fileList;
            try
            {
               fileList = TmxHandler.GetFileList(SelectedPath);
            }
            catch (Exception)
            {
                WarningMessage = "Invalid path...";
                return;
            }

            await Task.Run(() => MainCollection = TmxHandler.ReadTmxData(fileList));                
            FilterBaseCollection = MainCollection;
            
        }
        

        private void DataGridView_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();           
        }           
        
        
        private void SourceFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterRecords();
        }

        private void TargetFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterRecords();
        }

        private void FilterRecords()
        {
            if (RegexSearchMethod == true && TmxHandler.IsValidRegex(SourceFilterString, TargetFilterString))
            {
                var workingCollection = FilterBaseCollection;
                MainCollection = TmxHandler.FilterCollection(workingCollection, SourceFilterString, TargetFilterString, RegexSearchMethod);
            }
            else
            {
                return;//
            }
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
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
