using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour {

	float timer;
	[SerializeField] Text guideText;


	void Start () {
		
	}

	void Update () {
		timer += Time.deltaTime;//タイマー作動
		if(timer > 1.7f)
		{
			timer = 0;
		}
		else if(timer > 1.5f)
		{
			guideText.text = "";
		}
		else if(timer <= 0.8f)
		{
			guideText.text = "Press Space Key";
		}

        if(Input.GetKeyDown("space")== true){
            SceneManager.LoadScene("Main");
        }
	}
}
