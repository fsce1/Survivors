using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class EnemyUpgradeManager : MonoBehaviour
{
    #region SINGLETON
    public static EnemyUpgradeManager EUM;
    private void Awake()
    {
        if (EUM != null && EUM != this) Destroy(this);
        else EUM = this;
    }
    #endregion
    public List<Upgrade> upgrades;
    public IDictionary<Upgrade, int> upgradeStack = new Dictionary<Upgrade, int>();
    public GameObject overlay;

    private void Start()
    {
        SetupDictionary();
    }
    public void SetupDictionary()
    {
        foreach (Upgrade u in upgrades)
        {
            upgradeStack.Add(u, 0);
        }
    }

    [Header("EnemyUpgradeUI")]
    public List<TMP_Text> buttons;
    public List<Upgrade> choices;
    public int choiceNum = 3;

    [Header("Enemy Vars")]
    public float multMuzzleVelocity = 1;
    public float multMoveSpeed = 1;
    public Vector2 firingSpeed = new Vector2(2, 4);
    public int addHealth = 0;
    public Vector2 groupAmount= new Vector2(5, 15);
    void ApplyThisUpgrade(Upgrade u)
    {
        switch (u.shorthandKey)
        {
            case "E-MM":
                firingSpeed.x -= 0.2f; firingSpeed.y -= 0.2f;
                break;
            case "E-RA":
                addHealth += 2;
                break;
            case "E-WB":
                multMoveSpeed += 0.05f;
                break;
            case "E-RT":
                groupAmount.y += 1;
                break;
            case "E-PP":
                groupAmount.x += 1;
                break;
            case "E-BB":
                multMuzzleVelocity += 0.1f;
                break;
        }
    }

    public void DisplayEnemyUpgrades() //Called every RoundTimer
    {
        Time.timeScale = 0;

        for (int i = 0; i < choiceNum; i++)
        {
            int choice = Random.Range(0, upgrades.Count);
            Upgrade u = upgrades[choice];
            choices.Add(u);
            buttons[i].text = u.upgrade;
        }

        overlay.SetActive(true);



    }
    public void RecieveAnswer(int sel)
    {
        overlay.SetActive(false);
        Time.timeScale = 1;

        IterateInDictionary(choices[sel]);
        choices.Clear();
        ApplyUpgrades();
    }
    public void IterateInDictionary(Upgrade u)
    {
        upgradeStack[u] += 1;
        Debug.Log("stack for " + u + " is now at " + upgradeStack[u]);
    }

    public List<Upgrade> activeUpgrades;


    public List<Upgrade> StripEmptyUpgrades(List<Upgrade> l)
    {
        List<Upgrade> stripped = new List<Upgrade>(l);

        foreach (Upgrade u in l)
        {

            if (upgradeStack[u] == 0)
            {
                stripped.Remove(u);
                Debug.Log("Removed " + u.upgrade + " from Upgrades to Apply");
            }
        }

        return stripped;
    }
    public void ApplyUpgrades()
    {
        activeUpgrades.Clear();

        foreach (Upgrade u in StripEmptyUpgrades(upgrades))
        {
            activeUpgrades.Add(u);
            Debug.Log("Applying " + u.upgrade + " " + upgradeStack[u] + " Times");


        }
        foreach (Upgrade u in activeUpgrades)
        {
            for (int i = 0; i < upgradeStack[u]; i++)
            {
                ApplyThisUpgrade(u);
            }
        }

        disp.text = UpgradesToText(activeUpgrades);

        //UpdateUI();
    }
    
    public TMP_Text disp;
    public string UpgradesToText(List<Upgrade> list)
    {
        string result = "";
        foreach (Upgrade u in list)
        {
            result += upgradeStack[u] + " " + u.shorthandKey + "\n";
        }
        result.Replace("E", "E-");
        result.Replace("(Upgrade)", "");
        return result;
    }
}
