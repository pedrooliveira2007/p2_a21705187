using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Gets the files in the target directory, reads them and stores the content
/// </summary>
public class FileManager : MonoBehaviour
{
    // Declares a ProcessMapInformation variable
    private ProcessMapInformation _pmi;
    // Declares a string        
    string _desktop; 
    // Declares a string        
    string _directoryPath;
    // Declares a string array
    string[] _filesFolder;
    // Declares a game object variable to be assigned in editor
    [SerializeField]
    private GameObject _mapList;
    // Declares a game object variable to be assigned in editor
    [SerializeField]
    private GameObject _folderFileError;

    /// <summary>
    /// Awake is called when the script instance is being loaded
    /// </summary>
    private void Awake() 
    {
        // Gets the ProcessMapInformation component from the current game object
        _pmi = GetComponent<ProcessMapInformation>();

        // Gets the path to the current system's Desktop folder 
        // and assigns it to _desktop
        _desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);            

        // Sets the directory to the map4xfiles folder 
        // and assigns it to _directoryPath
        _directoryPath = _desktop + @"\map4xfiles";

        // Tries to run the specified code if an exception isn't encountered
        try
        {
            // Checks the existence of all the files 
            // with an *.map4x extension in the specified directory 
            // and assigns it to the _filesFolder array
            _filesFolder = Directory.GetFiles(_directoryPath, "*.map4x");
        }
        // Catches the specified exception and runs the code for the situation
        catch (DirectoryNotFoundException)
        {
            // Sets _folderFileError game object SetActive() value as true
            _folderFileError.SetActive(true);
            // Sets _mapList game object SetActive() value as false
            _mapList.SetActive(false);
        }
    }

    /// <summary>
    /// Gets all the files ending in .map4x in the target directory
    /// </summary>
    /// <returns> An list of files as strings </returns>
    public List<string> GetFiles()
    {
        // Instantiates a List of strings to save the file's names
        List<string> _files = new List<string>();

        // Tries to run the specified code if an exception isn't encountered
        try
        {
            // Goes through every file in _filesFolder and 
            // for each file in the folder adds its name as a string to the list
            foreach(string file in _filesFolder)
            {
                // Gets the name of the current targeted file 
                // and assigns it to _fileName
                string _fileName = Path.GetFileName(file);
                
                // Adds the current _fileName string to the _files list
                _files.Add(_fileName); 
            }
        }
        // Catches the specified exception and runs the code for the situation
        catch (NullReferenceException)
        {
            // Sets _folderFileError game object SetActive() value as true
            _folderFileError.SetActive(true);
            // Sets _mapList game object SetActive() value as false
            _mapList.SetActive(false);
        }
        
        // Returns the _files strings list
        return _files;
    }

    /// <summary>
    /// Reads the contents of the file chosen by the user
    /// </summary>
    /// <param name="_buttonText"> The string displayed on the button </param>
    public void ReadFile(string _buttonText)
    {
        // Gets the path of the file due to searching in the project directory
        // since no directory is specified with the name alone
        // and assigns it to _filePath
        string _filePath = _directoryPath + 
            "\\" + Path.GetFileName(_buttonText);
        
        // Reads all lines in the specified file direcotry
        // and assigns it to the _linesInFile array
        string[] _linesInFile = File.ReadAllLines(_filePath);

        // Instantiates a list of strings to save only the needed information
        List<string> _mapInformation = new List<string>();

        // Goes through every line in _linesInFile 
        // and acts accordingly to the conditions
        foreach (string line in _linesInFile)
        {
            // Checks if a line has a '#' char in it
            if (line.IndexOf("#") >= 0)
            {
                // Checks if the line starts with an # char
                if (line.StartsWith("#"))
                {
                    // Skips over this part of the verification
                    continue;
                }
                // If the previous condition was false executes it's content 
                else
                {
                    // Modifies the _line string by getting everything 
                    // before an # char and stores it in _lineModified string 
                    string _lineModified =
                            line.Substring(0, line.LastIndexOf("#"));
                    
                    // Adds the current _lineModified string 
                    // to the _mapInformation List
                    _mapInformation.Add(_lineModified);
                }
            }
            // If the previous condition was false executes it's content 
            else
            {
                // Adds the current line string to the _mapInformation list
                _mapInformation.Add(line);
            }
        }

        // Passes _mapInformation list 
        // to the ProcessFileInfo() method while calling it
        _pmi.ReceiveMapInfo(_mapInformation);
    }
}