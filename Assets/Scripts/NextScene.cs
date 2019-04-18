using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
