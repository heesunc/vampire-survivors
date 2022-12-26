using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed; // 속도를 편리하게 관리할 수 있도록 float 변수 추가

    // Component 가져오기
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    
    // Start is called before the first frame update
    void Awake()
    {
        // Component 가져온거 초기화 시켜주기
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     inputVec.x = Input.GetAxisRaw("Horizontal"); // 어떤 좌표 넣을 것이냐
    //     inputVec.y = Input.GetAxis("Vertical"); 
    // }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value) // InputValue 타입의 매개변수 작성
    {
        inputVec = value.Get<Vector2>(); // nomalized를 사용하고 있기 때문에 nextVec에서 지워줘도 됨
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        
        if (inputVec.x != 0) // inputVec.x가 0이 아닐 때
        {
            spriter.flipX = inputVec.x < 0; // 비교 연산자의 값을 True, False로 바로 넣어줌
        }
    }
}
