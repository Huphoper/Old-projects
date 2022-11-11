using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    public Transform generationPoint;
    public float distanceBetween;
    public PlatformManager platformM;
    float platformWidth;
    public float distanceMin;
    public float distanceMax;
    public GameObject player;
    Rigidbody2D rb;
    public Text score;
    public GameObject losescreen;
    public GameObject pausebut;
    void Start()
    {  
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;//запомнить размер платформ
    }
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {   
            distanceBetween = Random.Range(distanceMin, distanceMax); //выбрать дистанцию между платформами
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);         
            GameObject newplatform =  platformM.Getplatform();//получить платформу
            newplatform.transform.position = transform.position;
            newplatform.transform.rotation = transform.rotation;
            newplatform.SetActive(true);//отобразить и расположить платформу
        }
    }
    public void gamerestart()//перезапуск
    {   
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Blocks");
        for (int i = 0; i < platforms.Length; i++)
        {   
            platforms[i].SetActive(false);//скрыть не использующиеся платформы
        }
        transform.position = new Vector3(0, -2.76f,10);
        player.transform.position = new Vector3(0, -1, 0); //переместить игрока на стартовую позицию
        GameObject newplatform = platformM.Getplatform(); //получить платформу
        newplatform.transform.position = transform.position;
        newplatform.transform.rotation = transform.rotation;
        newplatform.SetActive(true);//отобразить и расположить платформу
        rb = player.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;//начать движение
        score.text = "0";//обнулить счёт
        losescreen.SetActive(false);//убрать экран поражения
        pausebut.SetActive(true);//отобразить кнопку паузы
    }
    public void gamequit()
    {
        Application.Quit();//выйти из игры
    }
}
