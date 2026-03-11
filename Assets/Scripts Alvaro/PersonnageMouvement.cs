using UnityEngine;
using UnityEngine.InputSystem;

public class PersonnageMouvement : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float hauteurJump = 8f;
    [SerializeField] float gravite = 20f;
    [SerializeField] GameObject foxBody; //Corps visuel du fox
    [SerializeField] GameObject explosion; //Effet d'explosion activé si l'on meurt
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
            //Augmentation de difficulté, désactive la pomme et joue le son
            speed += 2f;
            collision.gameObject.SetActive(false);
            powerUp.Play();
        }
        else if (collision.gameObject.CompareTag("Barricade"))
        {
            //Désactive corps visuel et les particules
            foxBody.SetActive(false);
            particles.Stop();
            //Active FX explosion
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
        //Si le fox est en vie(si son corps visuel est enabled) on peux bouger
        if (foxBody.activeSelf)
        {
            //mouvement endless
            Vector3 Direction = new Vector3(move.x * speed, verticalVelocity, speed);
            CC.Move(Direction * Time.deltaTime); //Deplacement par frame avec CharacterController


            //Jump
            if (CC.isGrounded && verticalVelocity < 0)
                verticalVelocity = -2f; //Garder le personnage sur le plancher avec une force negative
            else
                verticalVelocity -= gravite * Time.deltaTime;
        }
    }

    //CharacterController source: https://docs.unity3d.com/6000.3/Documentation/ScriptReference/CharacterController.html
}
