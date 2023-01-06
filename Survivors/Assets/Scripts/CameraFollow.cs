using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float camMoveSpeed = 5;
    public bool blockUpdate;

    void FixedUpdate()
    {
        if (blockUpdate) return;
        Vector2 dirToMove = GameManager.GM.player.transform.position - transform.position;
        transform.position += new Vector3(dirToMove.x * Time.deltaTime * camMoveSpeed, dirToMove.y * Time.deltaTime * camMoveSpeed);
    }
}