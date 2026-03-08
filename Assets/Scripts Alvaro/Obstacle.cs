using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Vector3 startPos = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        startPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

}
