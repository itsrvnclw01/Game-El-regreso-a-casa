using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Para obtener la posición objetivo de la cámara
    public Transform target;
    //Variables para posición mínima y máxima en vertical de la cámara
    public float minHeight, maxHeight;

    //Referencia a la última posición del jugador en X e Y
    private Vector2 _lastPos;


    // Start is called before the first frame update
    void Start()
    {
        //Al empezar el juego la última posición del jugador será la actual
        //_lastXPos = transform.position.x;
        _lastPos = transform.position;
    }


    void LateUpdate() 
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        Vector2 _amountToMove = new Vector2(transform.position.x - _lastPos.x, transform.position.y - _lastPos.y);


        //Actualizamos la posición del jugador
        //_lastXPos = transform.position.x;
        _lastPos = transform.position;

    }
}
