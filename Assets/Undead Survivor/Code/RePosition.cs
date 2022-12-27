using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        // OnTriggerExit2D의 매개변수 상대방 콜라이더의 태그를 조건으로
        if (!collision.CompareTag("Area"))
            return; // Tag가 Area가 아니면 return해줌
        
        // 거리를 구하기 위해 플레이어 위치와 타일맵 위치를 미리 저장
        Vector3 playerPos = GameManager.instance.transform.position;
        Vector3 myPos = transform.position;
        
        // 플레이어 위치 - 타일맵 위치 계산으로 거리 구하기
        // 무조건 + 값이여야 하기 때문에 Mathf.Abs : 절대값 함수 사용
        
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);
        
        // 플레이어의 이동 방향을 저장하기 위한 변수 추가
        Vector3 playerDir = GameManager.instance.player.inputVec;
        
        // Normallized 대각선 값때문에 삼항연산자로 작성 조건?true:false
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY) {
                    transform.Translate(dirX * 40, 0, 0);
                } else if (diffX < diffY) {
                    transform.Translate(0, dirY * 40, 0);
                } else {
                    transform.Translate(dirX * 40, dirY * 40, 0);
                }
                break;
            case "Enemy":
                break;
        }
    }
}
