using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;

    private Rigidbody2D rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxis("Horizontal"); // 어떤 좌표 넣을 것이냐
        inputVec.y = Input.GetAxis("Vertical"); 
    }
}
