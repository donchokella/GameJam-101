using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeManager : MonoBehaviour
{
    [SerializeField] private UiScprit xxxxxxx;

    [SerializeField] private GameObject xxxxBtn;

    private void Start()
    {
        xxxxBtn.SetActive(false);
    }

    private void Update()
    {
        if(xxxxxxx.death_enemy >= 99)
        {
            GoToNextLevel();
        }
    }

    public void GoToNextLevel()
    {
        xxxxBtn.SetActive(true);
    }
}
