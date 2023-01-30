using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnGameStart : MonoBehaviour
{
    void Update()
    {
        if (GameManager.GM.roundStarted)
        {
            gameObject.SetActive(false);
        }
    }
}
