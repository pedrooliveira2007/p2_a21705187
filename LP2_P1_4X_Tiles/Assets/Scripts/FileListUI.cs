using UnityEngine;
using System.Collections.Generic;

public class FileListUI : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject noFiles;

    private List<GameObject> files;

    internal void PopulateFileUIList(IEnumerable<string> filesInFolder)
    {
        files = new List<GameObject>();

        if ((filesInFolder as List<string>).Count == 0)
        { // Gives no files message
            noFiles.SetActive(true);
            button.SetActive(false);
        }
        else // if there are files inside
        { // Creates a button with the file name for each file
            foreach (string f in filesInFolder)
            {
                files.Add(Instantiate(button,
                    (button.transform.position),
                    button.transform.rotation, button.transform.parent));
                files[files.Count - 1].
                    GetComponentInChildren<UnityEngine.UI.Text>().text = f;
            }
            // Deactivates original button
            button.SetActive(false);
        }

    }

}