using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    private void Start()
    {
        Instance = this;
    }

    [SerializeField] private int speed = 7;
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal * speed * Time.deltaTime,vertical * speed * Time.deltaTime);  
        transform.position = transform.position + movement;
        
    }

    

}

