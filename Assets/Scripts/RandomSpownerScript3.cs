using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpownerScript3 : MonoBehaviour
{

    [SerializeField] GameObject[] randomItems = new GameObject[4];
    [SerializeField] GameObject gameManager;//UnityからGameManagerをアタッチ
    GameManagerScript gameManagerScript;//取得したGameManagerScriptを格納しておく為の変数

    float timer;




    // Use this for initialization
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();//gameManagerにくっついているGameManagerScriptを取得→変数gameManagerScriptに格納

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isPlaying == true)//GameManagerの中のisPlayingがtrueの時だけ...
        {
            InstantiateItem();//MinusItemを生成する
        }

    }

    void InstantiateItem()
    {
        timer += Time.deltaTime;
        if (timer > 1.5f)
        {
            int randomNum = Random.Range(0, 4);
            Instantiate(randomItems[randomNum], this.transform.position + this.transform.right * Random.Range(-10.0f, 10.0f), this.transform.rotation);
            Debug.Log("randomItem[" + randomNum + "]を生成");
            timer = 0;
        }
    }

}
