using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Point : MonoBehaviour
{
    public GameObject playerPoint;
    public GameObject player;
    public Text pointText;
    public Text overText;
    public Text overText2;
    public Text overText3;
    int hungry=50;
    public int hp = 100;
    bool isEnding;
    //bool isCover=false;
    public GameObject[] coin;
    public float Timer = 2f;
    public float coverTimer = 5f;
    void FixedUpdate()
    {
        Timer -= Time.deltaTime;
        Vector3 v = playerPoint.transform.localPosition;
        int i = Random.Range(0, 5);
        if (Timer <= 0)
        {
            GameObject newCoin = Instantiate(coin[i], new Vector3((int)v.x + 20, 0, 10), Quaternion.identity) as GameObject;
            Timer = 2f;
        }
        /*
        if (isCover == true)
        {
            player.SetActive(true);
            coverTimer -= Time.deltaTime;
            if (coverTimer < 5f && coverTimer > 4f)
            {
                player.SetActive(false);
            }
            if (coverTimer <= 4f && coverTimer > 3f)
            {
                player.SetActive(true);
            }
            if (coverTimer <= 3f && coverTimer > 2f)
            {
                player.SetActive(false);
            }
            if (coverTimer <= 2f && coverTimer > 1f)
            {
                player.SetActive(true);
            }
            if (coverTimer <= 1f && coverTimer > 0f)
            {
                player.SetActive(false);
            }
            if (coverTimer <= 0)
            {
                Debug.Log(string.Format("Timer1 is up !!! time=${0}", Time.time));
                isCover = false;
                coverTimer = 5.0f;
            }
            
        }
*/
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) &&isEnding==true)
        {
            SceneManager.LoadScene("Title");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Debug.Log(message: other.name);
            hp += 10;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy")) //&& isCover == false)
        {
            Debug.Log(message: other.name);
            hp -= 10;
            Destroy(other.gameObject);
            //isCover = true;
        }
        if (other.gameObject.CompareTag("Enemy2"))// && isCover == false)
        {
            Debug.Log(message: other.name);
            hp -= 2;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Floor"))
        {
            Debug.Log(message: other.name);
            hp -= 10;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("ending"))
        {
            Destroy(other.gameObject);
            overText.text = "Game Over";
            overText2.text = "あなたのポイントは" + pointText.text;
            overText3.text = "Press X to Title";
            isEnding = true;
            if (isEnding == true)
            {
                Time.timeScale = 0;
            }
        }
        if (other.gameObject.CompareTag("Over"))
        {
            overText.text = "Game Over";
            overText2.text = "あなたのポイントは" + pointText.text;
            overText3.text = "Press X to Title";
            isEnding = true;
            if (isEnding == true)
            {
                Time.timeScale = 0;
            }
        }

    }


}