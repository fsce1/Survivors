using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimManager : MonoBehaviour
{



    #region SINGLETON
    public static AimManager AM;
    private void Awake()
    {
        if (AM != null && AM != this) Destroy(this);
        else AM = this;
    }
    #endregion
    //List<GameObject> enemies = new List<GameObject>();


    //float rangeRadius = 5;
    public float targetAcquisition = 1;

    void Update()
    {
        Vector3 vel = Vector3.zero;
        Transform closestEnemy = ClosestEnemy();
        Vector3.SmoothDamp(transform.position, closestEnemy.position, ref vel, targetAcquisition);
        transform.position += new Vector3(vel.x, vel.y, 1 + transform.position.z);

        //this.transform.position = ClosestEnemy().position;
    }
    Transform ClosestEnemy()
    {

        Transform tPlayer = GameManager.GM.player.transform;
        if (GameManager.GM.enemies == null) return tPlayer;
        Transform tClosest = tPlayer;
        float minDist = Mathf.Infinity;
        foreach (GameObject g in GameManager.GM.enemies)
        {
            //if (!GetComponent<Renderer>().isVisible) continue; //this causes slowdown (i think)
            Transform t = g.transform;
            float dist = Vector3.Distance(tPlayer.position, t.position);

            if (dist < minDist)
            {
                tClosest = t;
                minDist = dist;
            }
        }
        if (!tClosest.gameObject.GetComponent<Renderer>().isVisible) return tPlayer;
        //if (minDist == Mathf.Infinity) return tPlayer;
        return tClosest;
    }
}
