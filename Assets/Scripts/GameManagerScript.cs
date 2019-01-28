using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour {

	[SerializeField] Text scoreText;
	[SerializeField] Text countdownTimerText;
    [SerializeField] Text timerText;
	[SerializeField] GameObject ui;
	[SerializeField] GameObject pannel;

    public int score;
    float timer = 15.0f;//Play時間司るタイマー
	float timer2;//ゲーム終了からResult画面行くまでの時間司るタイマー
	float countdownTimer = 3.5f;
	[SerializeField] float interval;//ゲーム終了からResult画面行くまでの時間を調整
    public bool isPlaying;

	void Start () {
        isPlaying = true;
		if(SceneManager.GetActiveScene().name == "Main")//Mainシーンの時だけ処理
		{
			ui.SetActive(false);//UI非表示
			score = 100;
		}
	}

	void Update () {
		//Mainシーンの時だけ処理
		if(SceneManager.GetActiveScene().name == "Main")
		{
			countdownTimer -= Time.deltaTime;//カウントダウン開始
			countdownTimerText.text = countdownTimer.ToString("f0");
			if(countdownTimer < 0.5)
			{
				ui.SetActive(true);//UIを表示
				countdownTimerText.text = "";
				pannel.SetActive(false);

				timer -= Time.deltaTime;
                timerText.text = timer.ToString("f1") + "s";
                if (timer <= 0)
                {
                    isPlaying = false;
                    ui.SetActive(false);//UIを表示
                    timerText.text = "";
                    timer = 0.0f;
                    Time.timeScale = 0.2f;//スローに
					PlayerPrefs.SetInt("score", score);
                }   
			}
			scoreText.text = score.ToString();
		}

		if(isPlaying == false)
		{
			timer2 += Time.deltaTime;//timer2スタート
			if(timer2 > interval)//基準値超えたら
			{
				SceneManager.LoadScene("ResultScene");
			}
		}
	}
}
