using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public GameObject startPanel;
    public GameObject inGame;
    public GameObject restartPanel;
    public bool gameStart;
    public bool playerDead;
    public int distance;
    public TextMeshProUGUI aliveForText;
    public TextMeshProUGUI maxDistance;

    public void Start()
    {
        if (PlayerPrefs.GetInt("start") == 1)
        {
            StartGame();
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter)||Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
            PlayerPrefs.SetInt("start", 1);
        }

        if (player.transform.position.y < -6)
        {
            playerDead = true;
            SetDistance(distance);
        }
    }

    private void StartGame()
    {
        if (!gameStart)
        {
            player.SetActive(true);
            inGame.SetActive(true);
            startPanel.SetActive(false);
            gameStart = true;
            StartCoroutine(TimeCounter());
        }
    }

    IEnumerator TimeCounter()
    {
        while (!playerDead)
        {
            yield return new WaitForSeconds(1);
            distance++;
            aliveForText.text = distance + " Sec";
            maxDistance.text = GetDistance().ToString();

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SetDistance(int distance)
    {
        if (GetDistance() <= distance)
        {
            PlayerPrefs.SetInt("distance", distance);
        }
        maxDistance.text = GetDistance().ToString();
        Restart();
    }
    public int GetDistance()
    {
        return PlayerPrefs.GetInt("distance");

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("start", 0);
    }
}
