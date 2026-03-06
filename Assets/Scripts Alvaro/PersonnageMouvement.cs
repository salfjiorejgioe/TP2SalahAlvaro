using UnityEngine;
using UnityEngine.InputSystem;

public class PersonnageMouvement : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float hauteurJump = 8f;
    Rigidbody rb;

    Vector2 move = Vector2.zero;


    string CoinTag = "Coin";
    bool isGrounded;
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



    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
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

    //Lire la touche jump, savoir si on est au sol, sauter
    public void InputJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, hauteurJump, rb.linearVelocity.z);
        }
    }

    //mouvement endless
    void Mouvement()
    {
        rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, speed);

    }

}
