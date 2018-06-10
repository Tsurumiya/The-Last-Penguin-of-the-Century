using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // speedを制御する
    public float speed = 10;

    private AudioSource sound01;
    private AudioSource sound02;

    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Item"))
        {
            int count = GameObject.FindGameObjectsWithTag("Item").Length;
            
            if (count != 0)
            {
                sound01.PlayOneShot(sound01.clip);
            }
            else
            {
                sound02.PlayOneShot(sound02.clip);
            }
        }         
    }

    // Update is called once per frame
    void FixedUpdate () {
        
        // 入力をxとzに代入
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        // 同一のGameObjectが持つRigidbodyコンポーネントを取得
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        // rigidbodyのx軸（横）とz軸（奥）に力を加える；xとzにspeedを掛ける
        rigidbody.AddForce(x * speed, 0, z * speed);
                
    }
}