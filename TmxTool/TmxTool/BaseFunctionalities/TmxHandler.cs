using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Data;
using TmxTool.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TmxTool.BaseFunctionalities
{
    public static class TmxHandler
    {
        public const string XPathTU = "//tu";

        


        public static IEnumerable<XElement> GetTmxNodes(string filePath)
        {
            XDocument document = XDocument.Load(filePath);
            IEnumerable<XElement> NodeList = document.XPathSelectElements(XPathTU);                   
            return NodeList;
        }
        
        
        public static List<string> GetFileList(string pathToFiles)
        {
            List<string> TempList = new List<string>(); 
            if (pathToFiles.Contains(".tmx"))
            {
                TempList.Add(pathToFiles);
            }
            else
            {
                try
                {
                    TempList = Directory.GetFiles(pathToFiles).Where(k => k.Contains(".tmx")).ToList();
                }
                catch (Exception)
                {
                    
                }                
            }            
            return TempList;
        }

        public static ObservableCollection<TmxRow> ReadTmxData(List<string> listOfFiles)
        {            
            ObservableCollection<TmxRow> TmxData = new ObservableCollection<TmxRow>();
            List<XElement> TranslationUnitList = new List<XElement>();
            foreach (string eachPath in listOfFiles)
            {
                TranslationUnitList.AddRange(GetTmxNodes(eachPath));
            }
            foreach (var item in TranslationUnitList)
            {
                List<XElement> SourceTargetList = item.Elements().ToList();
                TmxRow newRow = new TmxRow(SourceTargetList);
                TmxData.Add(newRow);                
            }
            return TmxData;
        }
        
        public static ObservableCollection<TmxRow> FilterCollection(ObservableCollection<TmxRow> inputCollection, string sourceString, string targetString, bool regexSearchMethod)
        {
            if (!regexSearchMethod)
            {               
                return new ObservableCollection<TmxRow>(inputCollection.Where(item => item.Source.Contains(sourceString) && item.Target.Contains(targetString)));                 
            }
            else
            {                
                return new ObservableCollection<TmxRow>(inputCollection.Where(item => Regex.Match(item.Source, sourceString).Success && Regex.Match(item.Target, targetString).Success));
            }            
        }

        

        public static bool IsValidRegex(string patterToValidate)
        {
            try
            {
                Regex.Match("", patterToValidate);

            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }

    }
}
