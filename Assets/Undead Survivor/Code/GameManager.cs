using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // 게임 시간과 최대 게임 시간을 담당할 변수 선언
    public float gameTime;
    public float maxGameTime = 2 * 10f; //2분
    
    public Player player;
    public PoolManager pool;

    void Awake()
    {
        instance = this; 
        // Awake 생명주기에서 인스턴스 변수를 자기자신 this로 초기화
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}


