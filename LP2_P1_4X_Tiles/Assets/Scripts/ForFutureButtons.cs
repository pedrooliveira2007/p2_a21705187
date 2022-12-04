using UnityEngine;

public class ForFutureButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject forFuturePanel;
    public void ForFutureButton1()
    {
        forFuturePanel.GetComponentInChildren<UnityEngine.UI.Text>().text = "For the future 1...";
    }
    public void ForFutureButton2()
    {
        forFuturePanel.GetComponentInChildren<UnityEngine.UI.Text>().text = "For the future 2...";
    }
    public void ForFutureButton3()
    {
        forFuturePanel.GetComponentInChildren<UnityEngine.UI.Text>().text = "For the future 3...";
    }
    public void ForFutureButton4()
    {
        forFuturePanel.GetComponentInChildren<UnityEngine.UI.Text>().text = "For the future 4...";
    }
    public void ForFutureButton5()
    {
        forFuturePanel.GetComponentInChildren<UnityEngine.UI.Text>().text = "For the future 5...";
    }
}
