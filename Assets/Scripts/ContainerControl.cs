using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerControl : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public float xMinPositionToCreate;
    public float xMaxPositionToCreate;
    public float yPositionToCreate;
    public float timeToCreateEnemy1;
    public float timeToCreateEnemy2;
    public float initialDelay;

    void Start()
    {
        Invoke("StartCreation", initialDelay);
    }

    private void StartCreation()
    {
        CreateEnemy1();
        CreateEnemy2();
    }

    public void CreateEnemy1()
    {
        Vector2 positionToCreate = GetEmptyPosition();
        float rotationAngle = Random.Range(0, 360);
        Quaternion randomRotation = Quaternion.Euler(0, 0, rotationAngle);
        Instantiate(enemyPrefab1, positionToCreate, randomRotation);
        Invoke("CreateEnemy1", timeToCreateEnemy1);
    }

    public void CreateEnemy2()
    {
        Vector2 positionToCreate = GetEmptyPosition();
        Instantiate(enemyPrefab2, positionToCreate, transform.rotation);
        Invoke("CreateEnemy2", timeToCreateEnemy2);
    }

    private Vector2 GetEmptyPosition()
    {
        Vector2 positionToCreate;
        bool positionOccupied;
        int attempts = 1000;
        do
        {
            float xPosition = Random.Range(xMinPositionToCreate, xMaxPositionToCreate);
            positionToCreate = new Vector2(xPosition, yPositionToCreate);
            positionOccupied = Physics2D.OverlapCircle(positionToCreate, 0.5f);
            attempts--;
        } while (positionOccupied && attempts > 0);
        return positionToCreate;
    }
}