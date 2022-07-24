using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float torqueRange = 10;
    private float minForce = 10.0f;
    private float maxForce = 14.0f;
    private float xRange = 4.0f;
    private float yPos = -0.5f;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem particle;
   


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        targetRB = GetComponent<Rigidbody>();

        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());

        transform.position = RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(!gameManager.isGameOver)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(particle, transform.position, particle.transform.rotation);
            //particle.Play();
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
            gameManager.GameOver();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    float RandomTorque()
    {
        return Random.Range(-torqueRange, torqueRange);
    }

    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), yPos, 0);
    }

}
