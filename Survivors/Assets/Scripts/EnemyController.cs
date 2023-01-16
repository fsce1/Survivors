using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public enum EnemyType
    {
        Melee,
        Ranger
    }

    Rigidbody2D rb;
    public TMP_Text rend;
    public int health = 4;
    public float typeMoveSpeed;

    public EnemyType type = EnemyType.Melee;
    public Transform weapon;
    //void Start()
    //{
    //}

    public void Setup()
    {
        timeBetweenShots = UpgradeManager.UM.eFiringSpeed;
        rb = GetComponent<Rigidbody2D>();
        switch (type)
        {
            case EnemyType.Melee:
                rend.color = Color.red;
                //moveSpeed = 0.25f;
                typeMoveSpeed = 1.25f;
                break;
            case EnemyType.Ranger:
                rend.color = Color.cyan;
                typeMoveSpeed = 0.5f;

                StartCoroutine(RangerTimer(CustomMath.GetRandom(timeBetweenShots)));

                break;
        }
        GameManager.GM.enemies.Add(this.gameObject);
        gameObject.name = type.ToString();
        health = UpgradeManager.UM.eMaxHealth;
    }
    public void Move()
    {
        Vector3 targetVector = GameManager.GM.player.transform.position - transform.position; targetVector.Normalize();
        rb.velocity = UpgradeManager.UM.eMultMoveSpeed * typeMoveSpeed *  targetVector;
    }
    public Vector2 timeBetweenShots;
    public float muzzleVel = 5;
    public Transform muzzlePos;
    public IEnumerator RangerTimer(float time)
    {
        while (time > 0)
        {
            time -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        OnRangerTimer();
    }
    void OnRangerTimer()
    {
        Fire();
        StartCoroutine(RangerTimer(CustomMath.GetRandom(timeBetweenShots)));
    }
    public void Fire()
    {
        GameObject eBullet = Instantiate(GameManager.GM.bullet, muzzlePos.position, muzzlePos.rotation);
        Vector2 target = (GameManager.GM.player.transform.position - transform.position);
        eBullet.GetComponent<Rigidbody2D>().AddForce(muzzleVel * UpgradeManager.UM.eMultMuzzleVelocity * target.normalized, ForceMode2D.Impulse);
        Bullet bullet = eBullet.GetComponent<Bullet>();
        bullet.firedFromPlayer = false; bullet.weaponFiredFrom = gameObject; bullet.dmg = UpgradeManager.UM.eDmg;

    }
    void Update()
    {

        weapon.transform.right = GameManager.GM.player.transform.position - transform.position;

        Move();

        switch (type)                //possible different AI, range sweet spots
        {
            case EnemyType.Melee:

                return;
            case EnemyType.Ranger:
                return;
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health < 1) Die();
    }
    public void Die()
    {
        GameManager.GM.enemies.Remove(gameObject);
        Destroy(gameObject);
        GameManager.GM.enemiesKilled++;
        GameManager.GM.tEnemyKills.text = "Kills = " + GameManager.GM.enemiesKilled.ToString();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Player":
                GameManager.GM.player.TakeDamage(UpgradeManager.UM.eDmg, gameObject);
                return;

        }
    }
}
