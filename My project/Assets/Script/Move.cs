using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{

    public GameObject Player;
   public float speed = 20f;
    public float Backspeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Right()
    {

        Debug.Log("111");
        //Player.transform.position += Vector3.right * speed * Time.deltaTime;
        Player.transform.Translate(Vector3.right * .5f);
    }

    public void Left()
    {

        Player.transform.Translate(Vector3.right * -.5f);
        // Player.transform.position += Vector3.left * speed * Time.deltaTime;
    }


    public void Jump()
    {


        //  Player.transform.position += Vector3.up * speed * Time.deltaTime;
        Player.transform.Translate(Vector3.up *  1);
        StartCoroutine(Ground());
    }



    public IEnumerator Ground()
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.Translate(Vector3.up * -1);
        //  Player.transform.Translate(Vector3.down * Time.deltaTime);
        // Player.transform.position += Vector3.down * Backspeed * Time.deltaTime;
        // Player.transform.position = (new Vector3(0,0.61f,-6.97f));


    }


  
}
