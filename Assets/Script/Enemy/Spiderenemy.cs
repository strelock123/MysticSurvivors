using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spiderenemy : MonoBehaviour
{
    private NavMeshAgent navmesh2;
    private int enemyhealth2 = 5;
    private SkinnedMeshRenderer hethongmau;
    public GameObject thannhen;
    private Material maunhap;
    public Material mautrang;
    private Animator anim1;

    // Start is called before the first frame update
    private void Awake(){
        navmesh2 = GetComponent<NavMeshAgent>();
        anim1 = GetComponent<Animator>();        
    }
    //kiem tra xem co dinh dan khong de bat hieu ung
    private void OnTriggerEnter(Collider muiten1){
        if (muiten1.CompareTag("MUITEN")){
            enemyhealth2--;
            hethongmau = thannhen.GetComponent<SkinnedMeshRenderer>();
            maunhap = hethongmau.material;
            hethongmau.material = mautrang;
            if(enemyhealth2 == 0){
                anim1.SetBool("endhealth", true);
                // chuyen trang thai die va dung theo duoi nhan vat
                //navmesh2.destination = transform.position;
              gameObject.GetComponent<NavMeshAgent>().enabled = false;
              //gameObject.GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
                StartCoroutine(cho4());
            }
           else StartCoroutine(cho3());
        }
    }
    private void OnCollisionEnter(Collision player){
        if(player.gameObject == Player.Playersingleton){
            anim1.SetBool("Attack", true);
            Debug.Log("da bat attack");
            StartCoroutine(cho5());
        }
    }

    // Update is called once per frame
    void Update()
    {          
           navmesh2.destination = Player.Playersingleton.transform.position;
    }
    IEnumerator cho3(){
        yield return new WaitForSeconds(0.25f);
        hethongmau.material = maunhap;
    }
        IEnumerator cho4(){
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }   
    IEnumerator cho5(){
        yield return new WaitForSeconds(0.7f);
        anim1.SetBool("Attack", false);
        //Debug.Log("da tat attack");
    }

}
