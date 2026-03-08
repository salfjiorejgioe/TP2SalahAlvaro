using UnityEngine;

public class Monnaie : MonoBehaviour
{
    [SerializeField] private float vitesseRotation = 50f;
    [SerializeField] private float amplitude = 0.2f;
    [SerializeField] private float frequence = 3f;

    [SerializeField] GameObject player;
 

    

    private void OnCollisionEnter(Collision collision)
    {
        //detecter le joueur, augmenter son speed
        if (collision.gameObject.Equals(player))
        {
            collision.gameObject.GetComponent<PersonnageMouvement>().moving = false;
            collision.gameObject.GetComponent<PersonnageMouvement>().enabled = false;
            //FX explode
        }
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Flotter();
    }

    void Flotter()
    {
        //si la monnaie spawn, elle flotte
        if (gameObject.activeSelf)
        {
            //tourner
            transform.Rotate(Vector3.up, vitesseRotation * Time.deltaTime);

            //flotter
            float yOffset = Mathf.Sin(Time.time * frequence) * amplitude;
            transform.localPosition = transform.position + new Vector3(0, yOffset, 0);
        }
    }
}
