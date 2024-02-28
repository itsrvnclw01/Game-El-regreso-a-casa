using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para poder trabajar con elementos de la UI

public class UIController : MonoBehaviour
{
    //Referencia a las im�genes de los corazones de la UI
    public Image heart1, heart2, heart3;
    //Referencias a los sprites que cambiar�n al perder o ganar un coraz�n
    public Sprite heartFull, heartEmpty;

    //Referencia al Script que controla la vida del jugador
    private PlayerHealthController _pHReference;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos la referencia al PlayerHealthController
        //Con GameObject.Find buscamos el objeto jugador en la escena
        //Con GetComponent obtenemos el c�digo que necesitamos (el componente) del objeto jugador
        _pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
    }

    private void Update()
    {
        UpdateHealthDisplay();

    }

    //M�todo para actualizar la vida en la UI
    public void UpdateHealthDisplay() 
    {
        //Dependiendo del valor de la vida actual del jugador
        switch (_pHReference.currentHealth) 
        {
            //En el caso en el que la vida actual valga 3
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                //Cerramos el caso y salimos del Switch
                break;
            //En el caso en el que la vida actual valga 2
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                //Cerramos el caso y salimos del Switch
                break;
            //En el caso en el que la vida actual valga 1
            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                //Cerramos el caso y salimos del Switch
                break;
            //En el caso en el que la vida actual valga 0
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                //Cerramos el caso y salimos del Switch
                break;
            //En el caso por defecto, el jugador estar� muerto
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                //Cerramos el caso y salimos del Switch
                break;
        }
    }

}
