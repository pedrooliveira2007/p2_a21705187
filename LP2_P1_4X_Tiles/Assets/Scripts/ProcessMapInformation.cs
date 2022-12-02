using System;
using System.Collections.Generic;
using UnityEngine;

public class ProcessMapInformation : MonoBehaviour
{
    // Declaration of variables
    private string _rowsInfo, _colsInfo;
    private int _rows, _cols;

    /// <summary>
    /// Receives the information about the map from the FileManager 
    /// and calls the methods required to process the information
    /// </summary>
    /// <param name="_mapInformation"> A list of strings with the 
    /// information about the map </param>
    public void ReceiveMapInfo(List<string> _mapInformation)
    {
        // Calls ProcessMapGrid() method and passes it _mapInformation list
        ProcessMapGrid(_mapInformation);

        // Calls ProcessTileInformation() method and passes it 
        // _mapInformation list
        ProcessTileInformation(_mapInformation);
    }

    /// <summary>
    /// Processes the map information to get it's grid size 
    /// </summary>
    /// <param name="_mapInformation"> A list of strings with everything 
    /// needed to generate the game map </param>
    private void ProcessMapGrid(List<string> _mapInformation)
    {
        // Tries to run the specified code if an exception isn't encountered
        try
        {
            // Gets the 1st element of the list _mapInformation and gets 
            // everything before a whitespace, then stores it in _rowsInfo
            _rowsInfo = _mapInformation[0].
                Substring(0, _mapInformation[0].LastIndexOf(" "));

            // Gets the 1st element of the list _mapInformation and gets 
            // everything after a whitespace, then stores it in _colsInfo
            _colsInfo =  _mapInformation[0].
                Substring(_mapInformation[0].LastIndexOf(" ") + 1);
            
            // Tries to run the specified code if an exception isn't encountered
            try
            {
                // Converts _rowsInfo into a integer and stores it in _rows
                _rows = Int32.Parse(_rowsInfo);

                // Converts _colsInfo into a integer and stores it in _cols
                _cols = Int32.Parse(_colsInfo);
            }
            // Catches the specified exception and runs the code for 
            // the situation
            catch (FormatException)
            {
                // Sets _fileGridSetupError game object SetActive() value 
                // as true
                //!_fileGridSetupError.SetActive(true);
            }
        }
        // Catches the specified exception and runs the code for the situation
        catch (ArgumentOutOfRangeException)
        {
            // Sets _fileGridSetupError game object SetActive() value as true
            //!_fileGridSetupError.SetActive(true);
        }
    }

    /// <summary>
    /// Removes the coordinates from the list _mapInformation and passes it s a 
    /// new list _tileInformation with the necessary elements for tile creation
    /// </summary>
    /// <param name="_mapInformation"> A list of strings with all the filtered 
    /// info in the file </param>
    public void ProcessTileInformation(List<string> _mapInformation)
    {
        // Instantiate new lists of strings _titleInformation 
        // and copy _mapInformation list into it
        List<string> _tileInformation = _mapInformation;

        // Remove the 1st element of _tileInformation list
        _tileInformation.RemoveAt(0);
    } 
}