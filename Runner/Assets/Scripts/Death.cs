using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    public GameObject losescreen;
    public Text scoretext;
    public Text finalscore;
    public GameObject pausebut;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //при попадании в зону смерти остановить игрока и вывести экран поражения
        rb = player.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        losescreen.SetActive(true);
        finalscore.text = scoretext.text;
        pausebut.SetActive(false);
        
    }
}
