using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    private float timer;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>(); // 배열이라서 컴포넌트s!!
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.2f)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(UnityEngine.Random.Range(0,2));
        enemy.transform.position = spawnPoint[UnityEngine.Random.Range(1, spawnPoint.Length)].position; 
                                    // 자식 오브젝트에서만 선택되도록 랜덤 시작을 1부터
    }
}
