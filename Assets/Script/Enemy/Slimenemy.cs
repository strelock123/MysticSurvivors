using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slimenemy : MonoBehaviour
{
    private NavMeshAgent navmes3;
    private Animator anim2;
    private int enemyhealth3 = 3;
    private SkinnedMeshRenderer hethongmau;
    public GameObject thanslim;
    private Material maunhap;
    public Material maudo;
    // Start is called before the first frame update
    void Awake()
    {
        navmes3 =  GetComponent<NavMeshAgent>();
        anim2 = GetComponent<Animator>();   
    }
    // kiem tra xem co dinh dan khong de chuyen tang thai
    private void OnTriggerEnter(Collider muiten2){
        if(muiten2.CompareTag("MUITEN")){
            enemyhealth3--;
            hethongmau = thanslim.GetComponent<SkinnedMeshRenderer>();
            maunhap = hethongmau.material;
            hethongmau.material = maudo;
            if(enemyhealth3 == 0){
                anim2.SetBool("diee", true);
                Debug.Log("da chuyen dc trang thai slim");
                //chuyen trang thai khong theo nhan vat nua
                gameObject.GetComponent<NavMeshAgent>().enabled =false;
                StartCoroutine(cho7());            
            }
            else StartCoroutine(cho6());
        }
    }

    // Update is called once per frame
    void Update()
    {
        navmes3.destination = Player.Playersingleton.transform.position;
    }
    IEnumerator cho6(){
        yield return new WaitForSeconds(0.25f);
        hethongmau.material =maunhap;
    }
    IEnumerator cho7(){
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        //Debug.Log("cho du 2 giay");
        

    }
}
