using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RePosition : MonoBehaviour
{
    private Collider2D coll;
    // Collider2D는 써클이든 뭐든 다 가지고 있음

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        // float diffX = Mathf.Abs(playerPos.x - myPos.x);
        // float diffY = Mathf.Abs(playerPos.y - myPos.y);
        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;
        
        float diffX = Mathf.Abs(dirX);
        float diffY = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        Vector3 playerDir = GameManager.instance.player.inputVec;
        // float dirX = playerDir.x < 0 ? -1 : 1;
        // float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag) {
            case "Ground":
                if (diffX > diffY) {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX < diffY) {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;
            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(UnityEngine.Random.Range(-3f, 3f), UnityEngine.Random.Range(-3f, 3f),0f));
                }
                break;
        }
    }
}