using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlusItem2Script: MonoBehaviour {

    int energy;

	Rigidbody rb;
    float speed;

	GameManagerScript gameManagerScript;
	[SerializeField] GameObject effect;

    void Start()
    {
        Destroy(this.gameObject, 15.0f);

        rb = this.gameObject.GetComponent<Rigidbody>();
        speed = Random.Range(5, 9);
        rb.velocity = this.transform.forward * speed;

		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void Update()
    {
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
            Destroy(this.gameObject);
            energy = Random.Range(10, 15);
            PlayerPrefs.SetInt("PlusScore2", energy);
            Debug.Log("エネルギー" + energy + "ゲット");
           

        }
    }

}
