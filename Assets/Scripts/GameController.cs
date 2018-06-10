using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public UnityEngine.UI.Text scoreLabel;
    public GameObject winnerLabelObject;
    public GameObject winnerLabel2Object;

    public void Update () {

        int count = GameObject.FindGameObjectsWithTag("Item").Length;
        scoreLabel.text = count.ToString();

        if (count == 0)
        {
            // クリア時の処理：オブジェクトをアクティブにする
            winnerLabelObject.SetActive(true);
            winnerLabel2Object.SetActive(true);
            if (Input.GetButtonDown("Submit"))
            {
                SceneManager.LoadScene(0);
            }
        }

    }
}
