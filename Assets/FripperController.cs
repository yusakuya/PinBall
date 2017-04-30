using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HinjiJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (OnTouchDown())
        {
            SetAngle(this.flickAngle);
        }
        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

    //スマホ向け そのオブジェクトがタッチされていたらtrue（マルチタップ対応）
    bool OnTouchDown()
    {
        float width = Screen.width;
        width /= 2;
        // タッチされているとき
        if (0 < Input.touchCount)
        {
            // タッチされている指の数だけ処理
            for (int i = 0; i < Input.touchCount; i++)
            {
                // タッチ情報をコピー
                Touch t = Input.GetTouch(i);
                // タッチ座標を取得
                if (Input.touches[i].position.x >= width && tag == "RightFripperTag")
                {
                    // タッチしたときかどうか
                    if (t.phase == TouchPhase.Began)
                    {
                        SetAngle(this.flickAngle);
                    }
                    if (t.phase == TouchPhase.Ended)
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
                if (Input.touches[i].position.x < width && tag == "LeftFripperTag")
                {
                    // タッチしたときかどうか
                    if (t.phase == TouchPhase.Began)
                    {
                        SetAngle(this.flickAngle);
                    }
                    if (t.phase == TouchPhase.Ended)
                    {
                        SetAngle(this.defaultAngle);
                    }
                }
            }
        }
        return false; //タッチされてなかったらfalse
    }

}