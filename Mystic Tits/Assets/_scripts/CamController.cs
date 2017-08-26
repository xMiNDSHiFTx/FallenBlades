using UnityEngine;

public class CamController : MonoBehaviour 
{
    #region Variables
    public Transform target;
    public Vector3 offset;
    public float pitch;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15;
    public float yawSpeed = 100f;

    private float currentyaw = 0f;
    private float currentZoom =10f;
    #endregion

    #region Unity Methods
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentyaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    void LateUpdate () 
	{
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position, Vector3.up, currentyaw);
	}
	#endregion
}
