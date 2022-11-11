using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_and_menu : MonoBehaviour
{
    
    public Text bul;
    public GameObject game;
    public GameObject startscreen;
    public GameObject pause;
    public GameObject minipause;
    public GameObject replayscreen;
    int count = 0;
    public void startpause()
    {
        if (count % 2 == 0)
        {
            //пауза игры
            bul.text = "1";
            pause.SetActive(true);
            minipause.SetActive(false);
        }
        else
        {
            //возобновление игры
            bul.text = "0";
            pause.SetActive(false);
            minipause.SetActive(true);
        }
        count++;
    }
   public void gamerestart()
    {
        for (int y = 0; y < Playfield.h; ++y)
            for (int x = 0; x < Playfield.w; ++x)
                Playfield.grid[x, y] = null;
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Groups");
        for (int i = 0; i < blocks.Length; i++)
        {
            Destroy(blocks[i]);
        }
        FindObjectOfType<Spawner>().spawnNext();
        replayscreen.SetActive(false);
        bul.text = "0";

        GameObject finalscore = GameObject.FindWithTag("finalscore");
        Color red = new Color(255, 0, 0, 0f);
        finalscore.GetComponent<Text>().color = red;
        GameObject scoretext = GameObject.FindWithTag("scoretxt");
        scoretext.GetComponent<Text>().text = "0";
        pause.SetActive(false);
        minipause.SetActive(true);

    }
    public void closemenu()
    {
        game.SetActive(true);
        startscreen.SetActive(false);
        
    }

    public void gamequit()
    {
        //выход из игры
        Application.Quit();
    }
  

    // Update is called once per frame
    void Update()
    {
        //если проиграл вывести экран поражения
        if (bul.text == "2")
        {
            replayscreen.SetActive(true);
        }
    }
}
