using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private float _cameraSpeed = 500.0f;
    [SerializeField] private float _zoomSpeed = 50.0f;
    [SerializeField] private float _minZoomDist = -200.0f;
    [SerializeField] private float _maxZoomDist = -1000.0f;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        _camera = Camera.main;
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

        Vector3 _dir = transform.up * _yinput + transform.right * _xinput;

        transform.position += _dir * _cameraSpeed * Time.deltaTime;
    }

    private void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        float dist = 
            Vector3.Distance(transform.position, _camera.transform.position);

        if (dist < _minZoomDist && scrollInput > 0.0f)
            return;
        else if (dist > _maxZoomDist && scrollInput < 0.0f)
            return;
        
        _camera.transform.position += 
            _camera.transform.forward * scrollInput * _zoomSpeed;
    }
}
