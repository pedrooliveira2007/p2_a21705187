using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private FileHandler _fileHandlerModel = new FileHandler();
    [SerializeField] private ProcessMapInformation _processMapInformationModel;

    [SerializeField] private FileListUI _fileListView;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    public void LoadFileList()
    {

        //gather file names and the folder path
        _fileHandlerModel.GatherFolderAndFiles();
        //populates the button list with the files
        _fileListView.PopulateFileUIList(_fileHandlerModel.GetFilesInFolderNames());
    }

    /// <summary>
    /// Method to be used at the file button, reading the specific file and loading the 
    /// next scene
    /// </summary>
    public void LoadMenuWithFile(GameObject buttonText)
    {

        _fileHandlerModel.SetFileName(buttonText.GetComponentInChildren<UnityEngine.UI.Text>().text);
        _fileHandlerModel.ReadFile();
        _processMapInformationModel.ReceiveMapInfo(_fileHandlerModel.MapInformation);
        _processMapInformationModel.ProcessTileInformation(_fileHandlerModel.MapInformation);
    }

}
