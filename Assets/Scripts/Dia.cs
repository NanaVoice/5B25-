﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dia : MonoBehaviour
{
    public GameObject dia;
    public GameObject choice;
    public Text diaText;
    bool isEvent;
    bool isChoice;
    public string[] _diaText;
    public int num=0;

    public void GameChoice1()
    {
        isChoice = false;
        num = 4;
    }
    public void GameChoice2()
    {
        isChoice = false;
        num = 5;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isEvent = true;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            isEvent = false;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            isChoice = true;
        }
        else if(Input.GetKeyDown(KeyCode.M))
        {
            isChoice = false;
        }

        if (isEvent == true) dia.SetActive(true);
        else if (isEvent == false) dia.SetActive(false);

        if (isChoice == true) choice.SetActive(true);
        else if(isChoice == false) choice.SetActive(false);
        
        if (Input.GetKeyDown(KeyCode.C)&&isChoice==false) num++;

        if (num == 3)
        {
            isChoice = true;
        }
        else
        {
            isChoice = false;
        }

        diaText.text = _diaText[num];
    }

    /*
    private float alpha = 0.0f;
    private float alphaSpeed = 2.0f;
    private CanvasGroup cg;
    void Start()
    {
        cg = this.transform.GetComponent<CanvasGroup>();
    }
    void Update()
    {
        if (alpha != cg.alpha)
        {
            cg.alpha = Mathf.Lerp(cg.alpha, alpha, alphaSpeed * Time.deltaTime);
            if (Mathf.Abs(alpha - cg.alpha) <= 0.01)
            {
                cg.alpha = alpha;
            }
        }
    }
    public void Show()
    {
        alpha = 1;
        cg.blocksRaycasts = true;//可以和该UI对象交互
    }
    public void Hide()
    {
        alpha = 0;
        cg.blocksRaycasts = false;//不可以和该UI对象交互
    }
    */
}
