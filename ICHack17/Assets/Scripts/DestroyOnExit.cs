using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExit : MonoBehaviour {


    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //Call to wallHit() in Follower.

        }
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(0.1f);
        print(Time.time);
    }
}
