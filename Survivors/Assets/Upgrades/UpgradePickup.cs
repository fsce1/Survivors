using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradePickup : MonoBehaviour
{
    public Upgrade upgrade;
    public int cost;

    public TMP_Text upgradeText;
    public TMP_Text costText;

    public void Start()
    {
        upgradeText.text = upgrade.shorthandKey.ToString();
        costText.text = cost.ToString();
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player")) return;

        if (GameManager.GM.enemiesKilled >= cost) GameManager.GM.enemiesKilled -= cost;
        else return;

        UpgradeManager.UM.ApplyThisPlayerUpgrade(upgrade);
        Destroy(gameObject);
    }

}
