using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BurrowEnemy : MonoBehaviour
{
    private NavMeshAgent navmes1;
    public Material mautrang;
    private Material maunhap;
    private SkinnedMeshRenderer hethongmau;
    public GameObject thanthe;
    private float enemyhealth1 =3;
    private void Awake(){
        navmes1 =GetComponent<NavMeshAgent>();       
    }

    // kiem tra xem co dinh dan khong va bat hieu ung
    private void OnTriggerEnter(Collider muiten1){
        if(muiten1.CompareTag("MUITEN")){
           hethongmau = thanthe.GetComponent<SkinnedMeshRenderer>();
           maunhap = hethongmau.material;
           hethongmau.material =mautrang;
           enemyhealth1--;
          // Debug.Log(hethongmau.material);
          // Debug.Log("da doi mau");
           StartCoroutine(cho2());
        }
    }

    // Update is called once per frame
    void Update()
    {     
        // cho duoi tho nhan vat
        navmes1.destination = Player.Playersingleton.transform.position;
    }
    IEnumerator cho2(){
        yield return new WaitForSeconds(0.25f);
        hethongmau.material = maunhap;
          if(enemyhealth1 <= 0){
            Destroy(gameObject);
           }
    }
}
