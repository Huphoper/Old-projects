using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Group : MonoBehaviour
{
    int fullscore=0;
    bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            //просмотр каждого дочернего элемента с помощью foreach , 
            //затем сохранение округленной позиции дочернего элемента в переменной. 
            //После этого проверка находится ли эта позиция внутри границы, а затем проверка есть ли уже блок в той же записи сетки или нет.

            Vector2 v = Playfield.roundVec2(child.position);            
            if (!Playfield.insideBorder(v))
                return false;
             if (Playfield.grid[(int)v.x, (int)v.y] != null && Playfield.grid[(int)v.x, (int)v.y].parent != transform)
                return false;
        }
        return true;
    }
    void updateGrid()
    {
        //Если родительский блок равен преобразованию текущей группы, то это дочерний элемент этой группы. 
        //После этого снова перебираем всех потомков, чтобы добавить их в таблицу. 
        for (int y = 0; y < Playfield.h; ++y)
            for (int x = 0; x < Playfield.w; ++x)
                if (Playfield.grid[x, y] != null)
                    if (Playfield.grid[x, y].parent == transform)
                        Playfield.grid[x, y] = null;

        foreach (Transform child in transform)
        {
            Vector2 v = Playfield.roundVec2(child.position);
            Playfield.grid[(int)v.x, (int)v.y] = child;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        if (!isValidGridPos())
        {           
            //экран поражения 
            Destroy(gameObject);
            GameObject bultext = GameObject.FindWithTag("bul");
            bultext.GetComponent<Text>().text = "2";
            GameObject scoretext = GameObject.FindWithTag("scoretxt");
            GameObject finalscore = GameObject.FindWithTag("finalscore");
            finalscore.GetComponent<Text>().text = scoretext.GetComponent<Text>().text;
            Color red = new Color(255, 0, 0,255f);
            finalscore.GetComponent<Text>().color = red;
            }
            }
    float lastFall = 0;
    int score = 0;
    // Update is called once per frame
    void Update()
    {
        //движение блока влево 
        GameObject bultext = GameObject.FindWithTag("bul");
        if (Input.GetKeyDown(KeyCode.LeftArrow) && (int.Parse(bultext.GetComponent<Text>().text))==0)
        {
            transform.position += new Vector3(-1, 0, 0);
            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(1, 0, 0);
        }
        //движение блока вправо 
        else if (Input.GetKeyDown(KeyCode.RightArrow) && (int.Parse(bultext.GetComponent<Text>().text)) == 0)
        {
            transform.position += new Vector3(1, 0, 0);

            if (isValidGridPos())
                updateGrid();
            else
                transform.position += new Vector3(-1, 0, 0);
        }
        //поворот блока
        else if (Input.GetKeyDown(KeyCode.UpArrow) && (int.Parse(bultext.GetComponent<Text>().text)) == 0)
        {
            transform.Rotate(0, 0, -90);
            if (isValidGridPos())
                updateGrid();

            else
                transform.Rotate(0, 0, 90);
        }

        
        //падение блока + ускоренное падение блока при нажатии стрелочки вниз
        else if ((Input.GetKey(KeyCode.DownArrow) || Time.time - lastFall >= 1) && (int.Parse(bultext.GetComponent<Text>().text)) == 0)
        {
            transform.position += new Vector3(0, -1, 0);

            if (isValidGridPos())
            {
                updateGrid();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);
                
                
                score=Playfield.deleteFullRows();
                if (score > 0) {
                    
                    
                    GameObject scoretext = GameObject.FindWithTag("scoretxt");
                    fullscore = int.Parse(scoretext.GetComponent<Text>().text);
                    fullscore += score;
                    
                    scoretext.GetComponent<Text>().text = fullscore.ToString();
                }

                FindObjectOfType<Spawner>().spawnNext();

                enabled = false;
            }

            lastFall = Time.time;

        }

    }
}

