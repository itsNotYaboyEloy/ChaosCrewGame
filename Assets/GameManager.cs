using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float timer = 10.0f;
    public TMP_Text timerUI;

    public Player player1;
    public Player player2;
    public GameObject endStatePanel;
    public TMP_Text winnerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerUI.text = ((int) timer).ToString();

        if (timer < 0)
        {
            endStatePanel.SetActive(true);
            Time.timeScale = 0;

            if (this.player1.score == this.player2.score)
            {
                winnerText.text = "Draw";
            }
            else if (this.player1.score > this.player2.score)
            {
                winnerText.text = "Player 1 Wins";
            }
            else
            {
                winnerText.text = "Player 2 Wins";
            }
        }
    }
}
