using UnityEngine;
using System.Collections;

public class CuttingManager : MonoBehaviour
{
    private Vector3 mouseStartPosition = Vector2.zero;
    private Vector3 mouseEndPosition = Vector2.zero;
    [SerializeField] Collider2D coliderStart;
    [SerializeField] Collider2D coliderEnd;
    private bool trackLineWithMouse = false;
    private Camera cam;
    private Vector2 nullPos;
    [SerializeField] private LineRenderer lRend;
    [SerializeField] private CuttingManager nextCut;
    [SerializeField] private Vector3 sliceLandPositionOffset;
    [SerializeField] private float sliceLandSpeed;
    private Vector3 sliceSpeedRef = Vector3.zero;
    private Vector3 sliceOrigin;
    [SerializeField] private bool isActive;

    void Start()
    {
        cam = Camera.main;
        nullPos = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        lRend.enabled = false;
        sliceOrigin = transform.position;
        if(isActive)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }
    void Update()
    {
        if(isActive)
        {
            StartPosCheckOnMouseDown();
            if (Input.GetMouseButton(0) && trackLineWithMouse)
            {
                lRend.SetPosition(1, GetMouseWorldPosition());
            }
            EndPosCheckOnMouseUp();
        }
    }
    Vector3 GetMouseWorldPosition() => cam.ScreenToWorldPoint(
        new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            cam.nearClipPlane));
    void Activate() => isActive = true;
    void Deactivate() => isActive = false;
    void StartPosCheckOnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Get2DBounds(coliderStart.bounds).Contains(GetMouseWorldPosition()))
            {
                mouseStartPosition = GetMouseWorldPosition();
                trackLineWithMouse = true;
                lRend.enabled = true;
                lRend.SetPosition(0, mouseStartPosition);
            }
            else
            {
                mouseStartPosition = nullPos;
                trackLineWithMouse = false;
                lRend.enabled = false;
            }
        }
    }
    void EndPosCheckOnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (Get2DBounds(coliderEnd.bounds).Contains(GetMouseWorldPosition()))
            {
                trackLineWithMouse = false;
                lRend.enabled = false;
                StartCoroutine(EraseLine());
                this.Deactivate();
                if (nextCut != null)
                {
                    nextCut.Activate();
                }
            }
            else
            {
                mouseStartPosition = nullPos;
                trackLineWithMouse = false;
                lRend.enabled = false;
            }
        }
    }
    IEnumerator EraseLine()
    {
        while (transform.position != sliceOrigin + sliceLandPositionOffset)
        {
            transform.position = Vector3.SmoothDamp(transform.position, sliceOrigin + sliceLandPositionOffset, ref sliceSpeedRef, sliceLandSpeed);
            yield return null;
        }
        if (nextCut == null)
        {
            GameEvent.current.IngredientPress("Cutting");
        }
    }
    private Bounds Get2DBounds(Bounds aBounds)
    {
        Vector3 ext = aBounds.extents;
        ext.z = float.PositiveInfinity;
        aBounds.extents = ext;
        return aBounds;
    }
}
