using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public PoolManager pool;

    void Awake()
    {
        instance = this; 
        // Awake 생명주기에서 인스턴스 변수를 자기자신 this로 초기화
    }

    void Update()
    {
        
    }
}


