using UnityEngine;

public class BananaStickPush : MonoBehaviour
{
    [SerializeField] Collider2D colider;
    private Camera cam;
    private bool isPressed = false;
    private Vector3 stickOrigin;
    private Vector2 stickSpeedRef = Vector2.zero;
    [SerializeField] private float stickSpeed;
    [SerializeField] float yTrigger;
    [SerializeField] float yBorder;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        stickOrigin = transform.position;
        Debug.Log(stickOrigin);
    }

    // Update is called once per frame
    void Update()
    {
        MousePressCheck();
        StickPositionUpdate();
        if(transform.position.y >= yTrigger)
        {
            GameEvent.current.IngredientPress(name);
        }
    }
    private void StickPositionUpdate()
    {
        if (Input.GetMouseButton(0) && isPressed)
        {
            Vector2 nextPos = Vector2.SmoothDamp(transform.position, new Vector2(-stickOrigin.y + stickOrigin.x + GetMouseWorldPosition().y, +GetMouseWorldPosition().y), ref stickSpeedRef, stickSpeed);
            if (nextPos. y >= yBorder && nextPos.y <= yTrigger+0.1)
            {
                this.transform.position = nextPos;
            }
        }
        else
        {
            isPressed = false;
        }
    }
    private void MousePressCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Get2DBounds(colider.bounds).Contains(GetMouseWorldPosition()))
            {
                isPressed = true;
            }
        }
    }

    private Bounds Get2DBounds(Bounds aBounds)
    {
        Vector3 ext = aBounds.extents;
        ext.z = float.PositiveInfinity;
        aBounds.extents = ext;
        return aBounds;
    }
    Vector3 GetMouseWorldPosition() => cam.ScreenToWorldPoint(
    new Vector3(
        Input.mousePosition.x,
        Input.mousePosition.y,
        cam.nearClipPlane));
}
