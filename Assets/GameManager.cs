using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float timer = 120.0f;
    private float nextActionTime = 0.0f;
    private float timePeriod = 20.0f;
    public TMP_Text timerUI;

    public Player player1;
    public Player player2;
    public GameObject endStatePanel;
    public TMP_Text winnerText;

    //List of Prefabs
    public GameObject SpeedUP;
    public GameObject SpeedDOWN;
    public GameObject DOUBLEMoney;
    public GameObject Confusion;
    public GameObject Object;

    List<GameObject> powerupList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        powerupList.Add(SpeedUP);
        powerupList.Add(SpeedDOWN);
        powerupList.Add(DOUBLEMoney);
        powerupList.Add(Confusion);
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

        //SpawnItems every 20
        if (Time.time > nextActionTime)
        {
            nextActionTime += timePeriod;
            SpawnItems();
        }
    }

    private void SpawnItems()
    {
        for (int i = 0; i < 4; i++)
        {
            int powerupListIndex = Random.Range(0, 4);
            GameObject powerUp = powerupList[powerupListIndex];
            powerUp.transform.position = new Vector3(Random.Range(-13, 13), Random.Range(-5, 5), -1);
            Instantiate(powerUp);
        }

        for (int i = 0; i < 10; i++)
        {
            Object.transform.position = new Vector3(Random.Range(-13, 13), Random.Range(-5, 5), -1);
            Instantiate(Object);
        }
    }
}
