using UnityEngine;

public class ChooseDish : MonoBehaviour
{
    public void LoadDrinkScene() => SceneTransition.current.RequestLoadsceneWithId(4);
    public void LoadMainCourseScene() => SceneTransition.current.RequestLoadsceneWithId(5);
    public void LoadDesertScene() => SceneTransition.current.RequestLoadsceneWithId(3);
    public void LoadFinalPicnicScene() => SceneTransition.current.RequestLoadsceneWithId(2);

}
