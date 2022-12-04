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
    [SerializeField] private IEnumerable<SpriteRenderer> _resourcesSpriteRenderer;
    // Declares the Tile's Sprite color based on its type
    [SerializeField] private Color _tileColor;
    // Declares Image to enable changes in the UI
    [SerializeField] private Image _tilePanel;
    // Declares bools to enable changes in the UI
    [SerializeField] private bool 
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
            hasAnimals = true;
        }

        if (resources.Contains("fossilfuel"))
        {
            Resources.Add(Resource.Fossilfuel);
            hasFossilFuel = true;
        }

        if (resources.Contains("luxury"))
        {
            Resources.Add(Resource.Luxury);
            hasLuxury = true;
        }

        if (resources.Contains("metals"))
        {
            Resources.Add(Resource.Metals);
            hasMetals = true;
        }

        if (resources.Contains("plants"))
        {
            Resources.Add(Resource.Plants);
            hasPlants = true;
        }

        if (resources.Contains("pollution"))
        {
            Resources.Add(Resource.Pollution);
            hasPollution = true;
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
    public void InitializeTile(string tileInfo, Image tilePanel)
    {
        //set the base values for the tile terrain type and tile resources
        SetResources(tileInfo);
        SetTerrainType(tileInfo);


        /* Switch statement checks for the passed Type of the tile,
           changing the color, Gold and Food Value's according to
           said type and assigns the Tile type to a string */
        switch (this.TerrainType)
        {
            case Terrain.Desert:
                _renderer.color = new Color(255, 209, 0, 255); //yellow 
                TileCoinValue += 0;
                TileFoodValue += 0;

                break;
            case Terrain.Plains:
                _renderer.color = new Color(0, 255, 75, 255); //green
                TileCoinValue += 0;
                TileFoodValue += 2;

                break;
            case Terrain.Hills:
                _renderer.color = new Color(104, 147, 188, 255); //grey
                TileCoinValue += 1;
                TileFoodValue += 1;

                break;
            case Terrain.Mountain:
                _renderer.color = new Color(255, 255, 255, 255); //white
                TileCoinValue += 1;
                TileFoodValue += 0;

                break;
            case Terrain.Water:
                _renderer.color = new Color(0, 43, 255, 255); //blue
                TileCoinValue += 0;
                TileFoodValue += 1;

                break;

            default: //default is desert
                _renderer.color = new Color(255, 209, 0, 255); //yellow
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

    public void SetTilePanel(Image tilePanel)
    {
        this._tilePanel = tilePanel;
    }




    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _tilePanel.gameObject.SetActive(true);
            _tilePanel.transform.GetChild(0).
                GetComponent<RawImage>().color
                = _renderer.color;
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

    /*
        /// <summary>
        /// Update method looks for ESC key presses to deactivate Tile's Camera and
        /// unlock the cursor. Both are important steps when closing the
        /// Tile Information panel, which is done by pressing the same key
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TileCamera.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
            }
        }

        /// <summary>
        /// Defines what happens when user places cursor over the Tile's Sprite
        /// </summary>
        private void OnMouseEnter()
        {
            // Highlight object becomes active, effectively graying out the Tile's
            // Sprite
            _highlight.SetActive(true);
        }

        /// <summary>
        /// Defines what happens when user removes cursor from the Tile's Sprite
        /// </summary>
        private void OnMouseExit()
        {
            // Highlight object becomes inactive, reverting the Tile's Sprite
            // to its default appearance
            _highlight.SetActive(false);
        }

        /// <summary>
        /// Defines what happens when user clicks over the Tile's Sprite
        /// </summary>
         private void OnMouseDown()
         {
             // Checks if Pointer is over UI element, and ignores click if so
             if (EventSystem.current.IsPointerOverGameObject())
                 return;

             // Finds Canvas game object in scene
             GameObject _canvas = GameObject.Find("Canvas");

             // Locks the cursor when the Tile is clicked, as this action opens the
             // Tile Info panel, and clicking on other Tiles while this panel is open
             // would result in conflict of Camera feeds into the Render Texture
             Cursor.lockState = CursorLockMode.Locked;

             TileCamera.SetActive(true);

             // Calls the DisplayFoodAndGold method from 
             // TileInformationDisplay script and passes it two integers
             _tileInfoDisplay.DisplayFoodAndGold(_tileGoldValue, _tileFoodValue);

             // Calls the DisplayTile method from 
             // TileInformationDisplay script and passes it a string 
             _tileInfoDisplay.DisplayTerrain(_tileType);

             // Calls the DisplayTile method from 
             // TileInformationDisplay script and passes it 6 bools 
             _tileInfoDisplay.DisplayResources(HasPlants,
                 HasAnimals, HasMetals, HasFossilFuel, HasLuxury, HasPollution);

             // Instantiates _tileInfoUI game object in scene
             GameObject TileInformation =
                 Instantiate(_tileInfoUI, _canvas.transform) as GameObject;
         }
         */

}
