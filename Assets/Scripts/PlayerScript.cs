using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{
    int score;
	[SerializeField] float speed;

	GameManagerScript gameManagerScript;
    [SerializeField] GameObject effect;

    void Start()
    {
		gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void Update()
    {
		Move();

		if (gameManagerScript.isPlaying == false)//isPlayingがfaleになったら
        {
            Destroy(this.gameObject);
            Instantiate(effect, this.transform.position, Quaternion.identity);//破壊エフェクト生成
        }
    }

	void Move()
	{
		if (Input.GetKey("up") == true)
        {
            if (this.transform.position.z < 12)
            {
                this.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            }
        }
        if (Input.GetKey("down") == true)
        {
            if (this.transform.position.z > -12)
            {
                this.transform.position -= new Vector3(0, 0, speed * Time.deltaTime);
            }
        }
        if (Input.GetKey("right") == true)
        {
            if (this.transform.position.x < 22)
            {
                this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
        if (Input.GetKey("left") == true)
        {
            if (this.transform.position.x > -21)
            {
                this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }
	}

    void OnTriggerEnter(Collider col) 
    {
        int minuspoints2 = PlayerPrefs.GetInt("MinusScore2");
        if (col.gameObject.tag == "MinusItem2") {
			gameManagerScript.score += minuspoints2;
        }

        int pluspoints2 = PlayerPrefs.GetInt("PlusScore2");
        if (col.gameObject.tag == "PlusItem2")
        {
			gameManagerScript.score += pluspoints2;
        }

        int minuspoints = PlayerPrefs.GetInt("MinusScore");
        if (col.gameObject.tag == "MinusItem")
        {
			gameManagerScript.score += minuspoints;
        }

        int pluspoints = PlayerPrefs.GetInt("PlusScore");
        if (col.gameObject.tag == "PlusItem")
        {
			gameManagerScript.score += pluspoints;
        }
    }
}

