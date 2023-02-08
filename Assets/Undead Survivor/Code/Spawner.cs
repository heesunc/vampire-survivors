using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;
    private float timer;
    private int level;
    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>(); // 배열이라서 컴포넌트s!!
    }

    void Update()
    {
        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1);
        // FloorToInt : 소수점 아래는 버리고 Int형으로 바꾸는 함수, 올리는 건 CeilToInt
        // 인덱스 에러는 레벨 변수 계산 시 Min 함수를 사용하여 막을 수 있음

        if (timer > spawnData[level].spawnTime)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[UnityEngine.Random.Range(1, spawnPoint.Length)].position; 
                                    // 자식 오브젝트에서만 선택되도록 랜덤 시작을 1부터
        enemy.GetComponent<Enemy>().Init(spawnData[level]); // 소환데이터 인자값 전달
    }
}


// 직렬화 (Serialization) : 개체를 저장 혹은 전송하기 위해 변환
[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}