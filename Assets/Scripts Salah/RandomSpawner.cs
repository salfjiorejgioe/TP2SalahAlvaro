using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public ObjectPool coinPool;
    public ObjectPool obstaclePool;
    public int nombreObjets = 5;
    public float largeurRoute = 4f;


    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnRandomObjects()
    {
        for (int i = 0; i < nombreObjets; i++)
        {
            float random = Random.value;

            float x = Random.Range(-largeurRoute, largeurRoute);
            float z = Random.Range(0f, 30f);

            Vector3 position = new Vector3(x, 1f, transform.position.z + z);

            if (random < 0.5f)
            {
                GameObject coin = coinPool.GetObject();
                coin.transform.position = position;
            }
            else
            {
                GameObject obstacle = obstaclePool.GetObject();
                obstacle.transform.position = position;
            }
        }
    }
}

