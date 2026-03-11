using UnityEngine;

public class Flottation : MonoBehaviour
{
    [SerializeField] private float vitesseRotation = 50f;
    [SerializeField] private float amplitude = 0.2f;
    [SerializeField] private float frequence = 3f;

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
