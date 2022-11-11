using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //блоки
    public GameObject[] groups;


    public void spawnNext()
    {
        //выбрать случайный блок
        int i = Random.Range(0, groups.Length);
        //заспавнить случайный блок
        Instantiate(groups[i], transform.position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnNext();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
