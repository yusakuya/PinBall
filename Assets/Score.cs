using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int score = 0;
    private GameObject ScoreText;

    // Use this for initialization
    void Start() {
        this.ScoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update () {
        this.ScoreText.GetComponent<Text>().text = "Score " + score;
    }

    void OnCollisionEnter(Collision hoge)
    {
        if (hoge.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (hoge.gameObject.tag == "LargeStarTag")
        {
            score += 30;
        }
        else if (hoge.gameObject.tag == "SmallCloudTag")
        {
            score += 20;
        }
        else if (hoge.gameObject.tag == "LargeCloudTag"){
            score += 40;
        }
    }
}
