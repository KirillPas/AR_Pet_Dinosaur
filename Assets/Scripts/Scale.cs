using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Scale : MonoBehaviour
{
    [Header("FOV Pinch Zoom")]
    public float minFOV = 10f;
    public float maxFOV = 60f;
    public float startFOV = 40f;
    public float sensitivity = 0.15f;

    private Camera cam;
    private ARCameraManager arCameraManager;
    private float targetFOV, previousDistance;
    private bool isPinching;
    private float aspect;

    void Start()
    {
        cam = GetComponent<Camera>();
        arCameraManager = GetComponent<ARCameraManager>();

        if (arCameraManager == null)
        {
            Debug.LogError("❌ ARCameraManager не найден на " + gameObject.name);
            enabled = false;
            return;
        }

        arCameraManager.frameReceived += OnCameraFrameReceived;
        targetFOV = startFOV;
        aspect = cam.aspect;
        Debug.Log($"✅ AR FOV Zoom: {startFOV} ({minFOV}-{maxFOV})");
    }
    void OnDestroy()
    {
        if (arCameraManager != null)
            arCameraManager.frameReceived -= OnCameraFrameReceived;
    }
    void OnCameraFrameReceived(ARCameraFrameEventArgs eventArgs)
    {
        if (!eventArgs.projectionMatrix.HasValue) return;

        Matrix4x4 projection = eventArgs.projectionMatrix.Value;

        float fovRad = targetFOV * Mathf.Deg2Rad;
        float cotHalfFov = 1f / Mathf.Tan(fovRad * 0.5f);

        projection[0, 0] = cotHalfFov / aspect;
        projection[1, 1] = cotHalfFov;

        cam.projectionMatrix = projection;
    }
    void Update()
    {
        HandlePinch();
    }
    void HandlePinch()
    {
        if (Input.touchCount != 2)
        {
            isPinching = false;
            return;
        }

        float currentDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);

        if (!isPinching)
        {
            previousDistance = currentDistance;
            isPinching = true;
            return;
        }

        float delta = (previousDistance - currentDistance) * sensitivity;
        targetFOV = Mathf.Clamp(targetFOV + delta, minFOV, maxFOV);
        previousDistance = currentDistance;
    }
    public void ResetFOV()
    {
        targetFOV = startFOV;
    }
}
