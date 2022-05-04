using UnityEngine;

public class MouseRotationStiring : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private SpriteRenderer blankLayer;
    [SerializeField] private SpriteRenderer dyedLayer;
    [Range(0f, 1f)] [SerializeField] private float initialAlpha;
    private float deltaAngleSum = 0f;
    [Range(1, 10)] [SerializeField] private int turns;
    // Start is called before the first frame update
    void Start()
    {
        changeSpriteAlpha(blankLayer, initialAlpha);
        changeSpriteAlpha(dyedLayer, 0f);
        cam = Camera.main;
    }

    void Update()
    {
        rotateSelf();
        swapAlpha();
        if(deltaAngleSum >= turns*360)
        {
            GameEvent.current.IngredientPress("Stiring");
        }
    }
    Vector2 GetMouseWorldPosition() => cam.ScreenToWorldPoint(
        new Vector2(
            Input.mousePosition.x,
            Input.mousePosition.y));
    void changeSpriteAlpha(SpriteRenderer sprtRend,float alpha)
    {
        Color tmp = sprtRend.color;
        tmp.a = alpha;
        sprtRend.color = tmp;
    }
    void swapAlpha()
    {
        changeSpriteAlpha(blankLayer, 1- (initialAlpha / (turns * 360 / deltaAngleSum)));
        changeSpriteAlpha(dyedLayer, initialAlpha / (turns * 360 / deltaAngleSum));
    }
    void rotateSelf()
    {
        float angle = Vector3.SignedAngle(transform.right, -new Vector2(transform.position.x, transform.position.y) + GetMouseWorldPosition(), transform.forward);
        deltaAngleSum += Mathf.Abs(angle);
        transform.RotateAround(transform.position, Vector3.forward, angle);
    }
}
