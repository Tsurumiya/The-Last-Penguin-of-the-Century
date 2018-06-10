using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#

public class Wall : MonoBehaviour {
    public AudioSource Audio;
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision hit)
    {
        // 接触したオブジェクトのタグが"Player"の場合
        if (hit.gameObject.CompareTag("Player"))
        {
            Audio.Play();
            GamePad.SetVibration(playerIndex, 0.8f, 0.8f);
            Invoke("MyWaitingFunction", 0.1f);
        }
    }
    void MyWaitingFunction()
    {
        GamePad.SetVibration(playerIndex, 0, 0);
    }
}
