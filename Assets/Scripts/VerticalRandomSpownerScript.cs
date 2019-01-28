using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerticalRandomSpownerScript : MonoBehaviour
{

    //アイテム4つを保持できるGameObject型の配列を宣言
    [SerializeField] GameObject[] randomItems = new GameObject[4];
    //[SerializeField]は『Unityからアタッチできるようにする！』っていう意味！

    float timer;
	[SerializeField] float interval;//各種Item生成の間隔を調整

    [SerializeField] GameObject gameManager;//UnityからGameManagerをアタッチ
    GameManagerScript gameManagerScript;//取得したGameManagerScriptを格納しておく為の変数

	void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();//gameManagerにくっついているGameManagerScriptを取得→変数gameManagerScriptに格納
		if (SceneManager.GetActiveScene().name == "Main")
        {
            timer = -2.5f;
        }
        else
        {
            timer = 0;
        }
    }

    void Update()
    {
        if (gameManagerScript.isPlaying == true)//GameManagerの中のisPlayingがtrueの時だけ...
        {
            InstantiateRandomItem();//Itemを生成する
        }
    }


    void InstantiateRandomItem()
    {
        timer += Time.deltaTime;
        if (timer > interval)//設定した時間が過ぎた時
        {
            int randomNum = Random.Range(0, 4);
            Instantiate(randomItems[randomNum], this.transform.position + this.transform.right * Random.Range(-20.0f, 20.0f), this.transform.rotation);
            //Debug.Log("randomItem[" + randomNum + "]を生成");
            timer = Random.Range(0, 2);
        }
    }
}
