using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Velocidad del jugador
    public float moveSpeed;
    //Fuerza de salto del jugador
    public float jumpForce;

    //Variable para saber si el jugador está en el suelo
    private bool _isGrounded;
    //Referencia al punto por debajo del jugador que tomamos para detectar el suelo
    public Transform groundCheckPoint;
    //Referencia para detectar el Layer de suelo
    public LayerMask whatIsGround;
    //Variable para saber si podemos hacer un doble salto
    private bool _canDoubleJump;

    //Variable para la fuerza del KnockBack
    public float knockBackForce;
    //Variables para controlar el contador de tiempo de Knocback
    public float knockBackLength; //Variable que nos sirve para rellenar el contador
    private float _knockBackCounter; //Contador de tiempo


    //El rigidbody del jugador
    //Barrabaja indica que la variable es privada
    private Rigidbody2D _theRB;
    //Referencia al Animator del jugador
    private Animator _anim;
    //Referencia al SpriteRenderer del jugador
    private SpriteRenderer _theSR;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el Rigidbody del jugador
        //GetComponent => Va al objeto donde está metido este código y busca el componente indicado
        _theRB = GetComponent<Rigidbody2D>();
        //Inicializamos el Animator del jugador
        _anim = GetComponent<Animator>();
        //Inicializamos el SpriteRenderer del jugador
        _theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si el contador de KnockBack se ha vaciado, el jugador recupera el control del movimiento
        if(_knockBackCounter <= 0) 
        {
            //El jugador se mueve a una velocidad dada en X, y la velocidad que ya tuviera en Y
            _theRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, _theRB.velocity.y);

            //La variable isGrounded se hará true siempre que el círculo físico que hemos creado detecte suelo, sino será falsa
            //OverlapCircle(punto donde se genera el círculo, radio del círculo, layer a detectar)
            _isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

            //Si pulsamos el botón de salto
            if (Input.GetButtonDown("Jump")) 
            {
                //Si el jugador está en el suelo
                if (_isGrounded) 
                {
                    //El jugador salta, manteniendo su velocidad en X, y aplicamos la fuerza de salto
                    _theRB.velocity = new Vector2(_theRB.velocity.x, jumpForce);
                    //Una vez en el suelo, reactivamos la posibilidad de doble salto
                    _canDoubleJump = true;
                }
                 //Si el jugador no está en el suelo
                else 
                {
                    //Si canDoubleJump es verdadera
                    if (_canDoubleJump) 
                    {
                        //El jugador salta, manteniendo su velocidad en X, y aplicamos la fuerza de salto
                        _theRB.velocity = new Vector2(_theRB.velocity.x, jumpForce);
                        //Hacemos que no se pueda volver a saltar de nuevo
                        _canDoubleJump = false;
                    }
                }
            }

            //Girar el Sprite del Jugador según su dirección de movimiento(velocidad)
            //Si el jugador se mueve hacia la izquierda
            if (_theRB.velocity.x < 0) 
            {
                //No cambiamos la dirección del sprite
                _theSR.flipX = true;
            }
            //Si el jugador se mueve hacia la derecha
            else if (_theRB.velocity.x > 0) 
            {
                //Cambiamos la dirección del sprite
                _theSR.flipX = false;
            }
        }
         //Si por el contrario el contador de KnockBack todavía no está vacío
        else 
        {
            //Hacemos decrecer el contador en 1 cada segundo
            _knockBackCounter -= Time.deltaTime;
            //Si el jugador mira a la izquierda
            if (!_theSR.flipX)
                //Aplicamos un pequeño empuje hacia la derecha
                _theRB.velocity = new Vector2(knockBackForce, _theRB.velocity.y);
            //Si el jugador mira a la derecha
            else
                //Aplicamos un pequeño empuje hacia la izquierda
                _theRB.velocity = new Vector2(-knockBackForce, _theRB.velocity.y);
        }  
    }


    //Método para gestionar el KnockBack producido al jugador al hacerse daño
    public void Knockback()
    {
         //Inicializamos el contador de KnockBack
        _knockBackCounter = knockBackLength;
        //Paralizamos al jugador en X y hacemos que salte en Y
        _theRB.velocity = new Vector2(0f, knockBackForce);
    }

}
