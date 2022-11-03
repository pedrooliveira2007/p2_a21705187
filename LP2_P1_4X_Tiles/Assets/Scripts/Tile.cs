using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Tile collumn in the map.
    public int Col { get; set; }
    // Tile row in the map.
    public int Row { get; set; }
    // Tile terrain type.
    public Terrain Terrain { get; set; }
    // Tile list of resources.
    public List<Resource> Resources { get; set; }
}
