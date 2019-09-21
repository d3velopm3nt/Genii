using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DALX.Core
{
    public static class FileHelper
    {
        public static string BrowseFolderLocation()
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            folderDlg.SelectedPath = CoreHelper.DefaultFilePath;
            // Show the FolderBrowserDialog.
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                return folderDlg.SelectedPath;
            }
            else
                return "0";
        }

        public static List<FileInfo> GetFilesFromPath(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);
          
            return di.GetFiles().ToList();
        }

        public static List<DirectoryInfo> GetDirectoriesFromPath(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            return di.GetDirectories().ToList();
            
        }

        public static void CreateFolderPathExist(string path)
        {
            var tempPath = path.Substring(0, path.LastIndexOf("\\") + 1);
            // Check if folder location exist else create one
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
        }

        public static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public static bool WriteToFile(string path, string contents)
        {
            File.WriteAllText(path, contents);
            return true;
        }

        public static bool CheckIfFileExist(string path)
        {
            if (File.Exists(path))
                return true;
            else
                return false;
            
        }

        public static void CreateFile(string path)
        {
            if (!File.Exists(path))
                File.Create(path);
        }
    }
}
