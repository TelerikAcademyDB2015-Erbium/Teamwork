﻿namespace AutopartsSystem.Core.Common
{
    using System.IO;
    using System.Windows.Forms;

    public static class Constants
    {
        public static string PathToProgramExeFolder = Path.GetDirectoryName(Application.ExecutablePath);

        public static string PathToProjectFolder = PathToProgramExeFolder.Substring(0, PathToProgramExeFolder.Length - 10);

        public static string PathToFiles = PathToProjectFolder + "\\Files";

        public static string DividerForExcelRead = "|||";
    }
}
