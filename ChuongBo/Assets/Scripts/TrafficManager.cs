using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour {

    public Vector3 startPos;
    public Vector3 endPos;
    public float traffic = 10;
    private float elapsedTime = 0;
    private GameObject car;
    public float carSpeed = 10;
	// Use this for initialization
	void Start () {
        generateRandomCar();
	}
	
    public void generateRandomCar()
    {
        traffic = Random.Range(10, 20);
        carSpeed = Random.Range(10, 30);
        elapsedTime = 0;
        int carType = Random.Range(1, 12);
        if (car != null)
        {
            DestroyObject(car);
        }
        car = GameObject.Instantiate(Resources.Load("Vehicles\\Car" + carType)) as GameObject;
        car.transform.position = startPos;
    }
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > traffic)
        {
            generateRandomCar();
        }
        else
        {
            if (car != null)
            {
                car.transform.position = Vector3.MoveTowards(car.transform.position, endPos, Time.deltaTime*carSpeed);
            }
        }
	}
}
