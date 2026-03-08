using UnityEngine;

public class Monnaie : MonoBehaviour
{
    [SerializeField] private float vitesseRotation = 50f;
    [SerializeField] private float amplitude = 0.2f;
    [SerializeField] private float frequence = 3f;

    [SerializeField] GameObject player;
    public Vector3 startPos = Vector3.zero;

    private void OnEnable()
    {
        //Mettre sur une position de la nouvelle map spawnée
        startPos = transform.localPosition;
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
            transform.localPosition = startPos + new Vector3(0, yOffset, 0);
        }
    }
}
