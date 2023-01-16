using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UP", menuName = "Upgrades/New Upgrade", order = 1)]
public class Upgrade : ScriptableObject
{
    //public enum UpgradeType
    //{
    //    ContainerOfHearts,
    //    WindsBlow,
    //    MarksmansScope

    //}
    //public enum EnemyUpgradeType
    //{
    //    StrongArmor,
    //    MarksmansMeal,



    //}
    //public UpgradeType upgradeType;
    //public EnemyUpgradeType enemyUpgradeType;
    public bool isEnemy;
    public string shorthandKey;
    public string upgrade;
    public string description;
}
