using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UiScprit : MonoBehaviour
{
    TextMeshProUGUI remain;
    [SerializeField] private int death_enemy = 0;
    void Start(){
        remain = GetComponentInChildren<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        int rem = 100 - death_enemy;
        remain.text = "Remaning Souls: " + rem.ToString();
    }
    public void IncreaseDeathNumber(){
        death_enemy += 1; 
    }
}
