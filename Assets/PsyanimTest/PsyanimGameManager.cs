using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsyanimGameManager : MonoBehaviour
{
    public KillPlayerOnTouch[] killzones;

    public GameObject gameOverUI;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < killzones.Length; ++i)
        {
            killzones[i].PlayerDied += this.EndGame;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndGame()
    {
        _player.SetActive(false);

        for (int i = 0; i < killzones.Length; ++i)
        {
            killzones[i].gameObject.SetActive(false);
        }

        gameOverUI.SetActive(true);
    }
}
