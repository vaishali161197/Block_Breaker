﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    GameStatus gameStatus;
    Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
       
       
        Vector2 paddlePos = new Vector2(Mathf.Clamp(GetXPos(), minX, maxX), transform.position.y);

        transform.position = paddlePos;
    }
    private float GetXPos()
    {
        if(gameStatus.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        }
    }
}
