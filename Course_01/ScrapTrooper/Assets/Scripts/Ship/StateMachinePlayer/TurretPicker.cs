using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPicker : MonoBehaviour
{
    [SerializeField]
    private TurretArmory turretArmory;
    
    
    private enum turretType 
    {
      bulletTurret =1,
      rocketTurret, 
    }
    turretType activeTurret;
    void Start()
    {
       
        turretArmory = GetComponent<TurretArmory>();
        activeTurret = turretType.rocketTurret;
       
    }

    
        

    private void Update()
    {
        switch (activeTurret)
        {
            case turretType.bulletTurret:
                if (Input.GetKeyDown(KeyCode.R))
                {                  
                    activeTurret = turretType.rocketTurret;
                }
                
                turretArmory.BulletTurret();
                break;

            case turretType.rocketTurret:
                if (Input.GetKeyDown(KeyCode.R))
                {                   
                    activeTurret = turretType.bulletTurret;
                }
                
                
                turretArmory.RocketTurret();
                break;
        }

   

    }
}
