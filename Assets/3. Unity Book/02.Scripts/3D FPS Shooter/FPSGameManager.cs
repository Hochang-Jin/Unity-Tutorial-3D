using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FPSGameManager : Singleton<FPSGameManager>
{
    public enum GameState{READY, RUN, GAMEOVER}

    public GameState gState = GameState.READY;
    public GameObject gameLabel;
    private TextMeshProUGUI gameText;

    private FPSPlayerMove player;

    private void Start()
    {
        gState = GameState.READY;
        gameText = gameLabel.GetComponent<TextMeshProUGUI>();
        gameText.text = "Ready ...";
        gameText.color = new Color32(255, 185, 0, 255);

        StartCoroutine(ReadyToStart());
        player = GameObject.Find("Player").GetComponent<FPSPlayerMove>();
    }

    private void Update()
    {
        if (player.hp <= 0)
        {
            player.GetComponentInChildren<Animator>().SetFloat("MoveMotion",0f);
            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = new Color32(255, 0, 0, 255);
            gState = GameState.GAMEOVER;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f);
        gameText.text = "Go!";
        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false);
        gState = GameState.RUN;
    }
}
