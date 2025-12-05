using UnityEngine;

public class ClickDino : MonoBehaviour
{
    public float clickRange = 1f;
    public PlayerAnimator playerAnimator;
    public LayerMask playerlayer;
    private Camera arCamera;
    void Start()
    {
        arCamera = Camera.main;
    }
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("[Attack] Mouse click detected", this);
            ClickToPlayer(Input.mousePosition);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ClickToPlayer(Input.mousePosition);
        }
#endif
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            Debug.Log($"[Attack] Touch detected. phase = {t.phase}", this);

            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("[Attack] Touch Began → TryAttack", this);
                ClickToPlayer(t.position);
            }
        }
        if (Input.touchCount == 2)
        {
            Touch t = Input.GetTouch(0);
            Debug.Log($"[Attack] Touch detected. phase = {t.phase}", this);

            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("[Attack] Touch Began → TryAttack", this);
                ClickToPlayer(t.position);
            }
        }
    }
    void ClickToPlayer(Vector2 screenPos)
    {
        Ray ray = arCamera.ScreenPointToRay(screenPos);
        if (!Physics.Raycast(ray, out RaycastHit hit, 100f, playerlayer))
        {
            Debug.Log("[Attack] Raycast: промах по playerlayer", this);
            return;
        }
        float distance = Vector3.Distance(transform.position, hit.transform.position);
        if (distance > clickRange)
        {
            Debug.Log($"[Attack] Враг слишком далеко: {distance} > {clickRange}", this);
            return;
        }
        if (hit.collider.gameObject && distance <= clickRange)
        {
            if (Input.touchCount == 2 || Input.GetMouseButtonDown(1))
                Animation2();
            else
                Animation1();
        }
    }
    void Animation1()
    {
        if (playerAnimator != null)
            playerAnimator.Dance();
    }
    void Animation2()
    {
        if (playerAnimator != null)
            playerAnimator.Action();
    }
}
