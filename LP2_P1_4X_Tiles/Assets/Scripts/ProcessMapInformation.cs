using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System;

public class ProcessMapInformation : MonoBehaviour
{
    // Declares Tile variable to house the _tilePrefab to be assigned in
    // editor and instantiated later on
    [SerializeField] private Tile _tilePrefab;

    // Declaration of variables
    private string _rowsInfo, _colsInfo;
    private int _rows, _cols;

    // Declares List of type Tile to later on add all instantiated Tiles
    private List<Tile> _tiles;

    internal Vector2 GetBoundaries() 
        => _tiles[(_tiles.Count)-1].transform.position;

    public void SetTilePrefab(GameObject tilePrefab)
    {
        this._tilePrefab = tilePrefab.GetComponent<Tile>();
    }

    /// <summary>
    /// Receives the information about the map and processes it
    /// </summary>
    /// <param name="_mapInformation"> IList regarding the map info </param>
    /// <param name="tilePanel"> Image regarding the tile's sprite </param>
    /// <param name="forFuturePanel"> Image regarding future functions </param>
    public void ReceiveMapInfo(IList<string> _mapInformation, Image tilePanel, 
        Image forFuturePanel)
    {
        // Process the map information and passes it a list with strings
        ProcessMapGrid(_mapInformation);

        // Calls ProcessTileInformation() method and passes it 
        // _mapInformation list
        ProcessTileInformation(_mapInformation, tilePanel, forFuturePanel);
    }

    /// <summary>
    /// Processes the map information to get it's grid size 
    /// </summary>
    /// <param name="_mapInformation"> A list of strings with everything 
    /// needed to generate the game map </param>
    private void ProcessMapGrid(IList<string> _mapInformation)
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
            _colsInfo = _mapInformation[0].
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
    /// <param name="_mapInformation"> IList regarding the map info </param>
    /// <param name="tilePanel"> Image regarding the tile's sprite </param>
    /// <param name="forFuturePanel"> Image regarding future functions </param>
    private void ProcessTileInformation(IList<string> _mapInformation, 
        Image tilePanel, Image forFuturePanel)
    {
        // Instantiate new lists of strings _titleInformation 
        // and copy _mapInformation list into it
        IList<string> _tileInformation = _mapInformation;

        // Remove the 1st element of _tileInformation list
        _tileInformation.RemoveAt(0);

        // Passes the list into a method to generate the map
        GenerateGrid(_rows, _cols, _tileInformation, tilePanel, forFuturePanel);

    }

    /// <summary>
    /// Method used to generate grid of default Tiles, takes two integers
    /// </summary>
    /// <param name="_rows"> The int value for the rows in the map </param>
    /// <param name="_cols"> The int value for the rows in the map </param>
    /// <param name="tilesBlueprints"> IList of strings to setup the 
    /// tiles </param>
    /// <param name="tilePanel"> Image regarding the tile's sprite </param>
    /// <param name="forFuturePanel"> Image regarding future functions </param>
    private void GenerateGrid(int _rows, int _cols, 
        IList<string> tilesBlueprints, Image tilePanel, Image forFuturePanel)
    {
        // Initializes List of Tile to later on be used to easily refer back
        // to instantiated Tiles
        _tiles = new List<Tile>();

        // "For" loops run for the length of the number of rows and columns of
        // the specified map
        for (int y = 0; y < _rows; y++)
        {
            for (int x = 0; x < _cols; x++)
            {
                // Instantiates a new Tile Prefab
                Tile spawnedTile = Instantiate(_tilePrefab, new Vector3(x, -y),
                    Quaternion.identity);

                // Changes the created Tile's name to include its coordinates on
                // the grid
                spawnedTile.name = $"Tile {y} {x}";

                // Adds the created Tile to the _tiles List
                _tiles.Add(spawnedTile);
            }
        }

        // Loop that goes through each tile and instantiates each one
        for (int i = 0; i < _tiles.Count; i++)
        {
            // Instantiates the given tile of the list
            _tiles[i].InitializeTile(tilesBlueprints[i], 
                tilePanel, forFuturePanel);
        }
    }

    public List<Tile> GetTiles() => _tiles;

}