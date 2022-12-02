using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Gets the files in the target directory, reads them and stores the content
/// </summary>
public class FileManager : MonoBehaviour
{
    // Declaration of variables
    private ProcessMapInformation _pmi; 
    private readonly string _directoryPath; 
    private readonly string _filePath;
    private string[] _filesInFolder;

    /// <summary>
    /// Awake is called when the script instance is being loaded
    /// </summary>
    private void Awake() 
    {
        // Gets a component from the current game object and assigns it
        _pmi = GetComponent<ProcessMapInformation>();

        // Gets the path to the "map4xfiles" folder on the desktop of the system
        _directoryPath = 
            Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
            "map4xfiles");         

        // Tries to run the specified code if an exception isn't encountered
        try
        {
            // Checks the existence of the target files and assigns them
            _filesInFolder = Directory.GetFiles(_directoryPath, "*.map4x");
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
    public void ReadFile(string _buttonText)
    {
        // Gets the path to the specified file
        _filePath = 
            _directoryPath + Path.DirectorySeparatorChar + 
            Path.GetFileName(_buttonText);
        
        // Reads and assigns all lines in the specified file directory
        string[] _linesInFile = File.ReadAllLines(_filePath);

        // Instantiates a list of strings to save only the needed information
        List<string> _mapInformation = new List<string>();

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
                    _mapInformation.Add(_lineModified);
                }
            }
            else
            {
                // Adds the current line string to the _mapInformation list
                _mapInformation.Add(line);
            }
        }

        foreach (string line in _mapInformation)
        {
            Debug.Log(line);
        }

        // Passes _mapInformation list 
        // to the ProcessFileInfo() method while calling it
        _pmi.ReceiveMapInfo(_mapInformation);
    }
}