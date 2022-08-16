using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour
{
   //public GameObject Player;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        this.gameObject.transform.position = (new Vector3(0, 0.61f, -6.97f));
        Debug.Log("1");
       // speed = speed * -1;
    }
}
