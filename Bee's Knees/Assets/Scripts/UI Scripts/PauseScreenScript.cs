using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenScript : MonoBehaviour
{

    public GameObject Screen;
    public GameObject Buttons;

    void Start()
    {
        Screen.SetActive(false);
        Buttons.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed.");
            ShowScreen();
        }
    }

    public void ShowScreen()
    {
        Screen.SetActive(true);
        Buttons.SetActive(true);
    }
}
