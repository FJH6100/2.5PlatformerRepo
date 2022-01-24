using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField]
    private Transform _respawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CharacterController cc = other.GetComponent<CharacterController>();
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.LoseLife();
            }
            if (cc != null)
                cc.enabled = false;
            other.transform.position = _respawn.transform.position;
            if (cc != null)
                StartCoroutine(EnableCC(cc));
        }            
    }
    
    IEnumerator EnableCC(CharacterController controller)
    {
        yield return new WaitForSeconds(.1f);
        controller.enabled = true;
    }
}
