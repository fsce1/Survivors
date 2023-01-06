using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimManager : MonoBehaviour
{
    //List<GameObject> enemies = new List<GameObject>();

    GameObject[] enemies;
    float rangeRadius = 5;
    public float targetAcquisition = 1;
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }


    void Update()
    {
        Vector3 vel = Vector2.zero;
        Vector3.SmoothDamp(transform.position, ClosestEnemy().position, ref vel, targetAcquisition);
        transform.position += vel;




        //this.transform.position = ClosestEnemy().position;
    }
    Transform ClosestEnemy()
    {
        Transform playerPos = GameManager.GM.player.transform;
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        foreach (GameObject g in enemies)
        {
            if (!GetComponent<Renderer>().isVisible) continue; //this causes slowdown (i think)
            Transform t = g.transform;
            float dist = Vector3.Distance(playerPos.position, t.position);

            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        if (minDist == Mathf.Infinity) return playerPos;
        return tMin;
    }
}
