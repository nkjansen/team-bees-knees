using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField]
    public Animator animator;
    private int LevelToLoad;
    [SerializeField]
    public string Scene;
    
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(Scene);
    }

    public void FadeToLevel(int levelIndex)
    {
        LevelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}

