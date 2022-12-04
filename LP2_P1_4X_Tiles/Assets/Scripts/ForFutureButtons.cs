using UnityEngine.UI;
using UnityEngine;

public class ForFutureButtons : MonoBehaviour
{
    // Declares a variable to be assigned in-editor
    [SerializeField] private Image forFuturePanel;
    
    /// <summary>
    /// Method that changes text on a respective child game object
    /// </summary>
    public void ForFutureButton1()
    {
        // Changes the display text of the objects child text component
        forFuturePanel.GetComponentInChildren<Text>().text = "For the future 1...";
    }

    /// <summary>
    /// Method that changes text on a respective child game object
    /// </summary>
    public void ForFutureButton2()
    {
        // Changes the display text of the objects child text component
        forFuturePanel.GetComponentInChildren<Text>().text = "For the future 2...";
    }

    /// <summary>
    /// Method that changes text on a respective child game object
    /// </summary>
    public void ForFutureButton3()
    {
        // Changes the display text of the objects child text component
        forFuturePanel.GetComponentInChildren<Text>().text = "For the future 3...";
    }

    /// <summary>
    /// Method that changes text on a respective child game object
    /// </summary>
    public void ForFutureButton4()
    {
        // Changes the display text of the objects child text component
        forFuturePanel.GetComponentInChildren<Text>().text = "For the future 4...";
    }

    /// <summary>
    /// Method that changes text on a respective child game object
    /// </summary>
    public void ForFutureButton5()
    {
        // Changes the display text of the objects child text component
        forFuturePanel.GetComponentInChildren<Text>().text = "For the future 5...";
    }
}