using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileSelect : MonoBehaviour
{
    [SerializeField]
    private GameObject button;

    [SerializeField]
    private GameObject noFiles;

    private List<GameObject> files;

    private FileInfo[] info;

    private void Start()
    {
        FileScanner();
    }

    private void FileScanner()
    {
        files = new List<GameObject>();
        // Searches for the map4xfiles folder
        try
        {
            DirectoryInfo dir = new DirectoryInfo($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}"
                + Path.DirectorySeparatorChar + @"map4xfiles");
            // Searches for .map4x files inside the folder
            info = dir.GetFiles("*.map4x");

            // If there are no files inside
            if (info.Length == 0)
            { // Gives no files message
                noFiles.SetActive(true);
                button.SetActive(false);
            }
            else // if there are files inside
            { // Creates a button with the file name for each file
                foreach (FileInfo f in info)
                {
                    files.Add(Instantiate(button, (button.transform.position), button.transform.rotation, button.transform.parent));
                    files[files.Count - 1].GetComponentInChildren<UnityEngine.UI.Text>().text = f.Name;
                }
                // Deactivates original button
                button.SetActive(false);
            }
        }
        catch
        {
            noFiles.SetActive(true);
            button.SetActive(false);
        }
    }

    public void Refresh()
    {
        noFiles.SetActive(false);
        foreach (FileInfo f in info)
        {
            Destroy(files[0]);
            files.RemoveAt(0);
        }
        button.SetActive(true);
        FileScanner();
    }
}
