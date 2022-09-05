using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    public float rotate;
    public float speed;
    private Rigidbody2D Rb;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootctrl;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //movimiento
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveY == 1)
        {
            Rb.velocity = transform.up * -speed;
        }
        if(moveY == -1)
        {
            Rb.velocity = transform.up * speed;
        }
        float moveX = Input.GetAxisRaw("Horizontal");
        

        if (moveX == -1)
        {
            transform.Rotate(0, 0, rotate * Time.deltaTime);
        }
        if (moveX == 1)
        {
            transform.Rotate(0, 0, -rotate * Time.deltaTime);
        }
        playerAnimator.SetFloat("speed", moveY);

        // disparo
        if(Input.GetButtonDown("Fire1"))
        {

        }
     
    }
    private void Shoot()
    {
        //Instantiate(bullet, shootctrl )
    }
                
    

}
