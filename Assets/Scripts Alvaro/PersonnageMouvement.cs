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

    //ajouter FX


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




    //Collision avec un coin ou barricade avec un CharacterController
    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            speed += 5f;
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Barricade"))
        {
            gameObject.SetActive(false);
            //FX explode
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

    
    void Mouvement()
    {
        //mouvement endless
        Vector3 Direction = new Vector3(move.x * speed, verticalVelocity, speed);
        CC.Move(Direction * Time.deltaTime); //Mouvement d'un gameObject avec CharacterController

        //Jump
        if (CC.isGrounded && verticalVelocity < 0)
            verticalVelocity = -2f; // Garder le personnage sur le plancher
        else
            verticalVelocity -= gravite * Time.deltaTime; 
    }

}
