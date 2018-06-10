using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float time;//時間を記録する小数も入る変数.
    Text text;

    void Start()
    {
        time = 0;
        text = GetComponent<Text>();//自分のインスペクター内からTextコンポーネントを取得.
    }

    void Update()
    {
        time += Time.deltaTime;//毎フレームの時間を加算.
        int minute = (int)time / 60;//分.timeを60で割った値.
        int second = (int)time % 60;//秒.timeを60で割った余り.
        float fraction = time * 100;
        fraction = (fraction % 100);
        int millis = (int)fraction;
        string minText, secText, msText;//テキスト形式の分・秒を用意.
        if (minute < 10)
            minText = "0" + minute.ToString();//ToStringでint→stringに変換.
        else
            minText = minute.ToString();
        if (second < 10)
            secText = "0" + second.ToString();//上に同じく.
        else
            secText = second.ToString();
        if (millis < 10)
            msText = "0" + millis.ToString();//上に同じく.
        else
            msText = millis.ToString();

        text.text = minText + ":" + secText + ":" + msText;
    }
}