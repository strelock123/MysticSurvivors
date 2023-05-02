using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class khoitaoenemy1 : MonoBehaviour
{
    // spawn enemy
    public GameObject enemy1;
    private Vector3 vitri;
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(cho21());
    }

    // Update is called once per frame
    IEnumerator cho21(){
        while (true){
            yield return new WaitForSeconds(5f);
        vitri = transform.position;
        Instantiate(enemy1, vitri, transform.rotation );
        }
    }
}
