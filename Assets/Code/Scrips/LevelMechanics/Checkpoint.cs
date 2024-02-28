using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //Referencias a los sprites que se ir�n alternando al activar o desactivar los checkpoints
    public Sprite cpOn, cpOff;

    //Referencia al SpriteRenderer del Checkpoint
    private SpriteRenderer _sR;
    //Referencia al CheckpointController
    private CheckpointController _cReference;


    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la referencia al SpriteRenderer
        _sR = GetComponent<SpriteRenderer>();
        //Inicializamos la referencia al CheckpointController
        //_cReference = GameObject.Find("CheckpointController").GetComponent<CheckpointController>();
        //Esta forma es m�s eficiente porque no recorre todos los objetos de la escena, busca al padre directamente
        _cReference = transform.parent.GetComponent<CheckpointController>();
    }

    //M�todo para conocer cuando el jugador entra en la zona de checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el que entra es el jugador
        if (collision.CompareTag("Player")) 
        {
            //Desactivamos primero todos los checkpoints
            //_cReference.DeactivateCheckpoints();
            //Cambiamos el sprite a Checkpoint activo
            _sR.sprite = cpOn;
            //Guardamos la posici�n de este Checkpoint para hacer el Spawn
            //_cReference.SetSpawnPoint(transform.position);
        }
    }


    //M�todo para desactivar este Checkpoint concreto
    public void ResetCheckpoint() 
    {

    }
}
