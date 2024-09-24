 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] bool fadeInOnStart;

    private void Start()
    {
        if (fadeInOnStart) { animator.SetTrigger("StartWithFadeIn"); }
    }

    public void LoadNextScene(float waitSec = 0f)
    {
        int currendScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadScene(currendScene + 1, waitSec));
    }


    public void LoadReplay()
    {
        StartCoroutine(LoadScene(1));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadGameOver(float waitSec = 3f)
    {
        int gameOver = SceneManager.sceneCountInBuildSettings - 1;
        StartCoroutine(LoadScene(gameOver, waitSec));
    }

    public IEnumerator LoadScene(int NextScene)
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(NextScene);
    }

    public IEnumerator LoadScene(int NextScene, float WaitSec)
    {
        yield return new WaitForSeconds(WaitSec);
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(NextScene);
    }

}
