using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리펩들을 저장할 배열 변수 선언
    public GameObject[] prefabs;
    
    // 오브젝트 풀들을 저장할 배열 변수 선언
    private List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
        
        Debug.Log(pools.Length);
    }

    public GameObject Get(int index)
    {
        GameObject select = null; // 지역변수
        
        // 선택한 풀의 놀고 있는(비활성화 된) 게임 오브젝트 접근
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf) // activeSelf : 내용물 오브젝트가 활성화(대기 상태)인지 확인
            {
                // 발견하면 select 변수에 할당
                select = item;
                select.SetActive(true); // 찾으면 활성화
                break; // 발견했으니 반복문 종료
            }
        }

        // 못 찾았으면?
        if (!select)
        {
            // 새롭게 생성하고 select 변수에 할당
            select = Instantiate(prefabs[index], transform);
            // Instantiate : 원본 오브젝트를 복제하여 장면에 생성하는 함수
            pools[index].Add(select);
        }
        return select;
    }
}
