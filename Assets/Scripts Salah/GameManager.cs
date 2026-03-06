using UnityEngine;

public class GameManager : MonoBehaviour

{
    public ObjectPool coinPool;
    public ObjectPool mapPool;
    public ObjectPool obstaclePool;

    public float distanceDeSpawn = 30f;
    public float prochainePosition = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i =0; i<5; i++)
        {
            SpawnMap();
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnMap()
    {
        GameObject map = mapPool.GetObject();
        map.transform.position = new Vector3(0, 0, prochainePosition);
        prochainePosition += 30f;
    }
}
