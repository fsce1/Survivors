using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    #region SINGLETON
    public static UpgradeManager UM;
    private void Awake()
    {
        if (UM != null && UM != this) Destroy(this);
        else UM = this;
    }
    #endregion
    #region SETUP + ENEMY UPGRADE UI
    private void Start()
    {
        SetupDictionary();
    }
    public void SetupDictionary()
    {
        foreach (Upgrade u in eMasterUpgrades) upgradeStack.Add(u, 0);
    }

    public List<Upgrade> eMasterUpgrades;
    public List<Upgrade> eActiveUpgrades;
    public IDictionary<Upgrade, int> upgradeStack = new Dictionary<Upgrade, int>();
    public GameObject overlay;

    [Header("UI")]
    public List<Tooltips> buttons;
    public List<Upgrade> choices;
    public int choiceNum;
    public TMP_Text eDisp;
    public TMP_Text pDisp;

    public void DisplayEnemyUpgrades() //Called every RoundTimer
    {

        for (int i = 0; i < choiceNum; i++)
        {
            int choice = Random.Range(0, eMasterUpgrades.Count);
            Upgrade u = eMasterUpgrades[choice];
            choices.Add(u);
            buttons[i].upgrade = u;
        }

        Time.timeScale = 0;
        overlay.SetActive(true);
    }
    public void RecieveAnswer(int sel)
    {
        IterateInDictionary(choices[sel]);
        choices.Clear(); //clean up enemy upgrades in choices
        ApplyUpgrades();

        Time.timeScale = 1;
        overlay.SetActive(false);
    }
    #endregion
    #region ENEMY + PLAYER VARS
    [Header("Enemy Vars")]
    public float eMultMuzzleVelocity = 1;
    public float eMultMoveSpeed = 1;
    public Vector2 eFiringSpeed = new Vector2(2, 4);
    public int eMaxHealth = 3;
    public Vector2 eGroupAmount = new Vector2(5, 15);
    public int eDmg = 1;

    [Header("Player Vars")]
    public float pMultMoveSpeed;
    public float pMaxSpeed;
    public int maxHealth;
    #endregion
    void ApplyThisUpgrade(Upgrade u)
    {
        switch (u.shorthandKey)
        {
            case "E-MM":
                eFiringSpeed.x -= 0.25f; eFiringSpeed.y -= 0.25f;
                break;
            case "E-RA":
                eMaxHealth += 1;
                break;
            case "E-WB":
                eMultMoveSpeed += 0.1f;
                break;
            case "E-RT":
                eGroupAmount.y += 1;
                break;
            case "E-PP":
                eGroupAmount.x += 1;
                break;
            case "E-BB":
                eMultMuzzleVelocity += 0.1f;
                break;
        }
    }
    public void IterateInDictionary(Upgrade u)
    {
        upgradeStack[u] += 1;
    }
    public List<Upgrade> StripEmptyUpgrades(List<Upgrade> listToStrip)
    {
        List<Upgrade> stripped = new List<Upgrade>(listToStrip);

        foreach (Upgrade u in listToStrip)
        {
            if (upgradeStack[u] == 0)
            {
                stripped.Remove(u);
            }
        }
        return stripped;
    }
    public void ApplyUpgrades()
    {
        eActiveUpgrades.Clear();

        foreach (Upgrade u in StripEmptyUpgrades(eMasterUpgrades))
        {
            eActiveUpgrades.Add(u);

        }
        foreach (Upgrade u in eActiveUpgrades)
        {
            for (int i = 0; i < upgradeStack[u]; i++)
            {
                ApplyThisUpgrade(u);
            }
        }

        eDisp.text = UpgradesToText(eActiveUpgrades);

        //UpdateUI();
    }
    public string UpgradesToText(List<Upgrade> list)
    {
        string result = "";
        foreach (Upgrade u in list)
        {

            result += upgradeStack[u] + " " + u.shorthandKey + "\n";
        }
        result.Replace("P", "P  -  ");
        result.Replace("E", "E  -  ");
        result.Replace("(Upgrade)", "");
        return result;
    }

    public List<Upgrade> pUpgrades;
    public void ApplyThisPlayerUpgrade(Upgrade u)
    {
        pUpgrades.Add(u);

        //pDisp.text = UpgradesToText(pUpgrades);
        switch (u.shorthandKey)
        {
            case "P-GH":
                pMultMoveSpeed += 0.1f; pMaxSpeed += 0.1f;
                break;
            case "P-CH":
                maxHealth += 1;
                GameManager.GM.player.health++;
                break;
        }
    }


}
