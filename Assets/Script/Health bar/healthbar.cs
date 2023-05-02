using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    private Camera _cam;
    void Start(){
        _cam = Camera.main;
    }
    [SerializeField] private Image healthbarsprite;
    public void updathealthbar(float maxhealth, float currenthealth){
        healthbarsprite.fillAmount = currenthealth / maxhealth;
        //Debug.Log(currenthealth/maxhealth);
    }
    void Update(){
        transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);
    }
}
