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


    void Start()
    {

        //gather file names and the folder path
        _fileHandlerModel.GatherFolderAndFiles();
        //populates the button list with the files
        _fileListView.PopulateFileUIList(_fileHandlerModel.FilesInFolder);
    }









    /// <summary>
    /// Method to be used at the file button, reading the specific file and loading the 
    /// next scene
    /// </summary>
    public void LoadSceneWithFile()
    {
        _fileHandlerModel.FileName =
            gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text; ;
        _fileHandlerModel.GatherFolderAndFiles();
        _processMapInformationModel.ReceiveMapInfo(_fileHandlerModel.MapInformation);
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }

}
