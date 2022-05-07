using UnityEngine;
public class BackButton : MonoBehaviour
{
    public void LoadMainScene() => SceneTransition.current.RequestLoadsceneWithId(0);
    public void LoadChoseDishScene() => SceneTransition.current.RequestLoadsceneWithId(1);
}
