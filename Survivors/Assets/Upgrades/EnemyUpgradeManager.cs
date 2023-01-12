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
    IDictionary<Upgrade, int> upgradeStack = new Dictionary<Upgrade, int>();

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
        Debug.Log(sel);
        AddToDictionary(choices[sel]);
        choices.Clear();
        ApplyUpgrades();
    }
    public void AddToDictionary(Upgrade u)
    {
        upgradeStack[u] += 1;
        Debug.Log("stack for " + u + " is now at " + upgradeStack[u]);
    }

    public List<Upgrade> appliedUpgrades;
    public void ApplyUpgrades()
    {
        foreach (Upgrade u in StripEmptyUpgrades(upgrades))
        {
            Debug.Log("Applying " + u.upgrade + " " + upgradeStack[u] + "Times");
            appliedUpgrades.Add(u);
        }
    }
    public List<Upgrade> StripEmptyUpgrades(List<Upgrade> l)
    {
        List<Upgrade> stripped = l;

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


    public void ParseToStrings()
    {

    }

}
