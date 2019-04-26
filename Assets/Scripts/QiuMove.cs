using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QiuMove : MonoBehaviour
{

    public float Power = 10;//這個代表發射时的速度/力度等
    public float Angle = 45;//發射的角度
    public float Gravity = -10;//重力加速度

    private Vector3 MoveSpeed;//初速度向量
    private Vector3 GritySpeed = Vector3.zero;//重力的速度向量，t時為0
    private float dTime;//已經過去的時間
    private Vector3 currentAngle;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 5.0f);                      //消失
    }

    // Update is called once per frame
    void Update()
    {
        //通過一個公式計算出初速度向量

        //角度*力度

        MoveSpeed = Quaternion.Euler(new Vector3(0, 0, Angle)) * Vector3.right * Power;

        currentAngle = Vector3.zero;

    }

    // Update is called once per frame

    void FixedUpdate()

    {

        //計算物体的重力速度

        //v = at ;

        GritySpeed.y = Gravity * (dTime += Time.fixedDeltaTime);

        //位移模擬軌跡

        transform.position += (MoveSpeed + GritySpeed) * Time.fixedDeltaTime;

        currentAngle.z = Mathf.Atan((MoveSpeed.y + GritySpeed.y) / MoveSpeed.x) * Mathf.Rad2Deg;

        transform.eulerAngles = currentAngle;

    }
}
