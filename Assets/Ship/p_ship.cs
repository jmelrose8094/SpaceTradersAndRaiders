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
    public ArrayList marines = new ArrayList();
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
        int numMarinesUsed, disadvantage = 0;
        spaceMarine[] AssaultMarines;
        numMarinesUsed = GetNumMarines();
        AssaultMarines = GetSpaceMarines(numMarinesUsed);

        disadvantage = HasMoreEngines(target);
        



        


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


    //  ------------------------------------- Add Space Marine

    public void addMarine(int l)
    {
        //spaceMarine a = new spaceMarine();

        //marines.Add(a);
    }

    // ------------------------------------- Ask the player how many marines they want to use in the assault

    public int GetNumMarines()
    {
        // To do: make a function to create a UI to ask the user how many marines that they want to use

        int num = 3;
        return num;
    }


    // -------------------------------------------- Get the array of space marines being used in attack and return them

    public spaceMarine[] GetSpaceMarines(int num)
    {
        spaceMarine[] a = new spaceMarine[3];
        return a;
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

    public void BuyNumBeam()
    {
        numBeamWeapons++;
        //Debug.Log("Bought 1 Beam Weapon");
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


