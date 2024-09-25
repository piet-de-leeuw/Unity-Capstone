 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] bool fadeInOnSceneStart;

    private void Start()
    {
        if (fadeInOnSceneStart) { animator.SetTrigger("StartWithFadeIn"); }
    }

    public void LoadNextScene(float waitSec = 0f)
    {
        int currendScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadScene(currendScene + 1, waitSec));
    }

    // Called by Replay button
    public void LoadReplay()
    {
        StartCoroutine(LoadScene(1));
    }

    // Called by Quit Button
    public void Quit()
    {
        Application.Quit();
    }

    // Called if playerHealth is 0. Called from playercontroller.
    public void LoadGameOver(float waitSec = 3f)
    {
        int gameOver = SceneManager.sceneCountInBuildSettings - 1;
        StartCoroutine(LoadScene(gameOver, waitSec));
    }

    public IEnumerator LoadScene(int NextScene, float WaitSec = 0)
    {
        // Allows a waittime before executing so animations like player death can play in full before scene transition.
        yield return new WaitForSeconds(WaitSec);
        animator.SetTrigger("FadeOut");
        // A set waittime so the scene transition animation can play in full.
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(NextScene);
    }

}
