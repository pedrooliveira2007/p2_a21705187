using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    // Declares Tile variable to house the _tilePrefab to be assigned in
    // editor and instantiated later on
    [SerializeField] private Tile _tilePrefab;

    // Declares List of type Tile to later on add all instantiated Tiles
    private List<Tile> _tiles;

    /// <summary>
    /// Method used to generate grid of default Tiles, takes two integers
    /// </summary>
    /// <param name="_rows"> Desired rows on grid</param>
    /// <param name="_cols"> Desired columns on grid</param>
    public void GenerateGrid(int _rows, int _cols)
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

                // Runs the no arguments overload of Init() method on the created
                // Tile, setting its color to the Default (no type) value
                spawnedTile.Init();

                // Adds the created Tile to the _tiles List
                _tiles.Add(spawnedTile);
            }
        }
    }


    /// <summary>
    /// Method used to check the desired type of a given tile and assign it the
    /// according properties (Color, Gold and Food value).
    /// </summary>
    /// <param name="TileBlueprint"> String that corresponds to
    /// an entire line on the .map4x file, or in other words, a Tile, and
    /// contains the information of the desired properties for that Tile</param>
    /// <param name="TileListIndex"> Index of the Tile on the List of
    /// instantiated Tiles to be changed</param>
    private void CheckType(string TileBlueprint, int TileListIndex)
    {
        if (TileBlueprint.Contains("desert"))
        {
            _tiles[TileListIndex].Init(TileType.desert);
        }

        else if (TileBlueprint.Contains("grassland"))
        {
            _tiles[TileListIndex].Init(TileType.grassland);
        }

        else if (TileBlueprint.Contains("hills"))
        {
            _tiles[TileListIndex].Init(TileType.hills);
        }

        else if (TileBlueprint.Contains("mountain"))
        {
            _tiles[TileListIndex].Init(TileType.mountain);
        }

        else if (TileBlueprint.Contains("ocean"))
        {
            _tiles[TileListIndex].Init(TileType.ocean);
        }
    }

    /// <summary>
    /// Method used to check the desired resources for a given tile and assign
    /// it the according properties (Gold and Food value modifications).
    /// The method used a series of "if" statements to look for more than one
    /// keywords, as one tile can have multiple different resources
    /// </summary>
    /// <param name="TileBlueprint"> String that corresponds to
    /// an entire line on the .map4x file, or in other words, a Tile, and
    /// contains the information of the desired properties for that Tile</param>
    /// <param name="TileListIndex"> Index of the Tile on the List of
    /// instantiated Tiles to be changed</param>
    private void CheckResources(string TileBlueprint, int TileListIndex)
    {
        if (TileBlueprint.Contains("plants"))
        {
            _tiles[TileListIndex].ChangeTileValues("plants");
        }

        if (TileBlueprint.Contains("animals"))
        {
            _tiles[TileListIndex].ChangeTileValues("animals");
        }

        if (TileBlueprint.Contains("metals"))
        {
            _tiles[TileListIndex].ChangeTileValues("metals");
        }

        if (TileBlueprint.Contains("fossilfuel"))
        {
            _tiles[TileListIndex].ChangeTileValues("fossilfuel");
        }

        if (TileBlueprint.Contains("luxury"))
        {
            _tiles[TileListIndex].ChangeTileValues("luxury");
        }

        if (TileBlueprint.Contains("pollution"))
        {
            _tiles[TileListIndex].ChangeTileValues("pollution");
        }
    }

    /// <summary>
    /// Method to place resources on Tiles according to the .map4x instructions.
    /// Receives a List of Strings that is created by converting every line
    /// after the first one (which defines the grid's size)on the .map4x file
    /// to a String (after filtering it for unwanted content such as # comments)
    /// </summary>
    /// <param name="_TilesBlueprints"> The list that contains every line
    /// on the .map4x file as strings </param>
    public void DistributeResources(List<string> _TilesBlueprints)
    {
        // Support variable used later to refer to Tiles in _tiles list
        // by their index
        int i = 0;

        // "Foreach" loop runs through every string (aka TileBlueprint, as these
        // each represent a Tile and contain its desired specifications) in
        // the passed list
        foreach (string TileBlueprint in _TilesBlueprints)
        {
            // Checks the string for the Type keyword and
            // modifies the Tile accordingly
            CheckType(TileBlueprint, i);

            // Checks the string for the Resources keywords and
            // modifies the Tile accordingly
            CheckResources(TileBlueprint, i);

            // Increments the support index variable to refer to next Tile on the
            // following loop run
            i++;
        }
    }
}