using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khoitaoenemy2 : MonoBehaviour
{
    // khoi tao ke thu
    public GameObject enemy2;
    private Vector3 vitri;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cho20());    
    }

    IEnumerator cho20(){
        while (true){
            yield return new WaitForSeconds(15f);
        vitri = transform.position;
        Instantiate(enemy2, vitri, transform.rotation);
        }
       
    }
}
