using UnityEngine;
using UnityEngine.InputSystem;

public class PersonnageMouvement : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float hauteurJump = 8f;
    [SerializeField] float gravite = 20f;
    [SerializeField] GameObject foxBody;
    [SerializeField] GameObject explosion;
    CharacterController CC;
    Vector2 move = Vector2.zero;

    //verticalVelocity represente la vitesse verticale haut/bas du personnage.
    float verticalVelocity = 0f;

    //FX
    AudioSource powerUp;
    ParticleSystem particles;

    void Start()
    {
        CC = GetComponent<CharacterController>();
        powerUp = GetComponent<AudioSource>();
        particles = GetComponent<ParticleSystem>();
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
            speed += 2f;
            collision.gameObject.SetActive(false);
            powerUp.Play();
        }
        else if (collision.gameObject.CompareTag("Barricade"))
        {
            foxBody.SetActive(false);
            particles.Stop();
            //FX explode
            explosion.SetActive(true);
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
        //Si le fox est en vie(si son corps est enabled) on peux bouger
        if (foxBody.activeSelf)
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

}
