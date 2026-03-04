using UnityEngine;
using UnityEngine.InputSystem;

public class PersonnageMouvement : MonoBehaviour
{
    [SerializeField] float speed = 20f;

    Rigidbody rb;

    Vector2 move = Vector2.zero;

    string CoinTag = "Coin";

    //Manque ajouter FX


    //pour savoir si notre personnage meurt ou non, je pense que ca nous servira dans la partie spawn de la map
    public bool moving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Mouvement();
    }


    //Collision avec un coin
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(CoinTag))
        {
            speed += 5f;
            collision.gameObject.SetActive(false);
        }
    }

    //Lire la touche gauche et droite
    public void InputMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }



    //mouvement endless
    void Mouvement()
    {
        rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, speed);

    }
}
