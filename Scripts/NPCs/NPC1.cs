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
    public bool hasTalked = false;
    public bool isDialogue = false;

    private void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Player" && !isDialogue)
        {

            triggerText.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)){
                isDialogue = true;
                if (!hasTalked)
                {
                    other.gameObject.GetComponent<PlayerData>().DialougeNumber = 1;
                DialougeObject.SetActive(true);
                rigid.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                triggerText.SetActive(false);
                }
                else{
                other.gameObject.GetComponent<PlayerData>().DialougeNumber = 1.5f;
                DialougeObject.SetActive(true);
                rigid.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                triggerText.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other){
        triggerText.SetActive(false);
    }
}
}