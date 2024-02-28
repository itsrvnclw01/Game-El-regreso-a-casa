using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public PlayerHealthController _pHReference;
    private UIController _uIReference;

    private void Start()
    {
        _pHReference = GameObject.Find("Player").GetComponent<PlayerHealthController>();
    }


    private void nTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            _pHReference.currentHealth = 0;
        }
    }
}
