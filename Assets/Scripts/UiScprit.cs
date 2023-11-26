using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UiScprit : MonoBehaviour
{
    TextMeshProUGUI remain;
    [SerializeField] public int death_enemy;
    void Start(){
        remain = GetComponentInChildren<TextMeshProUGUI>();
        death_enemy = 0;
    }
    // Update is called once per frame
    void Update()
    {
        int rem = 100 - death_enemy;
        remain.text = "Kalan Ruh: " + rem.ToString();
    }
    public void IncreaseDeathNumber(){
        death_enemy += 1; 
    }
}
