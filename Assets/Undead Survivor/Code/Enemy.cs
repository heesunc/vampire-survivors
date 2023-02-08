using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float maxHealth;
    // 속도, 목표, 생존여부를 위한 변수 선언
    public Rigidbody2D target;
    public RuntimeAnimatorController[] animCon;
    
    
    // 몬스터의 생존여부
    private bool isLive;

    private Rigidbody2D rigid;
    private Animator anim;
    private SpriteRenderer spriter;
    
    void Awake()
    {
        // 초기화
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        // 매개변수의 속성을 몬스터 속성 변경에 활용
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }
}
