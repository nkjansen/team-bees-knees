using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    
    void Update()
    {
       //Transition goes here
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(2);
        }
    }


    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    
   public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
