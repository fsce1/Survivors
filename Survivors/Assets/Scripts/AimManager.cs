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
    public Transform tPlayer;
    public float maxDistanceFromPlayer;
    void Update()
    {
        tPlayer = GameManager.GM.player.transform;
        Vector3 vel = Vector3.zero;
        Transform closestEnemy = ClosestEnemy();
        Vector3.SmoothDamp(transform.position, closestEnemy.position, ref vel, targetAcquisition);
        transform.position += new Vector3(vel.x, vel.y, 1 + transform.position.z);
        //Cull enemies far away
        //CullEnemies();
        //this.transform.position = ClosestEnemy().position;
    }

    //private void CullEnemies()
    //{
    //    foreach (GameObject g in GameManager.GM.enemies)
    //    {
    //        if (g != null)
    //        {
    //            if(Vector3.Distance(tPlayer.position, g.transform.position) > maxDistanceFromPlayer)
    //            {
    //                Destroy(g);
    //            }
                
    //        }
    //    }
    //}
    Transform ClosestEnemy()
    {

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
        //if (!tClosest.gameObject.GetComponent<Renderer>().isVisible) return tPlayer;
        //if (minDist == Mathf.Infinity) return tPlayer;
        return tClosest;
    }
}
