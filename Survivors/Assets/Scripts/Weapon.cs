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
    public Rigidbody2D rb;
    public int dmg;
    public Vector2 shotgunBurstAmt;
    public Vector2 shotgunSpread;
    public Vector2 muzzleVel;
    public float cooldown;

    public bool isInInventory;

    public bool isFiring;
    public void Setup()
    {
        rb.position = GameManager.GM.player.transform.position;
        transform.SetParent(GameManager.GM.player.transform);
        gameObject.SetActive(false);
        //transform.localPosition = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }
    public void StartTimer()
    {
        Debug.Log("StartTimer");

        isFiring = true;
        firingTimer = StartCoroutine(BulletTimer(cooldown));
    }

    public void StopTimer()
    {
        Debug.Log("StopTimer");
        isFiring = false;
        StopCoroutine(firingTimer);
        firstShot = false;
    }

    public bool firstShot = false;
    public IEnumerator BulletTimer(float cooldown){
        while (!firstShot)
        {
            firstShot = true;
            yield return new WaitForSeconds(cooldown);
        }
        while (isFiring)
        {
        OnBulletTimer();
        yield return new WaitForSeconds(cooldown);
        }
    }

    Coroutine firingTimer;


    void OnBulletTimer()
    {
        Debug.Log("OnBulletTimer" + wType);

        switch (wType)
        {
            case WeaponType.Pistol:

                SpawnBullet(0);
                break;
            case WeaponType.Shotgun:


                for (int i = 0; i < CustomMath.GetRandomInt(shotgunBurstAmt); i++)
                {
                    SpawnBullet(CustomMath.GetRandom(shotgunSpread));
                }
                break;
        }
    }
    public void SpawnBullet(float deviation)
    {
        Debug.Log("SpawnBullet " + deviation);

        Transform tBullet = Instantiate(GameManager.GM.bullet, MuzzlePos.position, MuzzlePos.rotation).transform;
        Rigidbody2D rb = tBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(MuzzlePos.right.normalized * CustomMath.GetRandom(muzzleVel), ForceMode2D.Impulse);
        Bullet bullet = tBullet.GetComponent<Bullet>();
        rb.AddForce(transform.up * deviation);
        bullet.firedFromPlayer = true; bullet.weaponFiredFrom = gameObject; bullet.dmg = dmg;
    }
    void Update()
    {
        if(GameManager.GM.player.curWeapon == this)
        {
            transform.right = GameManager.GM.Aim.position - transform.position;
            rb.position = GameManager.GM.player.transform.position;
        }
        else if (isInInventory)
        {
            gameObject.SetActive(false);
        }

        //transform.position = GameManager.GM.player.transform.position;
        //transform.localPosition = Vector2.zero;
        //Vector2 aimDir = GameManager.GM.Aim.position - MuzzlePos.position;
        //float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Deg2Rad - 90f;
        //rb.rotation = aimAngle;



    }
}
