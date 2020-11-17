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
    public int owner = 1;
    public GameObject GC;
    public List<Component> arrComponents = new List<Component>();
    public List<spaceMarine> marines = new List<spaceMarine>();
    public List<spaceMarine> enemyMarines = new List<spaceMarine>();
    public int numBeamWeapons;
    public int numGenerators;
    public int numMissiles;
    public int numAntiMissile;
    public int numCriticalHits = 0;
    public int numArmor;
    public int numEngines;
    public int numRepairSys;
    public int numCommandSys;
    public int maxComponents;
    public int slotsUsed;

    public int numSpaceMarines;
    public int numActiveMarines;
    public int numEnemyMarines;

    // To Do: add in determine tactical initiative

    void Start()
    {
        numSpaceMarines = marines.Count;
        numActiveMarines = numSpaceMarines;
        numEnemyMarines = 0;
        GC = GameObject.Find("GameController");
    }
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

    public void RollUIHandler(float roll, int level)
    {
        GC.GetComponent<RollPopUp>().PopUp();
        GC.GetComponent<RollPopUp>().SetAttackerText(roll);
        GC.GetComponent<RollPopUp>().SetDefenderText(level);
        

    }

    // --------------------------------------------------- This ship attacks ship at the target parameter

    public void Attack(p_ship target)
    {
        int beamHit = 0; // number of beam weapons that need to be calculated against shields
        int missileHit = 0; //number of missiles that need top be calculated against anitmissiles
        int dmgHits = 0; //number of hits that actually make it through sheilds and anti missile

        print("In attack");
        print(target.numArmor);

        //RollUIHandler(3, 4);

        //------------------------------------------ Beam


        for (int i = 0; i < arrComponents.Count; i++)
        {
            if (arrComponents[i] is p_beamWeapon && FireBeam(i) == true && arrComponents[i].getActivity() == true)
            {
                beamHit++;
            }
        }
        print(beamHit);

        //------------------------------------------- Missile

        for (int i = 0; i < arrComponents.Count; i++)
        {
            if (arrComponents[i] is p_missileLauncher && FireMissile(i) == true && arrComponents[i].getActivity() == true)
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

            do
            {
                int marker = UnityEngine.Random.Range(0, maxComponents);

                if (marker >= target.arrComponents.Count)
                {
                    print("Critical Hit!");
                    target.numCriticalHits--;
                    dmgHits--;
                }
                else if(target.arrComponents[marker].getActivity() == true)
                {
                    target.arrComponents[marker].ToggleActivity();
                    dmgHits--;
                    print("Component: " + target.arrComponents[marker].ToString() + " inactive");
                }
                else
                {
                    target.arrComponents.RemoveAt(marker);
                    dmgHits--;
                    print("Component: " + target.arrComponents[marker].ToString() + " Destroyed");
                }
            }
            while (dmgHits != 0 && target.numCriticalHits != 0);

        }
        else
        {
            print("Armor Before: " + target.numArmor);
            target.numArmor = target.numArmor - dmgHits;
            print("Armor After: " + target.numArmor);
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
        bool boardSuccessful = false;
        numMarinesUsed = GetNumAssaultMarines();
        disadvantage = HasMoreEngines(target);


        //Boarding process
        int i = 0;
        while(i<numMarinesUsed && marines.Count>=1)
        {
            if(marines[i] != null && marines[(i)].GetActivity() == true)
            {
                if(MarineRoll(disadvantage, (i)))
                {

                    TransferMarine(marines[(i)], (i), target);

                }
                else if(!MarineRoll(disadvantage, (i)))
                {
                    if(target.HasShields())
                    {
                        marines.RemoveAt(i);
                        numSpaceMarines--;
                        numActiveMarines--;
                    }
                    else
                    {
                        marines[(i)].ToggleActive();
                        numActiveMarines--;
                        i++;
                    }
                }
            }
            else
            {
                print("Null found");
            }
            
        }
        print("post board");
        if(target.GetNumSpaceMarines() > 0)
        {
            print("target has greater than 0 space marines");
            print(target.GetNumEnemy());
            
            // Each player rolls until one side no longer has any space marines
            do
            {
                float friendlyRoll = 0, enemyRoll = 0;
                friendlyRoll = UnityEngine.Random.Range(1f, 6f);
                enemyRoll = UnityEngine.Random.Range(1f, 6f);

                if (friendlyRoll > enemyRoll)
                {
                    target.marines.RemoveAt(0);
                    target.DecMarine();
                }
                else if (friendlyRoll < enemyRoll)
                {
                    target.enemyMarines.RemoveAt(0);
                    target.DecEnemyMarine();
                }
                else
                {
                    target.enemyMarines.RemoveAt(0);
                    target.marines.RemoveAt(0);
                    target.DecEnemyMarine();
                    target.DecMarine();
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
            print("board successful");
            print(target.marines.Count);
            print(target.GetNumSpaceMarines());
            boardSuccessful = true;
        }
        
        if(boardSuccessful == true)
        {
            print("Ship Captured");
        }
        else
        {
            print("Failed Attempt");
            print(target.GetNumSpaceMarines());
            print(target.GetNumEnemy());
        }

    }

    // -------------------------------------------- Utilizes all available repair systems

    public void Repair()
    {
        int numUsed = 0;
        while(numUsed <= numRepairSys)
        {
            RepairComponent();
            numUsed++;
        }
    }

    // ------------------------------------------- Repairs a single component

    public void RepairComponent()
    {
        for(int i = 0; i<arrComponents.Count; i++)
        {
            if(arrComponents[i].getActivity() == false)
            {
                arrComponents[i].ToggleActivity();
                break;
            }
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
        int num =3;
        //GameObject.Find("GameController").GetComponent<SpaceMarinePopUp>().PopUp();

       // num = int.Parse(GameObject.Find("GameController").GetComponent<SpaceMarinePopUp>().GetText());

       // print("Num Input" + num);

        
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
        for(int i = 0; i<target.arrComponents.Count; i++)
        {
            if(target.arrComponents[i] is p_sheildGenerator && arrComponents[i].getActivity() == true)
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

        for (int i =0; i<target.arrComponents.Count; i++)
        {
            int j = 0;
            if(target.arrComponents[i] is p_antiMissile && arrComponents[i].getActivity() == true)
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

    public void AddMarine(int l)
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
    public int GetNumRepairSys()
    {
        return numRepairSys;
    }
    public int GetNumCommand()
    {
        return numCommandSys;
    }
    
    public int GetNumEngine()
    {
        return numEngines;

    }
    
    // ---------------------------------------- Buy Components

    public void BuyEngine(int level)
    {
        p_engine e = new p_engine(level);
        numEngines++;
        arrComponents.Add(e);
        print("engine added");
                
    }
    public void BuyBeamWep(int level)
    {
        p_beamWeapon bw = new p_beamWeapon(level);
        numBeamWeapons++;
        arrComponents.Add(bw);
        print("Beam Weapon Added");

    }
    public void BuyMissileLauncher(int level)
    {
        p_missileLauncher ml = new p_missileLauncher(level);
        numMissiles++;
        arrComponents.Add(ml);
        print("Missile Launcher Added");

    }
    public void BuyAntiMissile(int level)
    {
        p_antiMissile am = new p_antiMissile(level);
        numAntiMissile++;
        arrComponents.Add(am);
        print("Anti-Missile Added");

    }
    public void BuyShieldGen(int level)
    {
        p_sheildGenerator sg = new p_sheildGenerator(level);
        numGenerators++;
        arrComponents.Add(sg);
        print("Shield Generator Added");

    }
    public void BuyCommandSys(int level)
    {
        p_commandSystem cs = new p_commandSystem(level);
        numCommandSys++;
        arrComponents.Add(cs);
        print("Command System Added");

    }
    public void BuyRepairSys(int level)
    {
        p_repairSystem rs = new p_repairSystem(level);
        numRepairSys++;
        arrComponents.Add(rs);
        print("Repair System Added");

    }
}


