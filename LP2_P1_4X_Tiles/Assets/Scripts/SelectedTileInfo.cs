using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays the information about the tile that is clicked on
/// </summary>
public class SelectedTileInfo : MonoBehaviour
{
    // Declares a text variable to be assigned in editor
    [SerializeField]
    private Text _tileType;
    // Declares a text variable to be assigned in editor
    [SerializeField]
    private Text _resources;
    // Declares a text variable to be assigned in editor
    [SerializeField]
    private Text _foodValue;
    // Declares a text variable to be assigned in editor
    [SerializeField]
    private Text _goldValue;
    // Declares a private string to store the tile's resources
    private string _totalResources;

    /// <summary>
    /// Called once every frame
    /// </summary>
    private void Update()
    {
        // Checks if the user has pressed the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Calls the DestroyInfoUI() method
            DestroyInfoUI();
        }
    }


    /// <summary>
    /// Displays the gold and food values of the targeted tile
    /// </summary>
    /// <param name="_tileFood"> Total food a tile has </param>
    /// <param name="_tileGold"> Total gold a tile has </param>
    public void DisplayFoodAndGold(int _tileGold, int _tileFood)
    {
        // Sets the text component of the game object _goldValue to display 
        // the _tileGold integer that is converted to a string
        _goldValue.text = _tileGold.ToString();
        // Sets the text component of the game object _foodValue to display 
        // the _tileFood integer that is converted to a string
        _foodValue.text = _tileFood.ToString();
    }

    /// <summary>
    /// Displays the tile type of the targeted tile
    /// </summary>
    /// <param name="_type"></param>
    public void DisplayTerrain(string _type)
    {
        // Sets the text component of the game object _tileType to display
        // the _type string
        _tileType.text = _type;
    }

    /// <summary>
    /// Displays the resources of the targeted tile
    /// </summary>
    /// <param name="hasPlants"> A bool that returns true or false if the tile
    /// has or does not have Plants </param>
    /// <param name="hasAnimals"> A bool that returns true or false if the tile
    /// has or does not have Animals </param>
    /// <param name="hasMetals"> A bool that returns true or false if the tile
    /// has or does not have Metals </param>
    /// <param name="hasFossilFuel"> A bool that returns true or false if the
    /// tile has or does not have Fossil Fuel </param>
    /// <param name="hasLuxury"> A bool that returns true or false if the tile
    /// has or does not have Luxury </param>
    /// <param name="hasPollution"> A bool that returns true or false if the
    /// tile has or does not have Pollution </param>
    public void DisplayResources(bool hasPlants, bool hasAnimals,
        bool hasMetals, bool hasFossilFuel, bool hasLuxury, bool hasPollution)
    {
        // A string that displays all the resources and if they are or not
        // present on the target tile
        string _totalResources = $"Plants: {hasPlants} | Animals: {hasAnimals}"
        + $" |  Metals: {hasMetals} | Fossil Fuel: {hasFossilFuel} | " +
        $"Luxury: {hasLuxury} | Pollution: {hasPollution}";

        // Sets the text component of the game object _resources to display
        // the _totalResources string
        _resources.text = _totalResources;
    }

    /// <summary>
    /// Destroys the game object this script is attached to in the scene
    /// </summary>
    public void DestroyInfoUI()
    {
        // Sets all the game objects' text component to an empty string
        _tileType.text = "";
        _resources.text = "";
        _foodValue.text = "";
        _goldValue.text = "";

        // Destroys the game object the script is attached to
        Destroy(gameObject);
    }
}