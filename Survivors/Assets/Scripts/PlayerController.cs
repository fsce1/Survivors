using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float moveMult = 100;

    public int health = 100;
    public float frictionAmount = 0.1f;
    public float maxSpeed = 1;
    public Vector2 curVelDebug = Vector2.zero;
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
        Vector2 rbVel = rb.velocity;
        Vector2 tPlayer = new Vector2(transform.position.x, transform.position.y);
        Vector2.SmoothDamp(tPlayer, tPlayer + move, ref rbVel, frictionAmount, maxSpeed);
        curVelDebug = rbVel;
        rb.velocity = rbVel;
    }
    public void TakeDamage(int dmg, GameObject enemy)
    {
        health -= dmg;
    }

}
