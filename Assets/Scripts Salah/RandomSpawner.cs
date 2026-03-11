using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public ObjectPool coinPool;  // l'object pool des coins (fruits)
    public ObjectPool obstaclePool;  // l'object pool des troncs d'arbres
    public int nombreObjets = 5;  // combien on en veut
    public float largeurRoute = 4f;  // la largeur pour ne pas dépasser 


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
            float random = Random.Range(0, 100);      

            float x = Random.Range(-largeurRoute, largeurRoute);  // une position entre -4 et 4 s'assurer que la position est entre les bornes de la route
            float z = Random.Range(0f, 30f); // une position entre 0 et 30 (la longeur de map)   s'assurer que ca spawn devant le joueur

            Vector3 position = new Vector3(x, 0.1f, transform.position.z + z); // 0.1 pour éviter qu'il spawn dessous le map  le +z pour s'assurer que l'objet spawn dans le nouvueau morceau du map

            if (random < 50) 
            {
                GameObject coin = coinPool.GetObject();  // si il est plus petit que 50 on génére un coin
                coin.transform.position = position;
            }
            else
            {
                GameObject obstacle = obstaclePool.GetObject(); //sinon on génére un obstacle
                obstacle.transform.position = position;
            }
        }
    }
}

