using UnityEngine;
using UnityEngine.InputSystem;

public class PersonnageMouvement : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float hauteurJump = 8f;
    [SerializeField] float gravite = 20f;
    CharacterController CC;

    Vector2 move = Vector2.zero;

    //verticalVelocity represente la vitesse verticale haut/bas du personnage.
    float verticalVelocity = 0f;

    string CoinTag = "Coin";
    bool isGrounded;
    //Manque ajouter FX


    //pour savoir si notre personnage meurt ou non, je pense que ca nous servira dans la partie spawn de la map
    public bool moving = false;

    void Start()
    {
        CC = GetComponent<CharacterController>();
    }
    void Update()
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

    //Lire la touche jump, savoir si on est au sol, sauter
    public void InputJump(InputAction.CallbackContext context)
    {
        if (CC.isGrounded)
            verticalVelocity = hauteurJump;
    }

    //mouvement endless
    void Mouvement()
    {

        Vector3 Direction = new Vector3(move.x * speed, verticalVelocity, speed);
        CC.Move(Direction * Time.deltaTime);


        //Jump
        if (CC.isGrounded && verticalVelocity < 0)
            verticalVelocity = -2f; // Keeps isGrounded stable
        else
            verticalVelocity -= gravite * Time.deltaTime; 
    }

}
