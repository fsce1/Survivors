using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    #region SINGLETON
    public static ScrollManager SM;
    private void Awake()
    {
        if (SM != null && SM != this) Destroy(this);
        else SM = this;
    }
    #endregion


    public List<GameObject> masterWeapons;
    public List<Upgrade> masterUpgrades;
    public GameObject upgradePrefab;
    public Vector2Int upgradesEachRoundTimer = new Vector2Int(0,2);
    public Vector2 spawnRangeY = new(20, 50);
    public Vector2 spawnRangeX = new(-30, 30);
    public float gunSpawnChance01;
    public int gunIndex = 0;
    public int numToUpgrade = 0;
    public void RecieveRoundTimer()
    {
        numToUpgrade = CustomMath.GetRandomInt(upgradesEachRoundTimer);

        for (int i = 0; i < numToUpgrade; i++)
        {
            SpawnFromUpgrade(masterUpgrades[i]);
        }
    }





    public void SpawnFromUpgrade(Upgrade u)
    {

        if (u.levelToAppearAt > GameManager.GM.level) { numToUpgrade++; return; }
        UpgradePickup pickup = upgradePrefab.GetComponent<UpgradePickup>();
        pickup.upgrade = u;
        pickup.cost = CustomMath.GetRandomInt(u.cost);
        //Vector2 spawnLoc = new(Camera.main.ViewportToWorldPoint(Vector2.zero).x, CustomMath.GetRandom(spawnRange));
        Vector3 spawnLoc = new(CustomMath.GetRandom(spawnRangeX), -CustomMath.GetRandom(spawnRangeY) + GameManager.GM.player.transform.position.y, -1);
        Instantiate(pickup.gameObject, spawnLoc, Quaternion.identity);
        Debug.Log("Spawning " + u.name);
    }
}
