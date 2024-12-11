using System;
using System.IO;
using System.Net;
using System.IO.Compression;

Console.WriteLine("=== Application d'installation des outils ADB ===");

// Demander à l'utilisateur de choisir la plateforme (Windows ou Linux)
Console.WriteLine("Choisissez votre système d'exploitation :");
Console.WriteLine("1. Windows");
Console.WriteLine("2. Linux");
Console.WriteLine("3.Mac");
string choice = Console.ReadLine();

string adbToolsUrl = string.Empty;
string installationDirectory = string.Empty;
string tempZipFile = string.Empty;

if (choice == "1")
{
    // URL des outils ADB pour Windows
    adbToolsUrl = "https://dl.google.com/android/repository/platform-tools_r31.0.3-windows.zip"; // Remplacer par le lien réel
    installationDirectory = @"C:\platform";
    tempZipFile = Path.Combine(Directory.GetCurrentDirectory(), "platform-tools-windows.zip");
}
else if (choice == "2")
{
    // URL des outils ADB pour Linux
    adbToolsUrl = "https://dl.google.com/android/repository/platform-tools_r31.0.3-linux.zip"; // Remplacer par le lien réel
    installationDirectory = @"/home/user/platform";  // Remplacez "user" par le nom d'utilisateur Linux si nécessaire
    tempZipFile = Path.Combine(Directory.GetCurrentDirectory(), "platform-tools-linux.zip");
}
if (choice == "3")
{
    // URL des outils ADB pour Windows
    adbToolsUrl = "https://dl.google.com/android/repository/platform-tools-latest-darwin.zip"; // Remplacer par le lien réel
    installationDirectory = @"/Users/user/platform";
    tempZipFile = Path.Combine(Directory.GetCurrentDirectory(), "platform-tools-darwin.zip");
}
else
{
    Console.WriteLine("Choix invalide. Le programme va se fermer.");
    return;
}

try
{
    Console.WriteLine($"Téléchargement des outils ADB pour {choice}...");

    // Télécharger les outils ADB
    using (WebClient client = new WebClient())
    {
        client.DownloadFile(adbToolsUrl, tempZipFile);
    }
    Console.WriteLine("Téléchargement terminé.");

    // Vérifier si le dossier d'installation existe, sinon le créer
    if (!Directory.Exists(installationDirectory))
    {
        Console.WriteLine($"Le dossier '{installationDirectory}' n'existe pas. Création...");
        Directory.CreateDirectory(installationDirectory);
    }

    // Extraire le fichier ZIP dans le dossier d'installation
    Console.WriteLine("Extraction des outils ADB...");
    ZipFile.ExtractToDirectory(tempZipFile, installationDirectory);
    Console.WriteLine("Extraction terminée.");

    // Supprimer le fichier ZIP après extraction
    File.Delete(tempZipFile);
    Console.WriteLine("Fichier ZIP temporaire supprimé.");

    Console.WriteLine("L'installation des outils ADB est terminée !");
    Console.WriteLine($"Les outils ADB ont été installés dans : {installationDirectory}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur pendant l'installation : {ex.Message}");
}
