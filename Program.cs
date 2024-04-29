using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Kaynak dizinleri
        string[] sourceDirectories =
        {
            @"C:\Walletgate\Master.Api",
            @"C:\Walletgate\Common.Api",
            @"C:\Walletgate\InvoicePayment.Backoffice"
        };

        // Hedef dizin
        string destinationBaseDirectory = @"C:\Users\baemir\Documents\AppSettings-Tracker\appSettingsChecker\Volume";

        foreach (string sourceDir in sourceDirectories)
        {
            // appsettings.json ve appsettings.Development.json dosyalarını kopyala
            string[] sourceFiles = Directory.GetFiles(sourceDir, "appsettings*.json");

            foreach (string sourceFile in sourceFiles)
            {
                string fileName = Path.GetFileName(sourceFile);
                string sourceDirectoryName = new DirectoryInfo(sourceDir).Name;

                string destinationFile = Path.Combine(destinationDirectoryName, fileName);

                try
                {
                    // Hedef klasörü oluştur (eğer zaten varsa, bu adımı atla)
                    Directory.CreateDirectory(destinationDirectoryName);

                    // Dosyayı kopyala ve üzerine yaz
                    File.Copy(sourceFile, destinationFile, true);
                    Console.WriteLine($"Dosya {sourceFile} {destinationFile} dizinine kopyalandı.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }
            }
        }
    }
}
