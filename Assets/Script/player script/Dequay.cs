using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dequay : MonoBehaviour
{
   // public float tocdoquaychuot;
    public float domuot;
    private float hitdist;

    // Update is called once per frame
    void Update()
    {
        xoaytheochuot();
        transform.position = Player.Playersingleton.transform.position;
    }
    void xoaytheochuot(){
                Plane deplane = new Plane(Vector3.up, transform.position);
        //Debug.Log(deplane);
       // Debug.Log(transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(ray);
        if(deplane.Raycast(ray,out hitdist)){
            //Debug.Log(hitdist);
            Vector3 diemdich =ray.GetPoint(hitdist);
            //Debug.Log(diemdich);
            Quaternion dichxoay = Quaternion.LookRotation(diemdich-transform.position);
            //Debug.Log(dichxoay);
            transform.rotation = Quaternion.Slerp(transform.rotation, dichxoay,domuot * Time.deltaTime);
           //Quaternion vectordich = Quaternion.LookRotation(diemdich - transform.position, Vector3.up);
           //transform.rotation = Quaternion.RotateTowards(transform.rotation, vectordich , domuot * Time.deltaTime);
        } 
    }

}
