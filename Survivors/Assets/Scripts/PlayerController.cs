using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public float moveMult = 100;

    public int health = 100;
    public int maxHealth = 100;
    public float frictionAmount = 0.1f;
    public float maxSpeed = 1;
    Rigidbody2D rb;
    //Vector2 rawInput; // x = horizontal y = vertical

    [Header("Inventory")]
    public List<Weapon> weaponInv;
    public Weapon.WeaponType curWeapon;

    public void NextWeapon()
    {
        curWeapon++;
    }
    public void LastWeapon()
    {
        curWeapon--;
    }
    public void FireWeapon()
    {
        weaponInv[(int)curWeapon].Fire();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Weapon":
                Weapon w = col.GetComponent<Weapon>();
                weaponInv.Add(w);
                //if (weaponInv.Contains(col.GetComponent<Weapon>().wType){}
                return;
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) NextWeapon();
        if (Input.GetKeyDown(KeyCode.Q)) LastWeapon();
        if (Input.GetKeyDown(KeyCode.Space)) FireWeapon();

        GameManager.GM.Health.value = Mathf.Lerp(0, maxHealth, health);



    }
    private void FixedUpdate()
    {

        Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

    }
    public void Move(Vector2 move)
    {
        Vector2 rbVel = rb.velocity;
        Vector2 tPlayer = new Vector2(transform.position.x, transform.position.y);
        Vector2.SmoothDamp(tPlayer, tPlayer + move, ref rbVel, frictionAmount, maxSpeed);
        rb.velocity = rbVel;
    }
    public void TakeDamage(int dmg, GameObject enemy)
    {
        health -= dmg;
    }

}
