using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [Header("Matrix Dimension")]
    public int rows;
    public int columns;
    public float deltaPosition;
    public GameObject stillEnemy;
    public GameObject stillShootingEnemy;
    public GameObject stillShootingSelectiveEnemy;
    public GameObject jumpingShootingEnemy;
    public GameObject jumpingShootingSelectiveEnemy;
    public float speed;
    float stageWidth;
    float stageHeight;
    Vector3 spawnPosition;
    public int direction=1;
    float probabilityStillEnemy=100f;
    float probabilityStillShootingEnemy=0f;
    float probabilityStillShootingSelectiveEnemy=0f;
    float probabilityjumpingShootingEnemy=0f;
    float probabilityjumpingShootingSelectiveEnemy=0f;
    float curveConstant=0.15f;

   

    public void Spawn()
    {
        spawnPosition = transform.position;
        float randomNumber;
        //Spawn all the enemys on a RowsxColumns Matrix
        for (int rowCounter = 0; rowCounter <rows; rowCounter++)
        {
            for (int columnCounter = 0; columnCounter < columns; columnCounter++)
            {
                randomNumber = Random.Range(0f, 100f);
                
                Debug.Log(probabilityStillEnemy + " " + probabilityStillShootingEnemy);
                Debug.Log(randomNumber);

                if (randomNumber<=probabilityStillEnemy)
                    Instantiate(stillEnemy, spawnPosition, transform.rotation);
                else if (randomNumber<=(probabilityStillEnemy + probabilityStillShootingEnemy))
                    Instantiate(stillShootingEnemy, spawnPosition, transform.rotation);
                else if (randomNumber<=(probabilityStillEnemy + probabilityStillShootingEnemy + probabilityStillShootingSelectiveEnemy))
                    Instantiate(stillShootingSelectiveEnemy, spawnPosition, transform.rotation);
                else if (randomNumber<=(probabilityStillEnemy + probabilityStillShootingEnemy + probabilityStillShootingSelectiveEnemy + probabilityjumpingShootingEnemy))
                    Instantiate(jumpingShootingEnemy, spawnPosition, transform.rotation);
                else if (randomNumber <= (probabilityStillEnemy + probabilityStillShootingEnemy + probabilityStillShootingSelectiveEnemy + probabilityjumpingShootingEnemy + probabilityjumpingShootingSelectiveEnemy))  
                    Instantiate(jumpingShootingSelectiveEnemy, spawnPosition, transform.rotation);

                LevelManager.s_Instance.enemysAlive++;
                spawnPosition.x += deltaPosition;                
            }
            spawnPosition.y -= deltaPosition;
            spawnPosition.x = transform.position.x;
        }
        //progress
        probabilityjumpingShootingSelectiveEnemy = curveConstant * probabilityjumpingShootingEnemy + probabilityjumpingShootingSelectiveEnemy;
        probabilityjumpingShootingEnemy = curveConstant * probabilityStillShootingSelectiveEnemy + probabilityjumpingShootingEnemy * (1 - curveConstant);
        probabilityStillShootingSelectiveEnemy = curveConstant * probabilityStillShootingEnemy + probabilityStillShootingSelectiveEnemy* (1 - curveConstant);
        probabilityStillShootingEnemy = (curveConstant * probabilityStillEnemy) + probabilityStillShootingEnemy * (1 - curveConstant);
        probabilityStillEnemy = (1-curveConstant) * probabilityStillEnemy;

    

    }
    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Limit")
        {
            direction = -direction;
        }

    }
}
