using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExit : MonoBehaviour {

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //Destroy(other.gameObject);
            collider.gameObject.SetActive(false);
            Debug.Log("Collision!");
        }
    }
}
