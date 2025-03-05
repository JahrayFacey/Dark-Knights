using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.FirstPerson
{

public class NPC1 : MonoBehaviour
{
    public GameObject triggerText;
    public GameObject DialougeObject;
    public RigidbodyFirstPersonController rigid;

    private void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Player"){
            triggerText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
                other.gameObject.GetComponent<PlayerData>().DialougeNumber = 1;
                DialougeObject.SetActive(true);
                rigid.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    private void OnTriggerExit(Collider other){
        triggerText.SetActive(false);
    }
}
}