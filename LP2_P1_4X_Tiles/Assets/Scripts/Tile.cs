using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Declares GameObject variable of Highlight component to use on mouse-over
    [SerializeField] private GameObject _highlight;
    // Declares SpriteRenderer variable to enable later changes of Sprite's color
    [SerializeField] private SpriteRenderer _renderer;
    // Declares SpriteRenderer "list" to enable later the actual tile resource sprites
    [SerializeField] public List<GameObject> _resourcesSpriteRenderer;
    // Declares Image to enable changes in the UI
    [SerializeField] private Image _tilePanel;
    // Declares Image to enable changes in the UI
    [SerializeField] private Image forFuturePanel;
    // Declares bools to enable changes in the UI
    [SerializeField]
    private bool
        hasAnimals = false, hasFossilFuel = false,
        hasLuxury = false, hasMetals = false,
        hasPlants = false, hasPollution = false;

    // Declares propreties for the Tile's Gold and Food overall Value
    public int TileCoinValue { get; private set; }
    public int TileFoodValue { get; private set; }
    // Declares Type attribute for the Tile from the set defined by enum Terrains
    public Terrain TerrainType { get; private set; }
    // Declares a generic enumeration of resources present inside this tile
    public List<Resource> Resources { get; private set; } = new List<Resource>();

    /// <summary>
    /// Method used to set the tile Resources
    /// </summary>
    /// <param name="resources">Line from file containing the resources and aditional infos</param>
    internal void SetResources(string resources)
    {
        if (resources.Contains("animals"))
        {
            Resources.Add(Resource.Animals);
            UpdateResourceImages("Animals");
            hasAnimals = true;
        }
        if (resources.Contains("fossilfuel"))
        {
            Resources.Add(Resource.Fossilfuel);
            UpdateResourceImages("Fossilfuel");
            hasFossilFuel = true;
        }
        if (resources.Contains("luxury"))
        {
            Resources.Add(Resource.Luxury);
            UpdateResourceImages("Luxury");
            hasLuxury = true;
        }
        if (resources.Contains("metals"))
        {
            Resources.Add(Resource.Metals);
            UpdateResourceImages("Metals");
            hasMetals = true;
        }
        if (resources.Contains("plants"))
        {
            Resources.Add(Resource.Plants);
            UpdateResourceImages("Plants");
            hasPlants = true;
        }
        if (resources.Contains("pollution"))
        {
            Resources.Add(Resource.Pollution);
            UpdateResourceImages("Pollution");
            hasPollution = true;
        }
    }

    private void UpdateResourceImages(string name)
    {
        foreach (GameObject resource in _resourcesSpriteRenderer)
        {
            if (resource.name == name)
            {
                resource.SetActive(true);
            }
        }
    }
    /// <summary>
    /// Method used to set the TerrainType value
    /// </summary>
    /// <param name="type">Line from file containing the terrain type and aditional infos</param>
    internal void SetTerrainType(string type)
    {
        if (type.Contains("desert"))
        {
            TerrainType = Terrain.Desert;
        }
        else if (type.Contains("plains"))
        {
            TerrainType = Terrain.Plains;
        }
        else if (type.Contains("hills"))
        {
            TerrainType = Terrain.Hills;
        }
        else if (type.Contains("mountain"))
        {
            TerrainType = Terrain.Mountain;
        }
        else if (type.Contains("water"))
        {
            TerrainType = Terrain.Water;
        }
    }

    /// <summary>
    /// Initializes the tile, coloring and altering 
    /// its properties and attributes according to its type
    /// </summary>
    /// <param name="type"> A given Tile's type, from the available
    /// items in Terrains enum </param>
    public void InitializeTile(string tileInfo, Image tilePanel, Image forFuturePanel)
    {
        //set the base values for the tile terrain type and tile resources
        this._tilePanel = tilePanel;
        this.forFuturePanel = forFuturePanel;
        SetTerrainType(tileInfo);
        SetResources(tileInfo);

        /* Switch statement checks for the passed Type of the tile,
           changing the color, Gold and Food Value's according to
           said type and assigns the Tile type to a string */
        switch (TerrainType)
        {
            case Terrain.Desert:
                _renderer.color = new Color(1f, 0.8f, 0f, 1f); ; //yellow 
                TileCoinValue += 0;
                TileFoodValue += 0;

                break;
            case Terrain.Plains:
                _renderer.color = new Color(0f, 1f, 0.29f, 1f); ; //green
                TileCoinValue += 0;
                TileFoodValue += 2;

                break;
            case Terrain.Hills:
                _renderer.color = new Color(0.4f, 0.6f, 0.7f, 1f); //grey
                TileCoinValue += 1;
                TileFoodValue += 1;

                break;
            case Terrain.Mountain:
                _renderer.color = new Color(0.62f, 0.32f, 0.17f, 1f); ; //brown
                TileCoinValue += 1;
                TileFoodValue += 0;

                break;
            case Terrain.Water:
                _renderer.color = new Color(0f, 0.17f, 1f, 1f); ; //blue
                TileCoinValue += 0;
                TileFoodValue += 1;

                break;
            default: //default is white
                _renderer.color = new Color(1f, 1f, 1f, 1f); //white
                TileCoinValue += 0;
                TileFoodValue += 0;

                break;
        }
        foreach (Resource r in Resources)
        {
            AddResourceValue(r);
        }
    }

    /// <summary>
    /// Method to apply Gold and Value modifications to Tile according to the
    /// resources it contains.
    /// </summary>
    /// <param name="resource"> Receives Resource to apply to tile as a
    /// String </param>
    private void AddResourceValue(Resource resource)
    {
        switch (resource)
        {
            case Resource.Animals:

                TileCoinValue += 1;
                TileFoodValue += 3;

                break;

            case Resource.Fossilfuel:

                TileCoinValue += 5;
                TileFoodValue += -3;

                break;

            case Resource.Luxury:

                TileCoinValue += 4;
                TileFoodValue += -1;

                break;

            case Resource.Metals:

                TileCoinValue += 3;
                TileFoodValue += -1;

                break;

            case Resource.Plants:

                TileCoinValue += 1;
                TileFoodValue += 2;

                break;

            case Resource.Pollution:

                TileCoinValue += -3;
                TileFoodValue += -3;

                break;

            default:
                break;
        }
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            forFuturePanel.gameObject.SetActive(false);
            _tilePanel.transform.
                    GetChild(3).GetChild(0).GetChild(0).
                    gameObject.SetActive(false);
            _tilePanel.transform.
                    GetChild(3).GetChild(0).GetChild(1).
                    gameObject.SetActive(false);
            _tilePanel.transform.
                    GetChild(3).GetChild(0).GetChild(2).
                    gameObject.SetActive(false);
            _tilePanel.transform.
                    GetChild(3).GetChild(0).GetChild(3).
                    gameObject.SetActive(false);
            _tilePanel.transform.
                    GetChild(3).GetChild(0).GetChild(4).
                    gameObject.SetActive(false);
            _tilePanel.transform.
                    GetChild(3).GetChild(0).GetChild(5).
                    gameObject.SetActive(false);
            _tilePanel.gameObject.SetActive(true);
            _tilePanel.transform.GetChild(0).
                GetComponent<RawImage>().color
                = _renderer.color;
            _tilePanel.transform.GetChild(0).
                GetChild(0).GetComponent<Text>().text
                = TerrainType.ToString();
            _tilePanel.transform.GetChild(1).
                GetChild(0).GetComponent<Text>().text
                = TileCoinValue.ToString();
            _tilePanel.transform.GetChild(2).
                GetChild(0).GetComponent<Text>().text
                = TileFoodValue.ToString();
            if (hasAnimals) _tilePanel.transform.
                    GetChild(3).GetChild(0).GetChild(0).
                    gameObject.SetActive(true);
            if (hasFossilFuel) _tilePanel.transform.
                    GetChild(3).GetChild(0).GetChild(1).
                    gameObject.SetActive(true);
            if (hasLuxury) _tilePanel.transform.
                    GetChild(3).GetChild(0).GetChild(2).
                    gameObject.SetActive(true);
            if (hasMetals) _tilePanel.transform.
                    GetChild(3).GetChild(0).GetChild(3).
                    gameObject.SetActive(true);
            if (hasPlants) _tilePanel.transform.
                    GetChild(3).GetChild(0).GetChild(4).
                    gameObject.SetActive(true);
            if (hasPollution) _tilePanel.transform.
                    GetChild(3).GetChild(0).GetChild(5).
                    gameObject.SetActive(true);
        }
    }
}