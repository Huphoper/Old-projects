using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingPong : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Transform ball;
    public int startBallSpeed = 350;
    public float player1Speed=10;
    public float player2Speed = 10;
    public float playerslimitY = 2.9f;
    public Text player1scoreText;
    public Text player2scoreText;
	public GameObject mainmenuscreen;
    private int player1score;
    private int player2score;
	private int clickcount = 0;
	public GameObject winscreen1;
	public GameObject winscreen2;
	public GameObject pausescreen;
	public GameObject[] randbloks;
	
	public void Gamequit()
	{
		Application.Quit();
		//функция выхода из игры
	}
	void Start()
    {
        Reset(0);
		//поставить всё на свои места при запуске игры
    }

	public void gamerestart()
	{
		//при рестарте обнулить всё и начать заново
		winscreen1.SetActive(false);
		winscreen2.SetActive(false);
		Reset(0);
		player1score = 0;
		player2score = 0;
		player1scoreText.text = player1score.ToString();
		player2scoreText.text = player2score.ToString();
	}
	public void gamecontinue()
	{
		pausescreen.SetActive(false);
		Reset(0);//возобновление игры
	}
	void Update()
	{
		
		if (Input.GetKeyDown(KeyCode.Space) && clickcount == 0)
		{//если был нажат пробел выбросить мяч на игровое поле
			ball.GetComponent<Rigidbody2D>().WakeUp();
			Vector2 direction = new Vector2(1, Random.Range(1.5f, -1.5f));
			if (Random.Range(0, 2) == 1) direction.x *= -1;
			ball.GetComponent<Rigidbody2D>().AddForce(direction * startBallSpeed);
			clickcount++;
			mainmenuscreen.SetActive(false);
		}
		else if (Input.GetMouseButtonDown(1))
		{
			//открытие меню паузы при нажатии пкм
			Reset(0);
			clickcount++;
			pausescreen.SetActive(true);
		}

		if (Input.GetKey(KeyCode.W) && player1.position.y < playerslimitY)
		{
			//двежение игрока1 вверх
			player1.Translate(Vector2.left * player1Speed * Time.deltaTime);
			
		}
		else if (Input.GetKey(KeyCode.S) && player1.position.y > -playerslimitY)
		{
			//двежение игрока1 вниз
			player1.Translate(-Vector2.left * player1Speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.UpArrow) && player2.position.y < playerslimitY)
		{
			//двежение игрока2 вверх
			player2.Translate(-Vector2.left * player2Speed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.DownArrow) && player2.position.y > -playerslimitY)
		{
			//двежение игрока2 вниз
			player2.Translate(Vector2.left * player2Speed * Time.deltaTime);
		}

		if (player1score == 5)
		{
			winscreen1.SetActive(true);
			//если игрок1 набрал 5 очков вывести победный экран
		}
		if (player2score == 5)
		{
			winscreen2.SetActive(true);
			//если игрок2 набрал 5 очков вывести победный экран

		}
		//обновление счета
		player1scoreText.text = player1score.ToString();
		player2scoreText.text = player2score.ToString();
	}

	public void Reset(float x)
	{
		//рестартраунда
		ball.GetComponent<Rigidbody2D>().Sleep();
		player2.position = new Vector2(player2.position.x, 0);
		player1.position = new Vector2(player1.position.x, 0);
		ball.position = new Vector2(0, 0);
		//в зависимости от положения меча добавить поинт одному из игроков
		if (x > 0) player1score++; else if (x < 0) player2score++;
		clickcount = 0;
		for (int k = 1; k <= 9; k++)
		{
			randbloks[k].SetActive(false);
			//обнуление фона
		}
		
		for (int k = 0; k < 4; k++)
		{
			int i = Random.Range(1, 6);
			randbloks[i].SetActive(true);
			//случайные блоки фона
		}
		for (int k = 0; k < 2; k++)
		{
			int j = Random.Range(7, 9);
			randbloks[j].SetActive(true);
			//случайные облака фона
		}
		
	}
}
