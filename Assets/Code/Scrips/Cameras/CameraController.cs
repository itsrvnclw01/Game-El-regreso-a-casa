using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Para obtener la posici�n objetivo de la c�mara
    public Transform target;
    //Variables para posici�n m�nima y m�xima en vertical de la c�mara
    public float minHeight, maxHeight;

    //Referencia a la �ltima posici�n del jugador en X e Y
    private Vector2 _lastPos;


    // Start is called before the first frame update
    void Start()
    {
        //Al empezar el juego la �ltima posici�n del jugador ser� la actual
        //_lastXPos = transform.position.x;
        _lastPos = transform.position;
    }


    void LateUpdate() 
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        Vector2 _amountToMove = new Vector2(transform.position.x - _lastPos.x, transform.position.y - _lastPos.y);


        //Actualizamos la posici�n del jugador
        //_lastXPos = transform.position.x;
        _lastPos = transform.position;

    }
}
