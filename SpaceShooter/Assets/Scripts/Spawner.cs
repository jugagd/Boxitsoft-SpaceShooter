using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [Header("Matrix Dimension")]
    public int rows;
    public int columns;
    public float deltaPosition;
    public GameObject stillEnemy;
    public GameObject jumpingEnemy;
    public GameObject shootingEnemy;
    public float speed;
    float stageWidth;
    float stageHeight;
    Vector3 spawnPosition;
    int direction=1;

    
    public void Spawn()
    {
        spawnPosition = transform.position;
        float randomNumber;
        //Spawn all the enemys on a RowsxColumns Matrix
        for (int rowCounter = 0; rowCounter <rows; rowCounter++)
        {
            for (int columnCounter = 0; columnCounter < columns; columnCounter++)
            {
                randomNumber = Random.Range(0, (float)LevelManager.s_Instance.levelNumber);
                Debug.Log(randomNumber);
                if (randomNumber<=1)
                {
                    Instantiate(stillEnemy, spawnPosition, transform.rotation);
                }
                else if (randomNumber<=2)
                {
                    Instantiate(jumpingEnemy, spawnPosition, transform.rotation);
                }
                else
                {
                    Instantiate(shootingEnemy, spawnPosition, transform.rotation);
                }
                
                LevelManager.s_Instance.enemysAlive++;
                spawnPosition.x += deltaPosition;                
            }
            spawnPosition.y -= deltaPosition;
            spawnPosition.x = transform.position.x;
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Limit")
        {
            direction = -direction;
        }

    }
}
