using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinusItemScript: MonoBehaviour {

    int energy;
	GameManagerScript gameManagerScript;

	Rigidbody rb;
    float speed;

	[SerializeField] GameObject effect;
    
	void Start () {
        Destroy(this.gameObject, 15.0f);

		rb = this.gameObject.GetComponent<Rigidbody>();
        speed = Random.Range(5, 9);
        rb.velocity = this.transform.forward * speed;

		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

	void Update () {
		//Mainシーンの時だけ処理
        if (SceneManager.GetActiveScene().name == "Main")
        {
            if (gameManagerScript.isPlaying == false)//isPlayingがfaleになったら
            {
                Destroy(this.gameObject);
                Instantiate(effect, this.transform.position, Quaternion.identity);//破壊エフェクト生成
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            energy = Random.Range(-10, -1);
            PlayerPrefs.SetInt("MinusScore", energy);

            Destroy(this.gameObject);
            Debug.Log("エネルギー" + energy + "ダウン");

        }
    }

}
