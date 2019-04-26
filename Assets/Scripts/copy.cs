using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copy : MonoBehaviour
{

    public GameObject a;

    public float t1;     //定義一個時間，可以在面板輸入，這個時間是從小球發射至小球消失的時間，為2時是個距離，4秒是個距離 。做個循環(幾秒實例化一個)

    private float t2;    //定義一個後台運行的，私有的时间。从開始運行至结束運行的時間。（這個時間用於輔助計算）

    // Use this for initialization

    void Start()
    {
        t2 = t1;        // 把面板输入的t1赋值给t2;

    }

    // Update is called once per frame
    void Update()
    {
        t2 = t2 - Time.deltaTime;      //把面板输入的時間，“1”，减去0.0000X，直至為0，也就是1秒過去了，實例化複製這個小球，1秒複製1個。

        if (t2 <= 0)
        {

            Instantiate(a);

            t2 = t1;                                       //重複赋值，重複運行

        }

    }
}
