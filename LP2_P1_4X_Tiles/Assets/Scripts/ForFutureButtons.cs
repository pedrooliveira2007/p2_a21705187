using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class ForFutureButtons : MonoBehaviour
{
    // Declares a variable to be assigned in-editor
    [SerializeField] private Image forFuturePanel;
    
    /// <summary>
    /// Method that changes text on a respective child game object
    /// </summary>
    public void ForFutureButton1(IEnumerable<Tile> tileList)
    {
        IEnumerable<Tile> target = tileList;

        target = target.Where(tile => tile.Resources.Count()>=2);

        // Changes the display text of the objects child text component
        forFuturePanel.GetComponentInChildren<Text>().text = target.Count().ToString();
    }

    /// <summary>
    /// Method that changes text on a respective child game object
    /// </summary>
    public void ForFutureButton2(IEnumerable<Tile> tileList)
    {
        IEnumerable<Tile> target = tileList;

        target = target.Where(tile => tile.TerrainType != Terrain.Desert);
        int value = 0;

        foreach(Tile t in target){
            value += t.TileCoinValue;
        }


        // Changes the display text of the objects child text component
        forFuturePanel.GetComponentInChildren<Text>().text = value.ToString();
    }

    /// <summary>
    /// Method that changes text on a respective child game object
    /// </summary>
    public void ForFutureButton3(IEnumerable<Tile> tileList)
    {
        IEnumerable<Tile> target = tileList;

        target = target.Where(tile => tile.Resources.Count()>2);
        string s = "";
        foreach(Tile t in target){
            s+= t.TerrainType +"  "+ t.Resources.ToString()+"  "+ t.gameObject.transform.pos.ToString();

        }

        // Changes the display text of the objects child text component
        forFuturePanel.GetComponentInChildren<Text>().text = target.Count().ToString();
    }

    /// <summary>
    /// Method that changes text on a respective child game object
    /// </summary>
    public void ForFutureButton4(IEnumerable<Tile> tileList)
    {
        IEnumerable<Tile> target = tileList;

        target = target.Where(tile => tile.Resources.Contains(Resource.Luxury)).Where(tile=>tile.TerrainType == Terrain.Plains);

        // Changes the display text of the objects child text component
        forFuturePanel.GetComponentInChildren<Text>().text = target.Count() >0? "contem":"não contem";
    }

    /// <summary>
    /// Method that changes text on a respective child game object
    /// </summary>
    public void ForFutureButton5(IEnumerable<Tile> tileList)
    {
        IEnumerable<Tile> target = tileList;

        target = target.Where(tile => tile.Resources.Count()>2);

        // Changes the display text of the objects child text component
        forFuturePanel.GetComponentInChildren<Text>().text = target.Count().ToString();
    }
}