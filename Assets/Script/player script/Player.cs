using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Playersingleton {get; private set;}
    private float lucdiphai;
    private float lucditrai;
    public int lucdingang;
    private int i;
    private Rigidbody rbl;
    public Camera camera1;
    public float tocdoquay;
    public GameObject chande;
    private Animator anim;
    private Vector3 vectorxoay;
    private float hitdist1;
    private bool playerattack ;
    private bool playermana;
    public Transform vitriban;
    public GameObject danban;
    private Vector3 vitrigioihan;
    private float playerhealth;
    private float playermaxhealth = 5;
    private SkinnedMeshRenderer hethongmau;
    private Material maunhap;
    public Material maudo;
    public GameObject skin;
    public Canvas gameover;
    public GameObject khoitaoenemy;
   [SerializeField] private healthbar healthbarscript;
    // Start is called before the first frame update
    private void Awake(){
        Playersingleton = this;
    }
    void Start()
    {
        rbl = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerattack = false;
        playermana = true;
        playerhealth = playermaxhealth;
        healthbarscript.updathealthbar(playermaxhealth, playerhealth);
    }

    // Kiem tra xem neu va cham thi tru mau, doi mau, chinh thanh mau
    private void OnCollisionEnter(Collision kethu){
        if(kethu.gameObject.CompareTag("ENEMY")){
            playerhealth--;
            healthbarscript.updathealthbar(playermaxhealth, playerhealth);
            Debug.Log(playerhealth/playermaxhealth);
            hethongmau = skin.GetComponent<SkinnedMeshRenderer>();
            maunhap = hethongmau.material;
            hethongmau.material = maudo;
            if(playerhealth <= 0){
                StartCoroutine(chobaoketthuc());
            }
            else StartCoroutine(chodoimau());
        }
    }
    void Update()
    {      
        lucditrai = Input.GetAxisRaw("Vertical");
        lucdiphai = Input.GetAxisRaw("Horizontal");
        Vector3 vectordichuyen = new Vector3( -lucdiphai, 0, -lucditrai);
       // Debug.Log(vectordichuyen);
        vectordichuyen.Normalize();
       // Debug.Log(vectordichuyen);
       //gioi han bien gioi di chuyen cua player
       vitrigioihan = transform.position;
       if (vitrigioihan.x < 20){
        vitrigioihan.x =20;
       }
       else if (vitrigioihan.x >180){
        vitrigioihan.x = 180;
       }
       if (vitrigioihan.z < 20){
        vitrigioihan.z =20;
       }
       else if(vitrigioihan.z > 180){
        vitrigioihan.z =180;
       }
       transform.position = vitrigioihan;

        // kiem tra xem co di chuyen khong de chuyen animation
        
        if ((vectordichuyen != Vector3.zero) &&  !playerattack){
            anim.SetBool("Idletorun",true); 
            // di chuyen
            rbl.position += new Vector3(lucdiphai, 0, lucditrai) * Time.deltaTime * lucdingang ;
           //dieu khien camera theo nhan vat chinh
           camera1.transform.position = new Vector3(transform.position.x, transform.position.y + 18f, transform.position.z + 18f);
           // chinh nhan vat quay theo huong chay
           Quaternion huongdichuyen = Quaternion.LookRotation(vectordichuyen, Vector3.up);
           // Debug.Log(huongdichuyen);
           transform.rotation = Quaternion.RotateTowards(transform.rotation, huongdichuyen, tocdoquay * Time.deltaTime);
           // chuyen animation run                       
         }
        else {
                anim.SetBool("Idletorun", false);
             }
    
      // kiem tra xem co attack va du mana de attack khong
       if (Input.GetKeyDown(KeyCode.Mouse0) && playermana) {
       anim.SetBool("Attack", true);
       //xoay player theo huong chan de
       transform.rotation = chande.transform.rotation;
       //tao dan ban vat bat sound 
       Instantiate(danban, vitriban.position, vitriban.rotation);
       var attacksound = GetComponent<AudioSource>();
       attacksound.Play();
       playerattack = true;
       playermana =false;
       StartCoroutine( cho());
       // playerattack = true;
       StartCoroutine(cho1());
      }
    }
        IEnumerator cho(){
        yield return new WaitForSeconds(0.13f); 
        playerattack = false;
        anim.SetBool("Attack", false);

        }
        IEnumerator cho1(){
          yield return new WaitForSeconds(0.5f);
          playermana = true;
        }
        //hien bang ket thuc game va tat spawmn ke thu
        IEnumerator chobaoketthuc(){
            yield return new WaitForSeconds(0.5f);
            Debug.Log("end game");
            gameover.transform.position = new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z + 8f);
            gameover.transform.rotation = Quaternion.LookRotation(gameover.transform.position - camera1.transform.position);
            Destroy(khoitaoenemy);
            Destroy(chande);
            Destroy(gameObject);
        }
        IEnumerator chodoimau(){
            yield return new WaitForSeconds(0.4f);
            hethongmau.material = maunhap;
        }
}
