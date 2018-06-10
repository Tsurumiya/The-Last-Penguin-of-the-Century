using UnityEngine;
using System.Collections;
using XInputDotNetPure; // Required in C#

public class DangerWall : MonoBehaviour {
    public AudioSource Audio;

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    void Start()
    {
        Audio = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (!playerIndexSet || !prevState.IsConnected)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    playerIndex = testPlayerIndex;
                    playerIndexSet = true;
                }
            }
        }
    }
    // オブジェクトと接触した時に呼ばれるコールバック

    void OnCollisionEnter(Collision hit)
    {
        // 接触したオブジェクトのタグが"Player"の場合
        if (hit.gameObject.CompareTag("Player"))
        {
            Audio.Play();
            hit.rigidbody.velocity = transform.TransformDirection(new Vector3(Random.Range(-10, 10), 20, Random.Range(-10, 10)));
            GamePad.SetVibration(playerIndex, 1f, 1f);
            Invoke("MyWaitingFunction", 0.4f);

        }
    }

    void MyWaitingFunction()
    {
        GamePad.SetVibration(playerIndex, 0, 0);
    }

}
