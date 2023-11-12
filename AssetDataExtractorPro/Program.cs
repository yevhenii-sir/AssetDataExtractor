namespace AssetDataExtractorPro
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            var mainForm = new MainForm();
            Application.Run(mainForm);

            if (args.Length > 0)
            {
                string filePath = args[0];
                mainForm.ReadProjectFile(filePath);
            }
        }
    }
}