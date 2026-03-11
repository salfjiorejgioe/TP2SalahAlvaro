using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;

    public ObjectPool coinPool;
    public ObjectPool mapPool;
    public ObjectPool obstaclePool;

    public float distanceDeSpawn = 30f;
    public float prochainePosition = 0f;

    bool spawnEnCours = false; // pour empecher de spawners plsuieurs fois

    void Start()
    {
        // Au début on génère 10 bouts
        for (int i = 0; i < 10; i++)
        {
            SpawnMap();
        }
    }

    void Update()
    {
        if (player.position.z > prochainePosition - distanceDeSpawn && spawnEnCours == false)  // on vérifie si le joueur approche de la fin 
        {
            spawnEnCours = true; // on s'assure de ne pas parcourir le boucle for plus qu'une fois

            // on ajoute 10 bouts
            for (int i = 0; i < 10; i++)
            {
                SpawnMap();
            }

            spawnEnCours = false;
        }
    }

    void SpawnMap()
    {
        GameObject map = mapPool.GetObject(); // on prend le bout du map du pool

        map.transform.position = new Vector3(0, 0, prochainePosition); // on prépare la position du map

        RandomSpawner spawner = map.GetComponent<RandomSpawner>(); // le script randomspawner

        if (spawner != null)
        {
            spawner.coinPool = coinPool; // on lui assigne l'objectpool dans l'hierarchie qui contient le prefab des coins
            spawner.obstaclePool = obstaclePool; // on lui donne l'objectpool dans l'hierarchie qui contient le prefab des obstacles
            spawner.SpawnRandomObjects(); // génére aléatoirement des obstacles ou des coins sur le nouveau morceau
        }

        prochainePosition += 30f;
    }
}