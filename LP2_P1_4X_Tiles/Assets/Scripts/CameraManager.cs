using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Declare variables and one of them to be assigned in-editor
    [SerializeField] private Camera _cam;
    private float _cameraSpeed = 25.0f;
    private float _zoomSpeed = 10.0f;
    private float _minZoomDist = -5.0f;
    private float _maxZoomDist = -30.0f;
    private Vector2 _boundaries;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Calls these 2 methods each Update
        Move();
        Zoom();
    }

    /// <summary>
    /// Assigns incoming Vector2 variable
    /// </summary>
    /// <param name="_boundariesPos"> Registers the last tiles' coordinates 
    /// for the clamp </param>
    internal void ReceivePosition(Vector2 _boundariesPos)
    {
        // Assigns value to local Vector2 variable
        _boundaries = _boundariesPos;

        // Calls the method and passes it the coordinates values
        SetInitialPos();
    }

    /// <summary>
    /// Sets the camera's initial position to be in the middle of the map
    /// </summary>
    private void SetInitialPos()
    {
        // Sets the initial camera position
        _cam.transform.position = 
            new Vector3 ((_boundaries.x/2), (_boundaries.y/2), -5.0f);
    }

    /// <summary>
    /// Manages the movement of the camera
    /// </summary>
    private void Move()
    {
        // Declares two variables to register input on the X and Y axis
        float _xinput = Input.GetAxis("Horizontal");
        float _yinput = Input.GetAxis("Vertical");

        // Declares and assigns Vector3 variable to register the camera movement
        Vector3 _dir = _cam.transform.up * _yinput + 
            _cam.transform.right * _xinput;

        // Moves the camera
        _cam.transform.position += _dir * _cameraSpeed * Time.deltaTime;

        // Verification to halt camera movement if the limits are reached
        if (_cam.transform.position.x < 0)
        {
            // Stops the camera from moving past a certain threshold
            _cam.transform.position = 
                new Vector3(0, 
                _cam.transform.position.y, _cam.transform.position.z);
        }
        // Verification to halt camera movement if the limits are reached
        if (_cam.transform.position.y > 0)
        {
            // Stops the camera from moving past a certain threshold
            _cam.transform.position = 
                new Vector3(_cam.transform.position.x, 0.0f, 
                _cam.transform.position.z);
        }
        // Verification to halt camera movement if the limits are reached
        if (_cam.transform.position.x > _boundaries.x)
        {
            // Stops the camera from moving past a certain threshold
            _cam.transform.position = 
            new Vector3(_boundaries.x, 
                _cam.transform.position.y, _cam.transform.position.z);
        }
        // Verification to halt camera movement if the limits are reached
        if (_cam.transform.position.y < _boundaries.y)
        {
            // Stops the camera from moving past a certain threshold
            _cam.transform.position = 
                new Vector3(_cam.transform.position.x, _boundaries.y, 
                _cam.transform.position.z);
        }
    }

    /// <summary>
    /// Manages the zoom of the camera
    /// </summary>
    private void Zoom()
    {
        // Declares a variable to register input in the Z axis
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        
        // Moves the camera
        _cam.transform.position += 
            _cam.transform.forward * scrollInput * _zoomSpeed;

        // Verification to halt the camera from moving past a certain threshold
        if (_cam.transform.position.z > _minZoomDist)
        {
            // Stops the camera from moving past a certain threshold
            _cam.transform.position = 
                new Vector3(_cam.transform.position.x, 
                _cam.transform.position.y, _minZoomDist);
        }
        // Verification to halt the camera from moving past a certain threshold
        else if (_cam.transform.position.z < _maxZoomDist)
        {
            // Stops the camera from moving past a certain threshold
            _cam.transform.position = 
            new Vector3(_cam.transform.position.x, 
                _cam.transform.position.y, _maxZoomDist);
        }
        
    }
}
