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

    public void LoadNextScene()
    {
        int currendScene = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadScene(currendScene + 1));
    }

    public void LoadReplay()
    {
        StartCoroutine(LoadScene(1));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public IEnumerator LoadScene(int NextScene)
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(NextScene);
    }

}
