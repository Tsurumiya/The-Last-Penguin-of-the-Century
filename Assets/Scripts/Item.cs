using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{
    float RotationSpeed = 1; //定义自转的速度
        
    float radian = 0; // 弧度  
    float perRadian = 0.05f; // 每次变化的弧度  
    float radius = 0.1f; // 半径  
    Vector3 oldPos; // 开始时候的坐标  
    
    // Use this for initialization  
    void Start()
    {
        oldPos = transform.position; // 将最初的位置保存到oldPos  
    }

    // Update is called once per frame  
    void Update()
    {
        radian += perRadian; // 弧度每次加0.03  
        float dy = Mathf.Cos(radian) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以  
        transform.position = oldPos + new Vector3(0, dy, 0);

        transform.Rotate(Vector3.down * RotationSpeed, Space.World); //物体自转
    }
    
    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter(Collider hit)
    {
        // 接触対象はPlayerタグですか？
        if (hit.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}