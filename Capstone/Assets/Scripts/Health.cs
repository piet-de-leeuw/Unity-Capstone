using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    IController thisController;
    public int health = 50;
    public bool isDeath = false;
    //Assign in the inspector the tag of the Weapon/Object that is to be able to damage this gameObject.
    [SerializeField] string weaponTag = "";
    [SerializeField] float hitForce = 100f;

    Rigidbody rBody;
    bool isBurning = false;

    private void Start()
    {
        thisController = GetComponent<IController>();
        rBody = GetComponent<Rigidbody>();
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

        if (other.CompareTag("HealthPowerUp"))
        {
            if (health < 100)
            {
                health += 20;
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("deathPit")) 
        { 
            isDeath = true;
            thisController.Die();
        }

        if (other.CompareTag("BurnPit"))
        {
            isBurning = true;
            StartCoroutine(Burn());
        }

        if (other.CompareTag(weaponTag))
        {
            IController otherController = other.transform.root.GetComponent<IController>();

            if (health > 0)
            {
                thisController.GetHit();
                rBody.AddRelativeForce(-Vector3.forward * hitForce);
                health -= otherController.WeaponDamage;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BurnPit"))
        {
            isBurning = false;
        }
    }

    IEnumerator Burn()
    {
        while (isBurning)
        {
            health -= 5;
            thisController.GetHit();
            yield return new WaitForSeconds(2);
        }
    }

}
