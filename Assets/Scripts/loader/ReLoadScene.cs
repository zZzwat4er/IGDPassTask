using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLoadScene : SceneLoader
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        reLoadScene();
    }

    private void reLoadScene()
    {
        loadScene(SceneManager.GetActiveScene().name);
    }
}
