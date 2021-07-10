using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazzardvolume : MonoBehaviour
{

    int Edam = 100;
    private void OnTriggerEnter(Collider other)
    {
        PMovement pmovement
            = other.gameObject.GetComponent<PMovement>();
        if (pmovement!= null)
        {
            PMovement.thvol = true;
        }
        EnemyS enemyS
    = other.gameObject.GetComponent<EnemyS>();
        if (enemyS != null)
        {
            //EnemyS.ehealth = 0;
            //Edam
            enemyS.TDamage(enemyS.ehealth);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PMovement.thvol = false;
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
