using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
     GameObject destroyPoint;
    // Start is called before the first frame update
    void Start()
    {
        destroyPoint = GameObject.Find("DestroyPoint");
        //найти точку уничтожения платформ
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < destroyPoint.transform.position.x)
        {
            gameObject.SetActive(false);
            //скрыть платформу за границей камеры
        
        }
    }
}
