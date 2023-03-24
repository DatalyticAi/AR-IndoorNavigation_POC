using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NavigatingMenu : MonoBehaviour
{
    public void NextGame()
    {
        SceneManager.LoadScene("Navigating");
    }

}