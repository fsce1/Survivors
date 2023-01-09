using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public enum WeaponType
    {   None,
        Pistol,
        Shotgun
    }
    public WeaponType wType;
    void Start()
    {
        
    }
    public void Fire()
    {
        Debug.Log("Bang!" + wType.ToString());
    }
    void Update()
    {
        
    }
}
