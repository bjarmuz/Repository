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
                OnPropertyChanged();
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
                OnPropertyChanged();                
            }
        }

        private bool regexSearchMethod;
        public bool RegexSearchMethod
        {
            get { return regexSearchMethod; }
            set { regexSearchMethod = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        private string warningMessage;
        public string WarningMessage
        {
            get
            {
                return warningMessage;
            }
            set
            {
                if (value == warningMessage)
                    return;
                warningMessage = value;
                OnPropertyChanged();
            }
        }
        

       

    }
}
