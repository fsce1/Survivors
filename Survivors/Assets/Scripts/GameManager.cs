using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Vector2 enemyGroupSize = new Vector2(5, 20);
    public Vector2 timeBetweenSpawns = new Vector2(0, 5);
    public int roundTimeLimit = 30 *60; // 30 minutes
    public List<GameObject> enemies;

    [Header("UI Elements")]
    public Text roundTimer;
    public Text enemyKills;
    public Text enemyTimer;
    public Text curWeapon;
    public Slider Health;

    //private void Start()
    //{
    //    //UpdateEnemyList();
    //}
    //public void UpdateEnemyList()
    //{
    //    //enemies = GameObject.FindGameObjectsWithTag("Enemy");

    //}
    public float GetRandom(Vector2 bounds)
    {
        return Random.Range(bounds.x, bounds.y);
    }

    public void StartRound()
    {
        StartCoroutine(RoundTimer(roundTimeLimit));
        StartCoroutine(EnemyTimer(GetRandom(timeBetweenSpawns)));
        player.health = player.maxHealth;
    }

    public IEnumerator RoundTimer(int maxTime)
    {
        while (maxTime >= 0)
        {
            maxTime -= 1;
            roundTimer.text = maxTime.ToString();
            yield return new WaitForSeconds(1);
        }
        OnRoundTimer();
    }
    public void OnRoundTimer()
    {

    }
    public IEnumerator EnemyTimer(float time)
    {
        while (time >= 0){
            time -= 0.1f;
            enemyTimer.text = time.ToString();
            yield return new WaitForSeconds(0.1f);
        }
        OnSpawnTimer();
    }
    void OnSpawnTimer()
    {
        SpawnEnemyGroup();
        StartCoroutine(EnemyTimer(GetRandom(timeBetweenSpawns)));
    }
    public void SpawnEnemyGroup()
    {

        transform.position = Random.insideUnitCircle.normalized * Random.Range(35f, 45f);
        for (int j = (int)Random.Range(enemyGroupSize.x, enemyGroupSize.y); j > 0; j--) //for-loop on random number of enemies inside range
        {
            transform.position += new Vector3(Random.Range(-15, 15), Random.Range(-15, 15));
            GameObject g = Instantiate(enemyPrefab, transform);
            g.transform.SetParent(null);
            EnemyController e = g.GetComponent<EnemyController>();
            e.type = (EnemyController.enemyType)Random.Range(0, 1 + 1); //must change as enemy types added. +1 is because it generates floats and it will almost never generate 2 exactly, it truncates
            e.Setup();
        }

        //UpdateEnemyList();
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
