using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class p_ship : MonoBehaviour
{
    public Component[] arrComponents;
    public List<spaceMarine> marines = new List<spaceMarine>();
    public List<spaceMarine> enemyMarines = new List<spaceMarine>();
    public int numBeamWeapons;
    public int numGenerators;
    public int numMissiles;
    public int numAntiMissile;
    public int numCriticalHits = 0;
    public int numArmor;
    public int numEngines;
    public int maxComponents;
    public int slotsUsed;

    public int numSpaceMarines;
    public int numActiveMarines;
    public int numEnemyMarines;




    public p_ship()
    {
        numBeamWeapons = 0;
        numGenerators = 0;
        numMissiles = 0;
        numAntiMissile = 0;
        numEngines = 1;
        maxComponents = 5;
        slotsUsed = 0;
        numArmor = 4;

    }

    public p_ship(int bw, int g, int m, int am, int e, int mc, int a)
    {
        numBeamWeapons = bw;
        numGenerators = g;
        numMissiles = m;
        numAntiMissile = am;
        numEngines = g;
        maxComponents = mc;
        slotsUsed = bw + g + m + am + e;
        numArmor = a;
    }

    public void Attack(p_ship target)
    {
        int beamHit = 0; // number of beam weapons that need to be calculated against shields
        int missileHit = 0; //number of missiles that need top be calculated against anitmissiles
        int dmgHits = 0; //number of hits that actually make it through sheilds and anti missile

        print("In attack");
        print(target.numArmor);

        //------------------------------------------ Beam

        for (int i = 0; i < arrComponents.Length; i++)
        {
            if (arrComponents[i] is p_beamWeapon && FireBeam(i) == true)
            {
                beamHit++;
            }
        }
        print(beamHit);

        //------------------------------------------- Missile

        for (int i = 0; i < arrComponents.Length; i++)
        {
            if (arrComponents[i] is p_missileLauncher && FireMissile(i) == true)
            {
                missileHit++;
            }
        }

        print(missileHit);

        //------------------------------------------- Shields

        if (target.HasShields() == true)
        {
            dmgHits = ShieldDeflect(beamHit, target);
        }
        else
        {
            dmgHits = beamHit;
        }

        //------------------------------------------- Anti-Missile

       if(target.HasAntiMissile() == true)
       {
            dmgHits = dmgHits + MissileDeflect(missileHit, target);
       }
        else
        {
            dmgHits = dmgHits + missileHit;
        }

        print("dmg Hits " + dmgHits);

        //--------------------------------------- Armor

        if(dmgHits > target.numArmor)
        {
            target.numArmor = 0;

            target.numCriticalHits = target.numCriticalHits - (dmgHits - target.numArmor);
        }
        else
        {
            target.numArmor = target.numArmor - dmgHits;
        }

        // -------------------------------------- Critical Hits

        if(target.numCriticalHits <= 0)
        {
            Destroy(target);
            Destroy(GameObject.FindGameObjectWithTag("ship 2"));
            print("Target Destroyed");
        }

    }


    //  -------------------------------------- Space Marine Combat

    public void MarineAssault(p_ship target)
    {
        int numMarinesUsed, disadvantage = 0, nullCounter = 0;
        bool boardSuccessful = false;
        numMarinesUsed = GetNumAssaultMarines();
        disadvantage = HasMoreEngines(target);


        //Boarding process
        int i = 0;
        while(i<numMarinesUsed)
        {
            print("boarding process while loop");
            print("Index before if: " +i);
            if(marines[i + nullCounter] != null && marines[i+nullCounter].GetActivity() == true)
            {
                print("in first if");
                if(MarineRoll(disadvantage, i+nullCounter))
                {
                    print("In if Marine roll. Size of enemy list" + target.GetEnemyMarineSize());
                    print("Index: " + i);
                    TransferMarine(marines[i+nullCounter], i+nullCounter, target);

                }
                else if(!MarineRoll(disadvantage, i+nullCounter))
                {
                    print("In else if");
                    if(target.HasShields())
                    {
                        print("Marine destroyed");
                        marines.RemoveAt(i+nullCounter);
                        numSpaceMarines--;
                        numActiveMarines--;
                    }
                    else
                    {
                        marines[i+nullCounter].ToggleActive();
                        numActiveMarines--;
                    }
                }
                i++;
            }
            else
            {
                nullCounter++;
                print("Null counter ++");
            }
            
        }
        print("post board");
        if(target.GetNumSpaceMarines() > 0)
        {

            
            // Each player rolls until one side no longer has any space marines
            do
            {
                float friendlyRoll = 0, enemyRoll = 0;
                friendlyRoll = UnityEngine.Random.Range(1f, 6f);
                enemyRoll = UnityEngine.Random.Range(1f, 6f);

                if (friendlyRoll > enemyRoll)
                {
                    for (int j = 0; j < target.GetMarinesSize(); j++)
                    {
                        if (target.marines[j] != null)
                        {
                            target.marines.RemoveAt(j);
                            target.DecMarine();
                            break;
                        }
                    }
                }
                else if (friendlyRoll < enemyRoll)
                {
                    for (int j = 0; j < target.GetEnemyMarineSize(); j++)
                    {
                        if (target.enemyMarines[j] != null)
                        {
                            target.enemyMarines.RemoveAt(j);
                            target.DecEnemyMarine();
                            break;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < target.GetMarinesSize(); j++)
                    {
                        if (target.marines[j] != null)
                        {
                            target.marines.RemoveAt(j);
                            target.DecMarine();
                            break;
                        }
                    }
                    for (int j = 0; j < target.GetEnemyMarineSize(); j++)
                    {
                        if (target.enemyMarines[j] != null)
                        {
                            target.enemyMarines.RemoveAt(j);
                            target.DecEnemyMarine();
                            break;
                        }
                    }
                }
            }
            while (target.GetNumSpaceMarines() > 0 && target.GetNumEnemy() > 0);

            if((target.GetNumEnemy() > 0) == true && target.GetNumSpaceMarines() == 0)
            {
                boardSuccessful = true;
            }
            
        }
        else
        {
            boardSuccessful = true;
        }
        
        if(boardSuccessful == true)
        {
            print("Ship Captured");
        }
        else
        {
            print("Failed Attempt");
        }

    }

    // ---------------------------------------- Rolls dice for marine

    public bool MarineRoll(int dis, int i)
    {
        if (marines[i].getLevel() >= UnityEngine.Random.Range(1f, 6f) + dis)
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }

    // ----------------------------------------- Returns how many more engines the target ship has over this ship
    public int HasMoreEngines(p_ship target)
    {
        if(this.GetNumEngine() >= target.GetNumEngine())
        {
            return 0;
        }
        else 
        {
            return (target.GetNumEngine() - this.GetNumEngine()); 
        }
    }


    

    // ------------------------------------- Ask the player how many marines they want to use in the assault

    public int GetNumAssaultMarines()
    {
        // To do: make a function to create a UI to ask the user how many marines that they want to use

        int num = 3;
        return num;
    }


    // -------------------------------------------- Get the array of space marines being used in attack and return them

    public spaceMarine[] GetSpaceMarines(int num)
    {
        spaceMarine[] a = new spaceMarine[num];

        for(int i = 0; i < num; i++)
        {
            if(marines[i] != null)
            {
                a[i] = marines[i];
            }
        }

        return a;
    }

    // -------------------------------------------- Transfers space marine from this ship to target ship

    public void TransferMarine(spaceMarine m, int i, p_ship target)
    {
        print("In Transfer Marine");
        target.AddEnemyMarine(m);
        target.IncEnemyMarine();

        marines.RemoveAt(i);

        numSpaceMarines--;


    }

    // --------------------------------------------- Adds marine to enemy ship

    public void AddEnemyMarine(spaceMarine m)
    {
        enemyMarines.Add(m);
    }


    //determines the amount of beam weapons that have a chance of hitting the enemy ship
    private bool FireBeam(int wep)
    {
        if(arrComponents[wep].getLevel() >= UnityEngine.Random.Range(1f, 6f))
        {
            return (true);
        }
        else
        {
            return (false);
        }


    }

    //determines the amount of missiles that have a chance of hitting the enemy ship
    private bool FireMissile(int wep)
    {
        if (arrComponents[wep].getLevel() >= UnityEngine.Random.Range(1f, 6f))
        {
            return (true);
        }
        else
        {
            return (false);
        }


    }

    //determines the amount of beam waepons that actually hit the ship
    private int ShieldDeflect(int hits, p_ship target)
    {
        int shieldGenLoc = 0;
        int dmg = 0;
        print("in shield" + hits);
        for(int i = 0; i<target.maxComponents; i++)
        {
            if(target.arrComponents[i] is p_sheildGenerator)
            {
                shieldGenLoc = i;
                break;
            }
        }

        for(int i=0; i<hits; i++)
        {
            if(target.arrComponents[shieldGenLoc].getLevel() <= UnityEngine.Random.Range(1f, 6f))
            {
                dmg++;
            }
        }

        return dmg;
    }

    //determines the amount of missiles that actually hit the ship
    private int MissileDeflect(int hits, p_ship target)
    {
        int dmg = 0;
        int[] AMLocations = new int[target.numAntiMissile];
        print("in MD" + hits);

        for (int i =0; i<target.maxComponents; i++)
        {
            int j = 0;
            if(target.arrComponents[i] is p_antiMissile)
            {
                AMLocations[j] = i;
                j++;
            }
        }

        for(int i = 0; i<target.numAntiMissile; i++)
        {
            if(target.arrComponents[AMLocations[i]].getLevel() >= UnityEngine.Random.Range(1f, 6f))
            {
                dmg++;
            }
        }

        if(hits > target.numAntiMissile)
        {
            dmg = dmg + (hits - target.numAntiMissile);
        }

        return (dmg);
        
    }

    // determines if this ship has any shields 
    public bool HasShields()
    {
        if(this.GetNumGenerator() >= 1)
        {
            return (true);
        }
        else
        {
            return (false);
        }
        
    }

    // determines if this ship has any anti missiles
    public bool HasAntiMissile()
    {
        if (this.GetNumAntiMissile() >= 1)
        {
            return (true);
        }
        else
        {
            return (false);
        }

    }

    //  ------------------------------------- Add Space Marine

    public void addMarine(int l)
    {
        spaceMarine a = new spaceMarine(l);

        marines.Add(a);
        numActiveMarines++;
        numSpaceMarines++;
    }

    public void IncEnemyMarine()
    {
        numEnemyMarines++;
    }

    public void DecMarine()
    {
        numSpaceMarines--;
        numActiveMarines--;
    }

    public void DecEnemyMarine()
    {
        numEnemyMarines--;
    }

    public void BuyNumBeam()
    {
        numBeamWeapons++;
        //Debug.Log("Bought 1 Beam Weapon");
    }

    public int GetMarinesSize()
    {
        return marines.Count;
    }

    public int GetEnemyMarineSize()
    {
        return enemyMarines.Count;
    }

    public int GetNumSpaceMarines()
    {
        return numSpaceMarines;
    }

    public int GetNumActiveMarines()
    {
        return numActiveMarines;
    }

    public int GetNumEnemy()
    {
        return numEnemyMarines;
    }

    public int GetNumBeam()
    {
        return numBeamWeapons;

    }
    public int GetNumGenerator()
    {
        return numGenerators;

    }
    public int GetNumMissile()
    {
        return numMissiles;

    }
    public int GetNumAntiMissile()
    {
        return numAntiMissile;

    }
    public void BuyEngine()
    {

        for(int i = 0; i<arrComponents.Length; i++)
        {
            if(arrComponents[i] == null)
            {
                numEngines++;
                arrComponents[i] = new p_engine();
                print("engine added");
                break;
                
            }
        }
    }
    public int GetNumEngine()
    {
        return numEngines;

    }
}


