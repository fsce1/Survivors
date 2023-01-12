using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    //public float lifetime;
    public int dmg;
    public GameObject weaponFiredFrom;
    public bool firedFromPlayer;
    public TMP_Text rend;
    private void Start()
    {
        if(firedFromPlayer)
        {
            rend.color = Color.gray;
        }
        else
        {
            rend.color = Color.white;

        }
        //StartCoroutine(BulletLifetime(lifetime));

    }

    //public IEnumerator BulletLifetime(float t)
    //{
    //    while (t > 0)
    //    {
    //        t -= 0.1f;
    //        transform.localScale = new Vector2(t, t);
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //    OnRangerTimer();
    //}
    //void OnRangerTimer() { 
    //}
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {           
            case "Player":
                if (!firedFromPlayer && col.gameObject.GetComponent<PlayerController>() is PlayerController pc)
                {
                    pc.TakeDamage(dmg,weaponFiredFrom);
                    Destroy(gameObject);
                }
                break;

            case "Enemy":
                if (firedFromPlayer && col.gameObject.GetComponent<EnemyController>() is EnemyController ec)
                {
                    ec.TakeDamage(dmg);
                    Destroy(gameObject);
                }
                break;
        }

    }
}

//    private void Update()
//    {
//        transform.eulerAngles += new Vector3(0,0,1);
//    }
//}
