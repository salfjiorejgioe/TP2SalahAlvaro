using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public ObjectPool coinPool;
    public ObjectPool obstaclePool;
    public Transform[] spawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            float random = Random.value;

            if (random < 0.5f)
            {
                GameObject coin = coinPool.GetObject();
                coin.transform.position = spawnPoints[i].position;
            }
            else
            {
                GameObject obstacle = obstaclePool.GetObject();
                obstacle.transform.position = spawnPoints[i].position;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
