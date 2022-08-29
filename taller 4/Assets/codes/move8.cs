using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move8 : MonoBehaviour
{ 
    [SerializeField]private float speed = 3f;
    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;
    
    
    [Header("Settings, delay on rotation")]
    [SerializeField] int framesToUpdate = 4;
    int actualFramesToUpdate = 0;
    Vector2 lastDirection;
    bool onTransition = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }



    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        if (onTransition == true)
        {
            if (actualFramesToUpdate == 0)
            {
                lastDirection = moveInput;
                onTransition = false;
            }
            else
            {
                actualFramesToUpdate -= 1;
                return;
            }
        }
        playerAnimator.SetFloat("speed",moveInput.sqrMagnitude);

        //if(lastDirection != moveInput && onTransition == false)
        //{
        //    actualFramesToUpdate = framesToUpdate;
        //    onTransition = true;
        //    return ; // Termina todo aqui, no hay rotation
        //}

        //if (moveX == 1 && moveY == 1)
        //{
        //    //diagonal derecha arriba
        //    // Debug.Log("diagonal derecha arriba");
        //    transform.rotation = Quaternion.Euler(0, 0, 135);
        //}
        //if (moveX == 1 && moveY == 0)
        //{
        //    // derecha
        //    // Debug.Log("derecha");
        //    transform.rotation = Quaternion.Euler(0, 0, 90);
        //}
        //if (moveX == 1 && moveY == -1)
        //{
        //    //diagonal derecha abajo
        //    // Debug.Log("diagonal derecha abajo");
        //    transform.rotation = Quaternion.Euler(0, 0, 45);
        //}
        //if (moveX == 0 && moveY == -1)
        //{
        //    //abajo
        //    // Debug.Log("abajo");
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
        //if (moveX == -1 && moveY == -1)
        //{
        //    //diagonal izq anajo
        //    // Debug.Log("diagonal izq anajo");
        //    transform.rotation = Quaternion.Euler(0, 0, 315);
        //}
        //if (moveX == -1 && moveY == 0)
        //{
        //    //izq
        //    // Debug.Log("izq");
        //    transform.rotation = Quaternion.Euler(0, 0, 270);
        //}
        //if (moveX == -1 && moveY == 1)
        //{
        //    //diagonal izq arriba
        //    // Debug.Log("diagonal izq arriba");
        //    transform.rotation = Quaternion.Euler(0, 0, 225);
        //}
        //if (moveX == 0 && moveY == 1)
        //{
        //    // arriba
        //    // Debug.Log("arriba");
        //    transform.rotation = Quaternion.Euler(0, 0, 180);
        //}
    }
    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);
        
    }
}

    