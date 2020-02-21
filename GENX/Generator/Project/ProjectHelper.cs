using DALX.Core;
using GENX.Files;
using GENX.Generator.Connection;
using GENX.Generator.Library;
using GENX.Generator.Snippet;
using GENX.Generator.Solution;
using GENX.Generator.Table;
using GENX.Generator.Template;
using GENX.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENX.Generator.Project
{
    public class ProjectHelper
    {
        #region Properties
        internal static string GetFullPath
        {
            get
            {
                var path = SolutionHelper.GetFullPath;
                FileHelper.CreateFolderPathExist(path);
                return path;
            }
        }

       public static List<SnippetFile> Snippets { get; set; }

        #endregion

        #region Methods
        public static void CreateProjectFolderWithXFolders(string Solution, string Folder)
        {
            string path = GetFullPath + "\\" + Solution + "\\" + Folder + "\\";
            FileHelper.CreateFolderPathExist(path);
            FileHelper.CreateFolderPathExist(path + "\\Templates\\");
            FileHelper.CreateFolderPathExist(path + "\\Snippets\\");
            ProjectFile file = new ProjectFile();
            file.Solution = Solution;
            file.ProjectName = Folder;
            file.Path = path;

            CreateFile(file);
        }

        public static void CreateFile(ProjectFile file)
        {
            FileHelper.WriteToFile(file.Path + "\\ProjectConfig.genx", BuildFile(file));
        }
        #endregion

        #region File
        /// <summary>
        /// Build the ProjectConfig.genx file with the ProjectFile Entity, returns ProjectConfig String
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string BuildFile(ProjectFile file)
        {
            string projectFile = "##Project Config File" + Environment.NewLine + Environment.NewLine;

            projectFile += "#Solution::" + file.Solution + Environment.NewLine +
                            "#Project::" + file.ProjectName + Environment.NewLine +
                            "#Project Path::" + file.Path + Environment.NewLine +
                            "#Target Path::" + file.TargetPath + Environment.NewLine + Environment.NewLine;

            ///Add the Connections to the Profile File

            projectFile += "#Conn::" + file.DefaultConnection.FullString + Environment.NewLine + Environment.NewLine;

            projectFile += "##Templates" + Environment.NewLine;

            if (file.TemplateList != null)
                foreach (IXFile temp in file.TemplateList)
                {
                    string fullname = !temp.IsActive ? "!" + temp.FileName : temp.FileName;
                    projectFile += "#Template::" +  fullname + Environment.NewLine +
                        "#Path::" + temp.TargetPath + Environment.NewLine;

                }
            projectFile += Environment.NewLine + "Database Tables" + Environment.NewLine;

            if (file.TableList != null)
                //Add template Tables
                foreach (TableEntity table in file.TableList)
                {
                    projectFile += "#Table::" + table.TableName + Environment.NewLine;
                    //foreach (string col in table.ColumnList)
                    //    projectFile += "#Column::" + Environment.NewLine;
                }


            return projectFile;
        }
        /// <summary>
        /// Read File , Loop through lines and create a ProfileFile, return Project File
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static ProjectFile LoadProjectFile(string path)
        {
            var projectFile = new ProjectFile();
            try
            {
                string fullpath = path + @"\ProjectConfig.genx";
                Snippets =  SnippetHelper.GetProjectSnippets(path);
                if (File.Exists(fullpath))
                {
                    var lines = File.ReadAllLines(fullpath);
                    IXFile template = new TemplateFile();

                    foreach (string line in lines)
                    {
                        if (line.Contains("::"))
                        {
                            var lineText = line.Substring(line.IndexOf("::") + 2);
                            if (line.Contains("#Solution::"))
                                projectFile.Solution = lineText;
                            else if (line.Contains("#Project::"))
                                projectFile.ProjectName = lineText;
                            else if (line.Contains("#Project Path::"))
                                projectFile.Path = lineText;
                            else if (line.Contains("#Target Path::"))
                                projectFile.TargetPath = lineText;
                            else if (line.Contains("#Conn::"))
                            {
                                projectFile.DefaultConnection = ConnectionHelper.LoadConnectionFile(lineText);
                                CoreHelper.ConnectionString = projectFile.DefaultConnection.FullString.ToString();
                            }
                            ///Add Template to ProjectFile
                            else if (line.Contains("#Template::"))
                            {
                                template = Language.LanguageHelper.GetFileFromExtention(lineText.GetFileExtention(),projectFile);
                                template.FileName = lineText;
                                template.IsActive = lineText.StartsWith("!") ? false : true;
                                template.FullPath = path + @"\Templates\" + lineText;

                            }
                            else if (line.Contains("#Path::"))
                            {
                                template.TargetPath = lineText;
                                projectFile.TemplateList.Add(template);

                            }
                            //Add Table to Template File
                            else if (line.Contains("#Table::"))
                            {
                                var table = new TableEntity(lineText);
                                projectFile.TableList.Add(table);
                            }
                            ////Add Column to TableEntity
                            //else if (line.Contains("#Column::"))
                            //    table.ColumnList.Add(lineText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return projectFile;
        }

        public static List<string> GetProjectTemplates(string path)
        {
            var templateList = new List<string>();
            List<FileInfo> fileList = FileHelper.GetFilesFromPath(path);

            foreach (FileInfo file in fileList)
            {
                templateList.Add(file.Name);
            }

            return templateList;
        }

        #endregion
    }
}
