using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public enum WeaponType
    {   None,
        Pistol,
        Shotgun
    }
    public WeaponType wType;
    public Transform MuzzlePos;
    public float muzzleVel;
    public Rigidbody2D rb;
    void Start()
    {
        
    }
    public void Setup()
    {
        transform.localPosition = Vector2.zero;
        transform.SetParent(GameManager.GM.player.transform);
        rb = GetComponent<Rigidbody2D>();
    }
    public void Fire()
    {
        Transform tBullet = Instantiate(GameManager.GM.bullet, MuzzlePos.position, MuzzlePos.rotation).transform;
        tBullet.GetComponent<Rigidbody2D>().AddForce(MuzzlePos.right * muzzleVel, ForceMode2D.Impulse);

        Debug.Log("Bang!" + wType.ToString());
    }
    void FixedUpdate()
    {
        transform.right = GameManager.GM.Aim.position - transform.position;
        //transform.localPosition = Vector2.zero;


        //Vector2 aimDir = GameManager.GM.Aim.position - MuzzlePos.position;
        //float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Deg2Rad - 90f;
        //rb.rotation = aimAngle;



    }
}
