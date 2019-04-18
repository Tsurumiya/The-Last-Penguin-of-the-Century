using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

    float time;
    public Text highScoreText; //ハイスコアを表示するText
    private int score;
    private int highScore;
    private int millis;
    private int highmillis;//ハイスコア用変数
    private string key1 = "HIGH SCORE"; //ハイスコアの保存先キー
    private string key2 = "HIGH SCORE MILLISECONDS"; //ハイスコアの保存先キー

    // Use this for initialization
    void Start () {
        time = 0;
        highScore = PlayerPrefs.GetInt(key1, 600);
        highmillis = PlayerPrefs.GetInt(key2, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ600になる
        int minute = highScore / 60;//分.timeを60で割った値.
        int second = highScore % 60;//秒.timeを60で割った余り.
        string minText, secText, msText;//テキスト形式の分・秒を用意.
        if (minute < 10)
            minText = "0" + minute.ToString();//ToStringでint→stringに変換.
        else
            minText = minute.ToString();
        if (second < 10)
            secText = "0" + second.ToString();//上に同じく.
        else
            secText = second.ToString();
        if (highmillis < 10)
            msText = "0" + highmillis.ToString();//上に同じく.
        else
            msText = highmillis.ToString();

        highScoreText.text = "HIGHSCORE " + minText + ":" + secText + ":" + msText;
        //ハイスコアを表示
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
        int count = GameObject.FindGameObjectsWithTag("Item").Length;
        if (count == 0)
        {
            int score = (int)time;
            float fraction = time * 100;
            fraction = (fraction % 100);
            int millis = (int)fraction;
            //ハイスコアより現在時間が短い時
            if (score < highScore)
            {
                highScore = score;
                highmillis = millis;
                //ハイスコア更新

                PlayerPrefs.SetInt(key1, highScore);
                //ハイスコアを保存
                highScore = PlayerPrefs.GetInt(key1, 600);
                //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ600になる

                PlayerPrefs.SetInt(key2, highmillis);
                highmillis = PlayerPrefs.GetInt(key2, 0);

                int minute = highScore / 60;//分.timeを60で割った値.
                int second = highScore % 60;//秒.timeを60で割った余り.
                string minText, secText, msText;//テキスト形式の分・秒を用意.
                if (minute < 10)
                    minText = "0" + minute.ToString();//ToStringでint→stringに変換.
                else
                    minText = minute.ToString();
                if (second < 10)
                    secText = "0" + second.ToString();//上に同じく.
                else
                    secText = second.ToString();
                if (highmillis < 10)
                    msText = "0" + highmillis.ToString();//上に同じく.
                else
                    msText = highmillis.ToString();

                highScoreText.text = "HIGHSCORE " + minText + ":" + secText + ":" + msText;
                //ハイスコアを表示                    
            }
            if (score == highScore)
            {
                if (millis < highmillis)
                {
                    //上と同じ
                    highScore = score;
                    highmillis = millis;
                    //ハイスコア更新

                    PlayerPrefs.SetInt(key1, highScore);
                    //ハイスコアを保存
                    highScore = PlayerPrefs.GetInt(key1, 600);
                    //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ600になる

                    PlayerPrefs.SetInt(key2, highmillis);
                    highmillis = PlayerPrefs.GetInt(key2, 0);

                    int minute = highScore / 60;//分.timeを60で割った値.
                    int second = highScore % 60;//秒.timeを60で割った余り.
                    string minText, secText, msText;//テキスト形式の分・秒を用意.
                    if (minute < 10)
                        minText = "0" + minute.ToString();//ToStringでint→stringに変換.
                    else
                        minText = minute.ToString();
                    if (second < 10)
                        secText = "0" + second.ToString();//上に同じく.
                    else
                        secText = second.ToString();
                    if (highmillis < 10)
                        msText = "0" + highmillis.ToString();//上に同じく.
                    else
                        msText = highmillis.ToString();

                    highScoreText.text = "HIGHSCORE " + minText + ":" + secText + ":" + msText;
                    //ハイスコアを表示
                }
            }
            Time.timeScale = 0;
        }
    }
}
