using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    public static GameManager GM;
    private void Awake(){
        if (GM != null && GM != this) Destroy(this);
        else GM = this;
    }
    #endregion

    public PlayerController player;
    public GameObject enemyPrefab;
    public Vector2 enemyGroupSize = new Vector2(1, 10);
    public GameObject[] enemies;
    private void Start()
    {
        UpdateEnemyList();
    }
    public void UpdateEnemyList()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

    }
    public void SpawnEnemyGroup()
    {

        transform.position = Random.insideUnitCircle.normalized * Random.Range(35f, 45f);
        for (int j = (int)Random.Range(enemyGroupSize.x, enemyGroupSize.y); j > 0; j--)
        {
            transform.position += new Vector3(Random.Range(-15, 15), Random.Range(-15, 15));
            GameObject g = Instantiate(enemyPrefab, transform);
            g.transform.SetParent(null);
        }
        UpdateEnemyList();
    }

    //public void Update()
    //{
    //    foreach (GameObject e in enemies)
    //    {
    //        if

    //    }
    //}

    #region BOID
    //https://swharden.com/csdv/simulations/boids/
    #endregion








}
