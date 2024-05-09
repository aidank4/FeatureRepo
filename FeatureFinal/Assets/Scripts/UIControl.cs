using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Kelly, Aidan
/// 05/08/2024
/// displays UI
/// </summary>

public class UIControl : MonoBehaviour
{
    public Ball ball;
    public TMP_Text scoreText;
    public TMP_Text takenText;

    private void Update()
    {
        scoreText.text = ("Shots Scored: " + ball.score);
        takenText.text = ("Shots Taken: " + ball.shotsTaken);
    }
}
