using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public enum enemyType
    {
        Melee,
        Ranger
    }

    Rigidbody2D rb;
    public TMP_Text rend;
    public int health = 4;
    public int maxHealth = 4;
    public int dmg = 10;
    public float moveSpeed;
    public enemyType type = enemyType.Melee;
    public Transform weapon;
    //void Start()
    //{
    //}

    public void Setup()
    {
        maxHealth += EnemyUpgradeManager.EUM.addHealth;
        rb = GetComponent<Rigidbody2D>();
        switch (type)
        {
            case enemyType.Melee:
                rend.color = Color.red;
                //moveSpeed = 0.25f;
                moveSpeed = 1.25f;
                break;
            case enemyType.Ranger:
                rend.color = Color.cyan;
                moveSpeed = 0.25f;

                StartCoroutine(RangerTimer(CustomMath.GetRandom(timeBetweenShots)));

                break;
        }
        GameManager.GM.enemies.Add(this.gameObject);
        gameObject.name = type.ToString();
        health = maxHealth;
    }
    public void Move()
    {
        Vector3 targetVector = Vector3.zero;

        Transform tPlayer = GameManager.GM.player.transform;
        targetVector = tPlayer.position - transform.position; targetVector.Normalize();
        rb.velocity = targetVector * moveSpeed * EnemyUpgradeManager.EUM.multMoveSpeed;

    }
    public Vector2 timeBetweenShots = EnemyUpgradeManager.EUM.groupAmount;
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
        eBullet.GetComponent<Rigidbody2D>().AddForce(target.normalized * muzzleVel * EnemyUpgradeManager.EUM.multMuzzleVelocity, ForceMode2D.Impulse);
        Bullet bullet = eBullet.GetComponent<Bullet>();
        bullet.firedFromPlayer = false; bullet.weaponFiredFrom = gameObject; bullet.dmg = dmg;

    }
    void Update()
    {

        weapon.transform.right = GameManager.GM.player.transform.position - transform.position;

        Move();

        switch (type)                //possible different AI, range sweet spots
        {
            case enemyType.Melee:

                return;
            case enemyType.Ranger:
                return;
        }

        ////CLOSE TO FRIENDS

        //Transform tClosest = null;
        //float minDist = Mathf.Infinity;
        //foreach(GameObject g in GameManager.GM.enemies)
        //{
        //    Transform t = g.transform;
        //    float dist = Vector3.Distance(transform.position, t.position);

        //    if (dist < minDist)
        //    {
        //        tClosest = t;
        //        minDist = dist;
        //    }
        //}



        //+(transform.position - tClosest.position));

        //Move(targetVector * moveSpeed);





    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health < 1) Die();
    }
    public void Die()
    {
        GameManager.GM.enemies.Remove(gameObject);
        GameManager.GM.enemiesKilled++;
        GameManager.GM.enemyKills.text = "Kills = " + GameManager.GM.enemiesKilled.ToString();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Player":
                GameManager.GM.player.TakeDamage(dmg, gameObject);
                return;

        }
    }
}
