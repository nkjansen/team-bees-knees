using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutButtonScript : MonoBehaviour
{
    public GameObject Screen;

    void Start()
    {
        Screen.SetActive(false);
    }

    public void ShowScreen()
    {
        Screen.SetActive(true);
    }
}
