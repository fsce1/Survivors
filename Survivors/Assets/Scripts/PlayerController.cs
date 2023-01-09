using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public float frictionAmount = 0.1f;
    public float moveMult = 1;
    public float maxSpeed = 1;
    Rigidbody2D rb;

    [Header("Inventory")]
    public List<Weapon> weaponInv;
    public int curWeaponIndex = 0;
    public Weapon curWeapon;


    public void UpdateInput()
    {
        if (Input.anyKey) GameManager.GM.StartRound();
        if (Input.GetKeyDown(KeyCode.E)) NextWeapon();
        if (Input.GetKeyDown(KeyCode.Q)) LastWeapon();
        if (Input.GetKeyDown(KeyCode.Space)) FireWeapon();
    }
    public void NextWeapon()
    {
        curWeaponIndex++;
        UpdateWeaponIndex();
    }
    public void LastWeapon()
    {
        curWeaponIndex--;
        UpdateWeaponIndex();
    }
    public void FireWeapon()
    {
        curWeapon.Fire();
    }

    public void UpdateWeaponIndex()
    {
        if (curWeapon != null) curWeapon.gameObject.SetActive(false);
        curWeaponIndex = Mathf.Abs(Mathf.Clamp(curWeaponIndex, 0, weaponInv.Count));
        if (curWeaponIndex >= 1) curWeapon = weaponInv[curWeaponIndex - 1]; //index weaponInv
        curWeapon.gameObject.SetActive(true);
        GameManager.GM.curWeapon.text = curWeapon.wType.ToString();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        switch (col.gameObject.tag)
        {
            case "Weapon":
                Weapon w = col.gameObject.GetComponent<Weapon>(); weaponInv.Add(w); //add weapon to Inv
                col.transform.SetParent(GameManager.GM.player.transform); col.gameObject.SetActive(false); //parent and disable weapon
                curWeaponIndex++;
                UpdateWeaponIndex();
                break;
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        UpdateInput();

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
        //rb.velocity = rbVel
        rb.velocity = rbVel * moveMult;
    }
    public void TakeDamage(int dmg, GameObject enemy)
    {
        health -= dmg;
        GameManager.GM.Health.text = (health).ToString(); //health stuff not working for now
        if (health < 1) Die();
    }
    public void Die()
    {
        GameManager.GM.roundStarted = false;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
