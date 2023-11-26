using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeManager : MonoBehaviour
{
    [SerializeField] private UiScprit xxxxxxx;

    private void Update()
    {
        if(xxxxxxx.death_enemy >= 99)
        {
            GoToNextLevel();
        }
    }

    private void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
    }
}
