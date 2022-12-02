using UnityEngine.SceneManagement;
using UnityEngine;

public class FileButton : MonoBehaviour
{
    public static string _buttonText;

    public void OnClick()
    {
        _buttonText = gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text;
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
}
