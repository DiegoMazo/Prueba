using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    private const ushort baseCamSize = 10;
    private const float camSizeMultipler = 0.5f;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 distance;
    private Camera cam;
    #region MonoBehaviour API
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, ushort.MinValue, ushort.MinValue) + distance;
        cam.orthographicSize = baseCamSize + (target.position.y * camSizeMultipler);
    }
    #endregion
}
