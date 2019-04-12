using System;
using System.IO;

namespace BookManager.Api.Targets
{
    public class TypeScriptClientExtensionsCreationTask : Microsoft.Build.Utilities.Task
    {
        private const string Extensions = "import { BaseClient } from './BaseClient'";

        public string BuildDir { get; set; }
        public string ExtensionCodeFileName { get; set; } = "client.extensions.ts";

        public override bool Execute()
        {
            bool result = true;

            try
            {
                string filePath = Path.Combine(BuildDir, ExtensionCodeFileName);
                Directory.CreateDirectory(BuildDir);

                // Delete the file if it exists.
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Create the file.
                using (FileStream fs = File.Create(filePath))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(Extensions);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"TypeScriptClientExtensionsCreationTask.Execute() ERROR: {e.Message} {e.StackTrace}");
                result = false;
            }
            return result;
        }
    }
}
