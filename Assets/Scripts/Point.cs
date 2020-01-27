using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Point : MonoBehaviour
{
    public GameObject playerPoint;
    public Text pointText;
    public Text overText;
    public Text overText2;
    public Text overText3;
    int point;
    int hungry;
    bool isEnding;
    public GameObject[] coin;
    public float Timer=2f;
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
        if (other.gameObject.CompareTag("Coin"))
        {
            Debug.Log(message: other.name);
            point += 10;
            pointText.text ="" + point;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(message: other.name);
            point += 10;
            hungry += 10;
            pointText.text = "" + point;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("ending"))
        {
            pointText.text = "" + point;
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
            pointText.text = "" + point;
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