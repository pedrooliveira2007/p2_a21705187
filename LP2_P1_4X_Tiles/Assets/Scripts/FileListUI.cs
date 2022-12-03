using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileListUI : MonoBehaviour
{
    [SerializeField]
    private GameObject button;

    [SerializeField]
    private GameObject noFiles;

    private List<GameObject> files;



    internal void PopulateFileUIList(IEnumerable<string> filesInFolder)
    {
        files = new List<GameObject>();

        if (((List<string>)filesInFolder).Count == 0)
            { // Gives no files message
                noFiles.SetActive(true);
                button.SetActive(false);
            }
            else // if there are files inside
            { // Creates a button with the file name for each file
                foreach (string f in filesInFolder)
                {
                Console.WriteLine("aaa"+f);
                    files.Add(Instantiate(button, (button.transform.position), button.transform.rotation, button.transform.parent));
                    files[files.Count - 1].GetComponentInChildren<UnityEngine.UI.Text>().text = f;
                }
                // Deactivates original button
                button.SetActive(false);
            }
       
    }

    public void Refresh(string[] filesInFolder)
    {
        noFiles.SetActive(false);
        foreach (string f in filesInFolder)
        {
            Destroy(files[0]);
            files.RemoveAt(0);
        }
        button.SetActive(true);
        PopulateFileUIList(filesInFolder);
    }


}
