using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    #region SINGLETON
    public static GameManager GM;
    private void Awake(){
        if (GM != null && GM != this) Destroy(this);
        else GM = this;
    }
    #endregion

    public bool roundStarted = false;
    public PlayerController player;
    public GameObject enemyPrefab;
    public Vector2 enemyGroupSize = new Vector2(5, 20);
    public Vector2 timeBetweenSpawns = new Vector2(0, 5);
    public int roundTimeLimit = 30 *60; // 30 minutes
    public List<GameObject> enemies;
    public Transform enemyParent;
    public Transform Aim;
    public GameObject bullet;

    [Header("UI Elements")]
    public Button startRound;
    public Text roundTimer;
    public Text enemyKills;
    public Text enemyTimer;
    public Text curWeapon;
    public Text Health;


    private void Start()
    {
        startRound.gameObject.SetActive(true);
    }
    public void StartRound()
    {
        if(roundStarted) return;

        startRound.gameObject.SetActive(false);

        StartCoroutine(RoundTimer(roundTimeLimit));
        OnSpawnTimer();

        player.health = player.maxHealth;
        roundStarted = true;
    }

    public IEnumerator RoundTimer(int time)
    {
        while (time >= 0)
        {
            time -= 1;
            roundTimer.text = CustomMath.SecondsToTimer(time);
            yield return new WaitForSeconds(1);
        }
        OnRoundTimer();
    }
    public void OnRoundTimer()
    {
        //increment difficulty up
    }
    public IEnumerator EnemyTimer(int time)
    {
        while (time > 0){
            time -= 1;
            enemyTimer.text = time.ToString();
            yield return new WaitForSeconds(1);
        }
        OnSpawnTimer();
    }
    void OnSpawnTimer()
    {
        SpawnEnemyGroup();
        StartCoroutine(EnemyTimer(CustomMath.GetRandomInt(timeBetweenSpawns)));
    }
    public void SpawnEnemyGroup()
    {

        transform.position = Random.insideUnitCircle.normalized * Random.Range(35f, 45f);
        for (int j = (int)Random.Range(enemyGroupSize.x, enemyGroupSize.y); j > 0; j--) //for-loop on random number of enemies inside range
        {
            transform.position += new Vector3(Random.Range(-15, 15), Random.Range(-15, 15));
            GameObject g = Instantiate(enemyPrefab, transform);
            g.transform.SetParent(enemyParent);
            EnemyController e = g.GetComponent<EnemyController>();
            e.type = (EnemyController.enemyType)Random.Range(0, 1 + 1); //must change as enemy types added. +1 is because it generates floats and it will almost never generate 2 exactly, it truncates
            e.Setup();
        }

        //UpdateEnemyList();
    }


    #region BOID
    //https://swharden.com/csdv/simulations/boids/
    #endregion








}
