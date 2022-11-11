using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public PingPong pingPomg;

	void OnBecameInvisible()
	{
		pingPomg.Reset(transform.position.x);
		//если мяч пропал из поля зрения выполнить функцию Reset() и передать координату x мяча 
	}
}
