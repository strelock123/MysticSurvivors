using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muiten : MonoBehaviour
{
    //tao 3 mui ten ban cho nhan vat
    public float lucban;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody muitenrb = GetComponent<Rigidbody>();
        // tao luc di chuyen cho butllet
        muitenrb.AddForce(transform.forward * lucban, ForceMode.Impulse);
        //Debug.Log(transform.forward);

    }

   private void OnTriggerEnter(Collider other){
    StartCoroutine(cho3());
    Destroy(gameObject);
   }
   IEnumerator cho3(){
    yield return new WaitForSeconds(0.1f);
   }
}
