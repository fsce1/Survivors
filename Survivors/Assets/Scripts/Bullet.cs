using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }

//    private void Update()
//    {
//        transform.eulerAngles += new Vector3(0,0,1);
//    }
//}
