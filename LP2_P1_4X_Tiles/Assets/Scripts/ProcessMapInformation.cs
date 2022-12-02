using System;
using System.Collections.Generic;
using UnityEngine;

public class ProcessMapInformation : MonoBehaviour
{
    // Declaration of variables
    private string _rowsInfo, _colsInfo;
    private int _rows, _cols;

    /// <summary>
    /// Receives the information about the map and processes it
    /// </summary>
    /// <param name="_mapInformation"> A list of strings with the 
    /// information about the map </param>
    public void ReceiveMapInfo(List<string> _mapInformation)
    {
        // Process the map information and passes it a list with strings
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
            // Gets the 1st element of the list and gets everything 
            // before a whitespace, then stores it 
            _rowsInfo = _mapInformation[0].
                Substring(0, _mapInformation[0].LastIndexOf(" "));

            // Gets the 2nd element of the list and gets everything 
            // before a whitespace, then stores it 
            _colsInfo =  _mapInformation[0].
                Substring(_mapInformation[0].LastIndexOf(" ") + 1);
            
            // Tries to run the specified code if an exception isn't encountered
            try
            {
                // Converts the Rows respective string into an int and stores it 
                _rows = Int32.Parse(_rowsInfo);

                // Converts the Cols respective string into a int and stores it 
                _cols = Int32.Parse(_colsInfo);
            }
            // Catches the specified exception and displays a warning
            catch (FormatException _fe)
            {
                Console.WriteLine("The Columns/Rows aren't numbers", _fe);
            }
        }
        // Catches the specified exception and displays a warning
        catch (ArgumentOutOfRangeException _aoore)
        {
            Console.WriteLine("There is nothing to read correctly.", _aoore);
        }
    }

    /// <summary>
    /// Removes the Columns and Rows from the list and passes a new list 
    /// necessary for the grid generation
    /// </summary>
    /// <param name="_mapInformation"> A list of strings with everything 
    /// needed to generate the game map </param>
    public void ProcessTileInformation(List<string> _mapInformation)
    {
        // Instantiate new lists of strings _titleInformation 
        // and copy _mapInformation list into it
        List<string> _tileInformation = _mapInformation;

        // Remove the 1st element of _tileInformation list
        _tileInformation.RemoveAt(0);
    } 
}