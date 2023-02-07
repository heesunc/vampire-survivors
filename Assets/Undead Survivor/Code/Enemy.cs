using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    // 속도, 목표, 생존여부를 위한 변수 선언
    public Rigidbody2D target;
    
    // 몬스터의 생존여부
    private bool isLive = true;

    private Rigidbody2D rigid;
    private SpriteRenderer spriter;
    
    void Awake()
    {
        // 초기화
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!isLive)
            return; // 살아있지 않으면 아래꺼 실행X
        // 위치 차이 = 타겟 위치 - 나의 위치
        Vector2 dirVec = target.position - rigid.position;
        // 방향 = 위치 차이의 정규화
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        // 플레이어의 키입력 값을 더한 이동 = 몬스터의 방향 값을 더한 이동
        rigid.MovePosition(rigid.position + nextVec);
        // 물리 속도가 이동에 영향을 주지 않도록 속도 제거
        rigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        if (!isLive)
            return;
        // 목표의 X축 값과 자신의 X축 값을 비교하여 작으면 true가 되도록 작성
        spriter.flipX = target.position.x < rigid.position.x;
    }
}
