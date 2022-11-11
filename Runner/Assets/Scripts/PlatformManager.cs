using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platform;
    public int platformAmount;
    List<GameObject> platforms;
    void Start()
    {
        platforms = new List<GameObject>();

        for (int i = 0; i < platformAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(platform);
            obj.SetActive(false);
            platforms.Add(obj);
            //создать платформы
        }
    }

    public GameObject Getplatform()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            if (!platforms[i].activeInHierarchy)
            {
                return platforms[i];
                //получить неактивную платформу
            }

        }
        GameObject obj = (GameObject)Instantiate(platform);
        obj.SetActive(false);
        platforms.Add(obj);
        return obj;
        //создать и получить платформу
    }
}
