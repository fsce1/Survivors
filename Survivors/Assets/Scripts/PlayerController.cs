using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float moveMult = 100;
    public float frictionAmount = 0.6f;
    public float maxSpeed = 10;
    Rigidbody2D rb;
    //Vector2 rawInput; // x = horizontal y = vertical


    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        //rawInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }
    private void FixedUpdate(){
        
        RampUp(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

    }
    public void RampUp(Vector2 move){
        Vector2 rbVel = rb.velocity; //badly done
        Vector2 transPos = new Vector2(transform.position.x, transform.position.y);
        Vector2.SmoothDamp(transform.position, transPos + move, ref rbVel, frictionAmount, maxSpeed);
        rb.velocity = rbVel; //badly done

    }

}
