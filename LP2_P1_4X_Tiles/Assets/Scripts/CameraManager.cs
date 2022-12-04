using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private float _cameraSpeed = 25.0f;
    private float _zoomSpeed = 10.0f;
    private float _minZoomDist = -5.0f;
    private float _maxZoomDist = -30.0f;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        transform.position = new Vector3 (0.0f, 0.0f, -5.0f);
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

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, 
                transform.position.y, transform.position.z);
        }

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0.0f, 
                transform.position.z);
        }
    }

    private void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        
        transform.position += 
            transform.forward * scrollInput * _zoomSpeed;

        if (transform.position.z > _minZoomDist)
        {
            transform.position = new Vector3(transform.position.x, 
                transform.position.y, _minZoomDist);
        }
        else if (transform.position.z < _maxZoomDist)
        {
            transform.position = new Vector3(transform.position.x, 
                transform.position.y, _maxZoomDist);
        }
        
    }
}
