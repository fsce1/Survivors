using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum enemyType
    {
        Melee,
        Ranger
    }

    Rigidbody2D rb;
    SpriteRenderer sr;

    public int dmg = 10;
    public float moveSpeed;
    public enemyType type = enemyType.Melee;
    //void Start()
    //{
    //}

    public void Setup()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        GameManager.GM.enemies.Add(this.gameObject);
    }
    void Update()
    {
        Vector3 targetVector = Vector3.zero;
        switch (type)
        {
            case enemyType.Melee:
                Transform tPlayer = GameManager.GM.player.transform;
                targetVector = tPlayer.position - transform.position; targetVector.Normalize();
                //rb.AddForce(targetVector*moveSpeed);
                rb.velocity = targetVector;
                //Debug.DrawRay(transform.position, targetVector);
                

                return;
            case enemyType.Ranger:
                sr.color = Color.cyan;











                return;
        }

        //CLOSE TO FRIENDS

        Transform tClosest = null;
        float minDist = Mathf.Infinity;
        foreach(GameObject g in GameManager.GM.enemies)
        {
            Transform t = g.transform;
            float dist = Vector3.Distance(transform.position, t.position);

            if (dist < minDist)
            {
                tClosest = t;
                minDist = dist;
            }
        }



        //+(transform.position - tClosest.position));

        //Move(targetVector * moveSpeed);





    }


    private void Move(Vector2 move)
    {
        rb.velocity = move;
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
