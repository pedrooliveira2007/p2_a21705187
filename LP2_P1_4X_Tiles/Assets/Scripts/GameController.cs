using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField] private FileHandler _fileHandlerModel = new FileHandler();
    [SerializeField] private ProcessMapInformation _processMapInformationModel;
    [SerializeField] private FileListUI _fileListView;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Image tilePanel;
    [SerializeField] private Image forFuturePanel;
    [SerializeField] private CameraManager _cameraManagerModel;
    [SerializeField] private ForFutureButtons _forFutureButtons;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _processMapInformationModel.SetTilePrefab(tilePrefab);
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

        _fileHandlerModel.SetFileName(buttonText.GetComponentInChildren<Text>().text);
        _fileHandlerModel.ReadFile();
        _processMapInformationModel.ReceiveMapInfo(_fileHandlerModel.MapInformation, tilePanel, forFuturePanel);
        _cameraManagerModel.ReceivePosition(_processMapInformationModel.GetBoundaries());
    }

 public void CallTilesWithResources()
    {
        IEnumerable<Tile> target = _processMapInformationModel.GetTiles();

        //target = target.Where(tile => tile.TerrainType == Terrain.Desert);

        _forFutureButtons.ForFutureButton1(target);
    }
 public void Button2()
    {
        IEnumerable<Tile> target = _processMapInformationModel.GetTiles();

        //target = target.Where(tile => tile.TerrainType == Terrain.Desert);

        _forFutureButtons.ForFutureButton2(target);
    }


    public void Button3()
    {
        IEnumerable<Tile> target = _processMapInformationModel.GetTiles();

        //target = target.Where(tile => tile.TerrainType == Terrain.Desert);

        _forFutureButtons.ForFutureButton3(target);
    }

public void Button4()
    {
        IEnumerable<Tile> target = _processMapInformationModel.GetTiles();

        //target = target.Where(tile => tile.TerrainType == Terrain.Desert);

        _forFutureButtons.ForFutureButton4(target);
    }


public void Button5()
    {
        IEnumerable<Tile> target = _processMapInformationModel.GetTiles();

        //target = target.Where(tile => tile.TerrainType == Terrain.Desert);

        _forFutureButtons.ForFutureButton5(target);
    }



















}