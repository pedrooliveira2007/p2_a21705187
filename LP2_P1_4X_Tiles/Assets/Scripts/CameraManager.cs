using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    private float _cameraSpeed = 25.0f;
    private float _zoomSpeed = 10.0f;
    private float _minZoomDist = -5.0f;
    private float _maxZoomDist = -30.0f;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _cam.transform.position = new Vector3 (0.0f, 0.0f, -5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Zoom();
    }

    private void Move()
    {
        float _xinput = Input.GetAxis("Horizontal");
        float _yinput = Input.GetAxis("Vertical");

        Vector3 _dir = _cam.transform.up * _yinput + 
            _cam.transform.right * _xinput;

        _cam.transform.position += _dir * _cameraSpeed * Time.deltaTime;

        if (_cam.transform.position.x < 0)
        {
            _cam.transform.position = new Vector3(0, 
                _cam.transform.position.y, _cam.transform.position.z);
        }
        else if (_cam.transform.position.y > 0)
        {
            _cam.transform.position = 
                new Vector3(_cam.transform.position.x, 0.0f, 
                _cam.transform.position.z);
        }
    }

    private void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        
        _cam.transform.position += 
            _cam.transform.forward * scrollInput * _zoomSpeed;

        if (_cam.transform.position.z > _minZoomDist)
        {
            _cam.transform.position = 
                new Vector3(_cam.transform.position.x, 
                _cam.transform.position.y, _minZoomDist);
        }
        else if (_cam.transform.position.z < _maxZoomDist)
        {
            _cam.transform.position = 
            new Vector3(_cam.transform.position.x, 
                _cam.transform.position.y, _maxZoomDist);
        }
        
    }
}
