using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [Header("Matrix Dimension")]
    public int rows;
    public int columns;
    public float deltaPosition;
    public GameObject go;
    public float speed;
    float stageWidth;
    float stageHeight;
    Vector3 spawnPosition;
    int direction=1;
	void Start ()
    {
        spawnPosition = transform.position;
        //Spawn all the enemys on a RowsxColumns Matrix
        for (int rowCounter = 0; rowCounter <rows; rowCounter++)
        {
            for (int columnCounter = 0; columnCounter < columns; columnCounter++)
            {
                Instantiate(go,spawnPosition,transform.rotation);
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
