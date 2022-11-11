using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    Rigidbody2D Rb;
    Collider2D myboxcollider;
    public bool isGround;
    public LayerMask whatIsGround;
    public Text scoretext;
    int score = 0;
    int count = 0;
    public GameObject losescreen;
    public GameObject gamestart;
    public GameObject pause;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        myboxcollider = GetComponent<Collider2D>();
    }

    public void gamestarted()
    {
        Rb.bodyType = RigidbodyType2D.Dynamic;//начать движение
        gamestart.SetActive(false);//скрыть главное меню
    }
    public void pauseandunpause()
    {
        if (count % 2 == 0) {
            Rb.bodyType = RigidbodyType2D.Static;
            pause.SetActive(true);
            count++;
            //поставить игру на паузу
        }
        else
        {
            Rb.bodyType = RigidbodyType2D.Dynamic;
            pause.SetActive(false);
            count++;
            //возобновить игру
        }
    }
    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.IsTouchingLayers(myboxcollider,whatIsGround);//определить местоположение игрока
        Rb.velocity = new Vector2(moveSpeed, Rb.velocity.y);//движение игрока
        score = (int)transform.position.x;//счёт в зависимости от местоположения
        scoretext.text = score.ToString();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGround) { //если была нажата кнопка прыжка и игрок находится на земле совершить прыжок
            Rb.velocity = new Vector2(Rb.velocity.x, jumpForce);
            }
        }
    }
}
