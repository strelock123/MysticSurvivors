using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khoitaoenemy3 : MonoBehaviour
{
    // khoi tao ke thu
    public GameObject enemy3;
    private Vector3 vitri;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(cho22());      
    }
    IEnumerator cho22(){
        while (true){
            yield return new WaitForSeconds(13f);
            vitri = transform.position;
            Instantiate(enemy3, vitri, transform.rotation);
        }
    }
}
