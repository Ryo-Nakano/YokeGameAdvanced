using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSceneManger : MonoBehaviour {

	[SerializeField] GameObject pannel;
	[SerializeField] Text guideText;
	[SerializeField] GameObject ui;
	float timer;
	Image image;

	float speed = 0.01f;
    float red, green, blue;
	float alfa;//透明度

	int lastScore;
	int highScore;
	[SerializeField] Text lastScoreText;
	[SerializeField] Text highScoreText;

	void Start () {
		Time.timeScale = 1.0f;
		ui.gameObject.SetActive(false);

		image = pannel.gameObject.GetComponent<Image>();

		red = image.color.r;
		green = image.color.g;
		blue = image.color.b;

		CreateScore();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;//タイマー作動
        if (timer > 1.7f)
        {
            timer = 0;
        }
        else if (timer > 1.5f)
        {
            guideText.text = "";
        }
        else if (timer <= 0.8f)
        {
			guideText.text = "Press SpaceKey to Retry";
        }

        if(Input.GetKeyDown("space")== true){
            SceneManager.LoadScene("StartScene");
        }

		Fade();//Pannelをフェードさせる関数
	}

	void Fade()
	{
		if(alfa < 0.275)
		{
			image.color = new Color(red, green, blue, alfa);
            alfa += speed;
		}
		else
		{
			ui.gameObject.SetActive(true);
		}
	}

	public void CreateScore()
    {
		lastScore = PlayerPrefs.GetInt("score");
        lastScoreText.text = lastScore.ToString();

        if (PlayerPrefs.HasKey("highScore") == true)
        {
            highScore = PlayerPrefs.GetInt("highScore");
            Debug.Log(highScore);
            if (highScore < lastScore)
            {
                highScore = lastScore;
                PlayerPrefs.SetInt("highScore", highScore);

            }
        }
        else
        {
            highScore = lastScore;
            PlayerPrefs.SetInt("highScore", highScore);
            highScoreText.text = highScore.ToString();
        }
        highScoreText.text = highScore.ToString();
    }
}
