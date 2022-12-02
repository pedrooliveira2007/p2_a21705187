using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    // Declares a TileInformationDisplay variable 
    [SerializeField] private SelectedTileInfo _tileInfoDisplay;

    // Declares GameObject variable component to use on mouse-over
    [SerializeField] private GameObject _tileInfoUI;

    // Declares GameObject variable of Highlight component to use on mouse-over
    [SerializeField] private GameObject _highlight;

    // Declares SpriteRenderer variable to enable later changes of Sprite's color
    [SerializeField] private SpriteRenderer _renderer;

    // Declares GameObject variable named TileCamera to later assign in editor
    // and use to visually display the Tile inside the Tile Info panel in
    // combination with a Render Texture applied to an Image on the Canvas
    [SerializeField] private GameObject TileCamera;

    // Declares Type attribute for the Tile from the set defined by enum
    // TileTypes
    public TileType Type;

    // Declares string variable to store the Tile's type
    private string _tileType;

    // Declares different Food and Gold values given by each Tile's Type
    private int _desertGold = 0;
    private int _desertFood = 0;
    private int _grasslandGold = 0;
    private int _grasslandFood = 2;
    private int _hillsGold = 1;
    private int _hillsFood = 1;
    private int _mountainGold = 1;
    private int _mountainFood = 0;
    private int _oceanGold = 0;
    private int _oceanFood = 1;

    // Declares different colors to be applied to the Tile's Sprite based on its
    // type
    [SerializeField]
    private Color
        _desertColor,
        _grasslandColor,
        _hillsColor,
        _mountainColor,
        _oceanColor,
        _defaultColor;

    // Declares different Food and Gold value modifiers
    // given by each Resource present on Tile
    private int plantsGoldMod = 1;
    private int plantsFoodMod = 2;
    private int animalsGoldMod = 2;
    private int animalsFoodMod = 3;
    private int metalsGoldMod = 3;
    private int metalsFoodMod = -1;
    private int fossilfuelGoldMod = 4;
    private int fossilfuelFoodMod = -2;
    private int luxuryGoldMod = 4;
    private int luxuryFoodMod = 0;
    private int pollutionGoldMod = -2;
    private int pollutionFoodMod = -3;


    // Declares variables for the Tile's Gold and Food overall Value
    public int _TileGoldValue;
    public int _TileFoodValue;

    // Defines booleans to determine if a given resource is present on the Tile
    private bool HasPlants;
    private bool HasAnimals;
    private bool HasMetals;
    private bool HasFossilFuel;
    private bool HasLuxury;
    private bool HasPollution;

    // Declares a list of strings to store all the resources present in a tile
    private List<string> _allResources = new List<string>();

    // Declares a game object variable for each of the resource sprites
    [SerializeField] private GameObject _plantsSprite;
    [SerializeField] private GameObject _animalsSprite;
    [SerializeField] private GameObject _metalsSprite;
    [SerializeField] private GameObject _fossilFuelSprite;
    [SerializeField] private GameObject _luxurySprite;
    [SerializeField] private GameObject _pollutionSprite;

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
        _tileInfoDisplay.DisplayFoodAndGold(_TileGoldValue, _TileFoodValue);

        // Calls the DisplayTile method from 
        // TileInformationDisplay script and passes it a string 
        _tileInfoDisplay.DisplayTileType(_tileType);

        // Calls the DisplayTile method from 
        // TileInformationDisplay script and passes it 6 bools 
        _tileInfoDisplay.DisplayResources(HasPlants,
            HasAnimals, HasMetals, HasFossilFuel, HasLuxury, HasPollution);

        // Instantiates _tileInfoUI game object in scene
        GameObject TileInformation =
            Instantiate(_tileInfoUI, _canvas.transform) as GameObject;
    }

    /// <summary>
    /// Method colors the tile in its default color, without altering any
    /// of its default properties or attributes
    /// </summary>
    public void Init()
    {
        _renderer.color = _defaultColor;
    }

    /// <summary>
    /// Overloads previous Init() method implementation, coloring the
    /// tile and altering its properties and attributes according to
    /// its type
    /// </summary>
    /// <param name="type"> A given Tile's type, from the available
    /// items in TileTypes enum </param>
    public void Init(TileType type)
    {
        this.Type = type;

        // Switch statement checks for the passed Type of the tile,
        // changing the color, Gold and Food Value's according to
        // said type and assigns the Tile type to a string
        switch (type)
        {
            case TileType.desert:
                _renderer.color = _desertColor;
                _TileGoldValue += _desertGold;
                _TileFoodValue += _desertFood;
                _tileType = "Desert";
                break;
            case TileType.grassland:
                _renderer.color = _grasslandColor;
                _TileGoldValue += _grasslandGold;
                _TileFoodValue += _grasslandFood;
                _tileType = "Grassland";
                break;
            case TileType.hills:
                _renderer.color = _hillsColor;
                _TileGoldValue += _hillsGold;
                _TileFoodValue += _hillsFood;
                _tileType = "Hills";
                break;
            case TileType.mountain:
                _renderer.color = _mountainColor;
                _TileGoldValue += _mountainGold;
                _TileFoodValue += _mountainFood;
                _tileType = "Mountain";
                break;
            case TileType.ocean:
                _renderer.color = _oceanColor;
                _TileGoldValue += _oceanGold;
                _TileFoodValue += _oceanFood;
                _tileType = "Ocean";
                break;
        }
    }


    /// <summary>
    /// Method to apply Gold and Value modifications to Tile according to the
    /// resources it contains. Compares the given Resource using "if" and
    /// "else if" statements to decide which modifications to apply
    /// </summary>
    /// <param name="resource"> Receives Resource to apply to tile as a
    /// String </param>
    public void ChangeTileValues(string resource)
    {
        if (resource == "plants")
        {
            _TileGoldValue += plantsGoldMod;
            _TileFoodValue += plantsFoodMod;
            HasPlants = true;
            _plantsSprite.SetActive(true);
        }

        else if (resource == "animals")
        {
            _TileGoldValue += animalsGoldMod;
            _TileFoodValue += animalsFoodMod;
            HasAnimals = true;
            _animalsSprite.SetActive(true);
        }

        else if (resource == "metals")
        {
            _TileGoldValue += metalsGoldMod;
            _TileFoodValue += metalsFoodMod;
            HasMetals = true;
            _metalsSprite.SetActive(true);
        }

        else if (resource == "fossilfuel")
        {
            _TileGoldValue += fossilfuelGoldMod;
            _TileFoodValue += fossilfuelFoodMod;
            HasFossilFuel = true;
            _fossilFuelSprite.SetActive(true);
        }

        else if (resource == "luxury")
        {
            _TileGoldValue += luxuryGoldMod;
            _TileFoodValue += luxuryFoodMod;
            HasLuxury = true;
            _luxurySprite.SetActive(true);
        }

        else if (resource == "pollution")
        {
            _TileGoldValue += pollutionGoldMod;
            _TileFoodValue += pollutionFoodMod;
            HasPollution = true;
            _pollutionSprite.SetActive(true);
        }
    }


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
}
