using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Gets the files in the target directory, reads them and stores the content
/// </summary>
[System.Serializable]
public class FileHandler
{
    // Declaration of variables

    public string DirectoryPath { get; internal set; }
    public string FilePath { get; internal set; }
    public List<string> FilesInFolder { get; internal set; }
    public List<string> MapInformation { get; internal set; }
    public string FileName { get; internal set; }
    public FileInfo[] Info ;



    /// <summary>
    /// Reads the map4xfiles folder, searching for the files
    /// </summary>
    internal void GatherFolderAndFiles()
    {
        // Tries to run the specified code if an exception isn't encountered
        try
        {
            // Gets the path to the specified file
            DirectoryInfo dir =
               new DirectoryInfo($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}"
                   + Path.DirectorySeparatorChar + @"map4xfiles");

            // Searches for .map4x files inside the folder
            Info =  dir.GetFiles("*.map4x");
            // If there are files inside
            
            {  // Get the file name for each file
                for (int i = 0; i <Info.Lenght();i++)
                {
                    FilesInFolder.Add(Info[i]);
                }
            }
        }
        // Catches the specified exception and displays a warning
        catch (DirectoryNotFoundException _dnfe)
        {
            Console.WriteLine("The folder was not found in the desktop", _dnfe);
        }

    }

    /// <summary>
    /// Reads the contents of the file chosen by the user in the main menu
    /// </summary>
    /// <param name="_buttonText"> The string displayed on the button </param>
    public void ReadFile(string fileName)
    {
       
                // Reads and assigns all lines in the specified file directory
                string[] _linesInFile = File.ReadAllLines(FilePath);

        // Instantiates a list of strings to save only the needed information
        MapInformation = new List<string>();

        // Goes through every line in _linesInFile 
        foreach (string line in _linesInFile)
        {
            // Checks if a line has a '#' char in it
            if (line.IndexOf("#") >= 0)
            {
                // Checks if the line starts with an # char and skips it
                if (line.StartsWith("#"))
                    continue;
                else
                {
                    // Modifies the string by getting everything 
                    // before an # char and storing it 
                    string _lineModified =
                            line.Substring(0, line.LastIndexOf("#"));

                    // Adds the current string to the _mapInformation List
                    MapInformation.Add(_lineModified);
                }
            }
            else
            {
                // Adds the current line string to the _mapInformation list
                MapInformation.Add(line);
            }
        }

        foreach (string line in MapInformation)
        {
            Debug.Log(line);
        }

    }
}
