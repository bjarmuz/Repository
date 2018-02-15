using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace TmxTool.BaseFunctionalities
{
    public class FileManager
    {

        public static string BrowseFolderPath()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                string ChoosenPath = dialog.SelectedPath;
                return ChoosenPath;
            }
        }

      

        
    }
}