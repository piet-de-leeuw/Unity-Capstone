using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    IController thisController;
    public int health = 50;
    bool isDeath = false;
    //Assign in the inspector the tag of the Weapon/Object that is to be able to damage this gameObject.
    [SerializeField] string weaponTag = "";

    private void Start()
    {
        thisController = GetComponent<IController>();

    }

    private void Update()
    {
        
        if (isDeath) { return; }
        if (health <= 0)
        {
            Debug.Log("die" + thisController);

            isDeath = true;
            thisController.Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isDeath) { return; }

        if (other.CompareTag("deathPit")) 
        { 
            isDeath = true;
            thisController.Die();
        }

        if (!other.CompareTag(weaponTag)) { return; }
        if (other.CompareTag(weaponTag))
        {
            Debug.Log(thisController + other.gameObject.name);

            IController otherController = other.transform.root.GetComponent<IController>();

            if (health > 0)
            {
                thisController.GetHit();
                health -= otherController.WeaponDamage;
            }
        }
    }

}
