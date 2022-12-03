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
    public void GenerateGrid(int _rows, int _cols, List<string> tilesBlueprints)
    {
        // Initializes List of Tile to later on be used to easily refer back
        // to instantiated Tiles
        _tiles = new List<Tile>();
        int line = 0;
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

                spawnedTile.InitializeTile(tilesBlueprints[line]);

                // Adds the created Tile to the _tiles List
                _tiles.Add(spawnedTile);
                line++;
            }
        }
    }

 

    
}