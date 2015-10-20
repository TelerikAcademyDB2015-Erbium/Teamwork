namespace AutopartsSystem.Core.Pdf
{
    using System;

    public static class UniqueFileNameGenerator
    {
        public static string AddUniqueFilenameSuffix(string fileName)
        {
            DateTime currentDate = DateTime.Now;
            var fileNameSuffix =
                string.Format(
                "-{0}.{1}.{2}-{3}.{4}.{5}.pdf",
                    currentDate.Day,
                    currentDate.Month,
                    currentDate.Year,
                    currentDate.Hour,
                    currentDate.Minute,
                    currentDate.Second);

            fileName = fileName + fileNameSuffix;
            return fileName;
        }
    }
}
