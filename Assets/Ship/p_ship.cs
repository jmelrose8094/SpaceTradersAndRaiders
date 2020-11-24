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
    public int numBeamWeapons, numGenerators, numMissiles, numAntiMissile, numEngines, numRepairSys, numCommandSys;
    public int numCriticalHits, numArmor, maxComponents, slotsUsed, numAttacksRemaining, numRepairsUsed, numAssaults;
    public int numSpaceMarines, numActiveMarines, numEnemyMarines;

    // To Do: add in determine tactical initiative

    void Start()
    {
        numSpaceMarines = marines.Count;
        numActiveMarines = numSpaceMarines;
        numEnemyMarines = 0;
        GC = GameObject.Find("GameController");
    }

    void Update()
    {
        slotsUsed = arrComponents.Count;
    }
    public p_ship()
    {
        numBeamWeapons = 0;
        numGenerators = 0;
        numMissiles = 0;
        numAntiMissile = 0;
        numEngines = 0;
        numRepairSys = 0;
        numCommandSys = 0;
        numAttacksRemaining = 0;
        numRepairsUsed = 0;
        numAssaults = 0;
        numCriticalHits = 2;
        maxComponents = 5;
        slotsUsed = 0;
        numArmor = 5;
    }

    public p_ship(int maxComponentSize) //The size of the maxComponentSize variable determines what kind of ship is being created
    {
        numBeamWeapons = 0;
        numGenerators = 0;
        numMissiles = 0;
        numAntiMissile = 0;
        numEngines = 0;
        numRepairSys = 0;
        numCommandSys = 0;
        numAttacksRemaining = 0;
        numRepairsUsed = 0;
        numAssaults = 0;
        slotsUsed = 0;

        
        if(maxComponentSize <= 5)
        {
            maxComponents = 5;
            numArmor = 5;
            numCriticalHits = 2;
        }
        else if(maxComponentSize <= 10)
        {
            maxComponents = 10;
            numArmor = 10;
            numCriticalHits = 3;
        }
        else if (maxComponentSize <= 15)
        {
            maxComponents = 15;
            numArmor = 15;
            numCriticalHits = 6;
        }
        else if (maxComponentSize <= 20)
        {
            maxComponents = 20;
            numArmor = 20;
            numCriticalHits = 9;
        }
        else if (maxComponentSize <= 25)
        {
            maxComponents = 25;
            numArmor = 25;
            numCriticalHits = 18;
        }
        else
        {
            maxComponents = 5;
            numArmor = 5;
            numCriticalHits = 2;
        }

    }

    private void RollUIHandler(int roll, int level, string location)
    {
        GC.GetComponent<RollPopUp>().PopUp();

        switch(location)
        {
            case "beam hit":
                GC.GetComponent<RollPopUp>().SetAttackerText(roll);
                GC.GetComponent<RollPopUp>().SetDefenderText(level);
                GC.GetComponent<RollPopUp>().SetP1_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP2_Text("Tech Level: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Firing Beam Weapon");
                GC.GetComponent<RollPopUp>().SetHitText("Hit!");
                break;
            case "beam miss":
                GC.GetComponent<RollPopUp>().SetAttackerText(roll);
                GC.GetComponent<RollPopUp>().SetDefenderText(level);
                GC.GetComponent<RollPopUp>().SetP1_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP2_Text("Tech Level: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Firing Beam Weapon");
                GC.GetComponent<RollPopUp>().SetHitText("Miss!");
                break;
            case "missile hit":
                GC.GetComponent<RollPopUp>().SetAttackerText(roll);
                GC.GetComponent<RollPopUp>().SetDefenderText(level);
                GC.GetComponent<RollPopUp>().SetP1_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP2_Text("Tech Level: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Firing Missile");
                GC.GetComponent<RollPopUp>().SetHitText("Hit!");
                break;
            case "missile miss":
                GC.GetComponent<RollPopUp>().SetAttackerText(roll);
                GC.GetComponent<RollPopUp>().SetDefenderText(level);
                GC.GetComponent<RollPopUp>().SetP1_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP2_Text("Tech Level: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Firing Missile");
                GC.GetComponent<RollPopUp>().SetHitText("Miss!");
                break;
            case "shield deflect":
                GC.GetComponent<RollPopUp>().SetAttackerText(level);
                GC.GetComponent<RollPopUp>().SetDefenderText(roll);
                GC.GetComponent<RollPopUp>().SetP2_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP1_Text("Tech Level: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Deflecting Beam");
                GC.GetComponent<RollPopUp>().SetHitText("Deflected!");
                break;
            case "shield break":
                GC.GetComponent<RollPopUp>().SetAttackerText(level);
                GC.GetComponent<RollPopUp>().SetDefenderText(roll);
                GC.GetComponent<RollPopUp>().SetP2_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP1_Text("Tech Level: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Deflecting Beam");
                GC.GetComponent<RollPopUp>().SetHitText("Hit!");
                break;
            case "anti-missile hit":
                GC.GetComponent<RollPopUp>().SetAttackerText(level);
                GC.GetComponent<RollPopUp>().SetDefenderText(roll);
                GC.GetComponent<RollPopUp>().SetP2_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP1_Text("Tech Level: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Blocking Missile");
                GC.GetComponent<RollPopUp>().SetHitText("Hit!");
                break;
            case "anti-missile blocked":
                GC.GetComponent<RollPopUp>().SetAttackerText(level);
                GC.GetComponent<RollPopUp>().SetDefenderText(roll);
                GC.GetComponent<RollPopUp>().SetP2_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP1_Text("Tech Level: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Blocking Missile");
                GC.GetComponent<RollPopUp>().SetHitText("Blocked!");
                break;
            case "marine assault success":
                GC.GetComponent<RollPopUp>().SetAttackerText(level);
                GC.GetComponent<RollPopUp>().SetDefenderText(roll);
                GC.GetComponent<RollPopUp>().SetP2_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP1_Text("Tech Level: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Space Marine Assault");
                GC.GetComponent<RollPopUp>().SetHitText("Marine boarded");
                break;
            case "marine assault fail":
                GC.GetComponent<RollPopUp>().SetAttackerText(level);
                GC.GetComponent<RollPopUp>().SetDefenderText(roll);
                GC.GetComponent<RollPopUp>().SetP2_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP1_Text("Tech Level: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Space Marine Assault");
                GC.GetComponent<RollPopUp>().SetHitText("Marine failed to board");
                break;
            case "marine assault fail destroyed":
                GC.GetComponent<RollPopUp>().SetAttackerText(level);
                GC.GetComponent<RollPopUp>().SetDefenderText(roll);
                GC.GetComponent<RollPopUp>().SetP2_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP1_Text("Tech Level: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Space Marine Assault");
                GC.GetComponent<RollPopUp>().SetHitText("Marine was destroyed");
                break;
            case "marine vs marine success":
                GC.GetComponent<RollPopUp>().SetAttackerText(roll);
                GC.GetComponent<RollPopUp>().SetDefenderText(level);
                GC.GetComponent<RollPopUp>().SetP1_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP2_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Space Marine vs Space Marine");
                GC.GetComponent<RollPopUp>().SetHitText("Enemy marine was destroyed");
                break;
            case "marine vs marine fail":
                GC.GetComponent<RollPopUp>().SetAttackerText(roll);
                GC.GetComponent<RollPopUp>().SetDefenderText(level);
                GC.GetComponent<RollPopUp>().SetP2_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP1_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Space Marine vs Space Marine");
                GC.GetComponent<RollPopUp>().SetHitText("Friendly marine was destroyed");
                break;
            case "marine vs marine tie":
                GC.GetComponent<RollPopUp>().SetAttackerText(roll);
                GC.GetComponent<RollPopUp>().SetDefenderText(level);
                GC.GetComponent<RollPopUp>().SetP2_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP1_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Space Marine vs Space Marine");
                GC.GetComponent<RollPopUp>().SetHitText("Both marines destroyed");
                break;
            default:
                GC.GetComponent<RollPopUp>().SetAttackerText(roll);
                GC.GetComponent<RollPopUp>().SetDefenderText(level);
                GC.GetComponent<RollPopUp>().SetP1_Text("Roll: ");
                GC.GetComponent<RollPopUp>().SetP2_Text("Tech Level: ");
                GC.GetComponent<RollPopUp>().SetFiringText("Firing nothing");
                break;
        }


    }

    private void DmgAssesmentHandler(p_ship target)
    {
        string disabledComponent = "";

        GC.GetComponent<DamageAssesmentUI>().PopUp();
        GC.GetComponent<DamageAssesmentUI>().SetArmorText(target.numArmor);
        GC.GetComponent<DamageAssesmentUI>().SetCritText(target.numCriticalHits);

        for(int i = 0; i<target.arrComponents.Count; i++)
        {
            if(target.arrComponents[i].getActivity() == false)
            {
                disabledComponent = disabledComponent + target.arrComponents[i].toString();
            }
        }
        GC.GetComponent<DamageAssesmentUI>().SetDisabledComponents(disabledComponent);
    }

    private void MarineAssaultAssesmentHandler(string s)
    {
        GC.GetComponent<MarineAssaultAssesment>().PopUp();
        GC.GetComponent<MarineAssaultAssesment>().SetText(s);
    }

    private IEnumerator ErrorBox(string message)
    {
        GC.GetComponent<ErrMsgPopUp>().PopUp();
        GC.GetComponent<ErrMsgPopUp>().SetText(message);
        yield return new WaitForSeconds(2f);
        GC.GetComponent<ErrMsgPopUp>().Close();
    }

    // --------------------------------------------------- This ship attacks ship at the target parameter
    public void LaunchAttack(p_ship target)
    {
        if (numAttacksRemaining > 0)
        {
            numAttacksRemaining--;
            StartCoroutine(Attack(target));
        }
        else
            StartCoroutine(ErrorBox("You have used all you attacks for this turn"));
    }

    public void LaunchMarineAssault(p_ship target)
    {
        if (numAssaults == 0)
        {
            numAssaults++;
            StartCoroutine(MarineAssault(target));
        }
        else
            StartCoroutine(ErrorBox("You have used all you marine assaults for this turn"));
    }

    private IEnumerator Attack(p_ship target)
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
            Tuple<bool, int> temp;
            GC.GetComponent<RollPopUp>().Close();
            if (arrComponents[i] is p_beamWeapon && arrComponents[i].getActivity() == true)
            {
                temp = FireBeam(i);
                if(temp.Item1 == true)
                {
                    beamHit++;

                    RollUIHandler(temp.Item2, arrComponents[i].getLevel(), "beam hit");
                    yield return new WaitForSeconds(3f);
                    GC.GetComponent<RollPopUp>().Close();
                }
                else
                {
                    RollUIHandler(temp.Item2, arrComponents[i].getLevel(), "beam miss");
                    yield return new WaitForSeconds(3f);
                    GC.GetComponent<RollPopUp>().Close();
                }
                
            }
        }
        print(beamHit);

        //------------------------------------------- Missile

        for (int i = 0; i < arrComponents.Count; i++)
        {
            Tuple<bool, int> temp;
            if (arrComponents[i] is p_missileLauncher && arrComponents[i].getActivity() == true)
            {
                temp = FireMissile(i);
                if (temp.Item1 == true)
                {
                    missileHit++;

                    RollUIHandler(temp.Item2, arrComponents[i].getLevel(), "missile hit");
                    yield return new WaitForSeconds(3f);
                    GC.GetComponent<RollPopUp>().Close();
                }
                else
                {
                    RollUIHandler(temp.Item2, arrComponents[i].getLevel(), "missile miss");
                    yield return new WaitForSeconds(3f);
                    GC.GetComponent<RollPopUp>().Close();
                }
            }
        }

        print(missileHit);

        //------------------------------------------- Shields

        if (target.HasShields() == true)
        {
            int shieldGenLoc = 0;
            for (int i = 0; i < target.arrComponents.Count; i++)
            {
                if (target.arrComponents[i] is p_sheildGenerator && arrComponents[i].getActivity() == true)
                {
                    shieldGenLoc = i;
                    break;
                }
            }

            for(int i = 0; i<beamHit; i++)
            {
                Tuple<bool, int> temp;
                temp = ShieldDeflect(shieldGenLoc, target);

                if(temp.Item1 == true)
                {
                    dmgHits++;
                    RollUIHandler(arrComponents[shieldGenLoc].getLevel(), temp.Item2, "shield break");
                    yield return new WaitForSeconds(3f);
                    GC.GetComponent<RollPopUp>().Close();
                }
                else
                {
                    RollUIHandler(arrComponents[shieldGenLoc].getLevel(), temp.Item2, "shield deflect");
                    yield return new WaitForSeconds(3f);
                    GC.GetComponent<RollPopUp>().Close();
                }
            }
        }
        else
        {
            dmgHits = beamHit;
        }

        //------------------------------------------- Anti-Missile

       if(target.HasAntiMissile() == true)
       {
            Tuple<bool, int> temp;
            for (int i = 0; i < target.arrComponents.Count; i++)
            {
                if(missileHit <= 0)
                {
                    break;
                }
                else if (target.arrComponents[i] is p_antiMissile && arrComponents[i].getActivity() == true)
                {
                    temp = MissileDeflect(i, target);

                    if(temp.Item1 == true)
                    {
                        dmgHits++;
                        missileHit--;
                        RollUIHandler(arrComponents[i].getLevel(), temp.Item2, "anti-missile hit");
                        yield return new WaitForSeconds(3f);
                        GC.GetComponent<RollPopUp>().Close();
                    }
                    else
                    {
                        missileHit--;
                        RollUIHandler(arrComponents[i].getLevel(), temp.Item2, "anti-missile blocked");
                        yield return new WaitForSeconds(3f);
                        GC.GetComponent<RollPopUp>().Close();
                    }
                }
            }

            if(missileHit > 0)
            {
                dmgHits = dmgHits + missileHit;
            }

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

        DmgAssesmentHandler(target);
        yield return new WaitForSeconds(5f);
        GC.GetComponent<DamageAssesmentUI>().Close();

        if (target.numCriticalHits <= 0)
        {
            Destroy(target);
            Destroy(GameObject.FindGameObjectWithTag("ship 2"));
            print("Target Destroyed");
        }

    }


    //  -------------------------------------- Space Marine Combat

    private IEnumerator MarineAssault(p_ship target)
    {
        int disadvantage = 0;
        bool boardSuccessful = false;

        disadvantage = HasMoreEngines(target);


        //Boarding process
        int i = 0;
        while(i<numActiveMarines && marines.Count>=1)
        {
            Tuple<bool, int> temp;
            if(marines[i] != null && marines[(i)].GetActivity() == true)
            {
                temp = MarineRoll(disadvantage, (i));
                if (temp.Item1 == true)
                {
                    RollUIHandler(temp.Item2, marines[i].getLevel(), "marine assault success");
                    TransferMarine(marines[(i)], (i), target);
                    yield return new WaitForSeconds(3f);
                    GC.GetComponent<RollPopUp>().Close();

                }
                else if(!temp.Item1)
                {
                    if(target.HasShields())
                    {
                        RollUIHandler(temp.Item2, marines[i].getLevel(), "marine assault fail destroyed");
                        yield return new WaitForSeconds(3f);
                        GC.GetComponent<RollPopUp>().Close();
                        marines.RemoveAt(i);
                        numSpaceMarines--;
                        numActiveMarines--;

                    }
                    else
                    {
                        RollUIHandler(temp.Item2, marines[i].getLevel(), "marine assault fail");
                        yield return new WaitForSeconds(3f);
                        GC.GetComponent<RollPopUp>().Close();
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
                int friendlyRoll = 0, enemyRoll = 0;
                friendlyRoll = UnityEngine.Random.Range(1, 6);
                enemyRoll = UnityEngine.Random.Range(1, 6);

                if (friendlyRoll > enemyRoll)
                {
                    RollUIHandler(friendlyRoll, enemyRoll, "marine vs marine success");
                    yield return new WaitForSeconds(3f);
                    GC.GetComponent<RollPopUp>().Close();
                    target.marines.RemoveAt(0);
                    target.DecMarine();
                }
                else if (friendlyRoll < enemyRoll)
                {
                    RollUIHandler(friendlyRoll, enemyRoll, "marine vs marine fail");
                    yield return new WaitForSeconds(3f);
                    GC.GetComponent<RollPopUp>().Close();
                    target.enemyMarines.RemoveAt(0);
                    target.DecEnemyMarine();
                }
                else
                {
                    RollUIHandler(friendlyRoll, enemyRoll, "marine vs marine tie");
                    yield return new WaitForSeconds(3f);
                    GC.GetComponent<RollPopUp>().Close();
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
            MarineAssaultAssesmentHandler("Enemy ship was captured!");
            yield return new WaitForSeconds(5f);
            GC.GetComponent<MarineAssaultAssesment>().Close();
            print("Ship Captured");
        }
        else
        {
            MarineAssaultAssesmentHandler("Enemy ship was not captured!");
            yield return new WaitForSeconds(5f);
            GC.GetComponent<MarineAssaultAssesment>().Close();
            print("Failed Attempt");
            print(target.GetNumSpaceMarines());
            print(target.GetNumEnemy());
        }

    }

    // -------------------------------------------- Utilizes all available repair systems

    public void Repair()
    {
        while(numRepairsUsed <= numRepairSys)
        {
            RepairComponent();
            numRepairsUsed++;
        }
    }

    // ------------------------------------------- Repairs a single component

    private void RepairComponent()
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

    private Tuple<bool, int> MarineRoll(int dis, int i)
    {
        int roll = UnityEngine.Random.Range(1, 6) + dis;
        if (marines[i].getLevel() >= roll)
        {
            return Tuple.Create(true, roll);
        }
        else
        {
            return Tuple.Create(false, roll);
        }
    }

    // ----------------------------------------- Returns how many more engines the target ship has over this ship
    private int HasMoreEngines(p_ship target)
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

    //public IEnumerator GetNumAssaultMarines()
    //{
    //    // To do: make a function to create a UI to ask the user how many marines that they want to use
    //    int num =3;
    //    GC.GetComponent<SpaceMarinePopUp>().PopUp();

    //    while (!GC.GetComponent<SpaceMarinePopUp>().GetClicked())
    //    {
    //        yield return new WaitForSeconds(1f);
    //    }
        
    //    num = int.Parse(GC.GetComponent<SpaceMarinePopUp>().GetText());

    //    numMarinesUsed = num;
    //}


    // -------------------------------------------- Get the array of space marines being used in attack and return them

    private spaceMarine[] GetSpaceMarines(int num)
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

    // ------------------------------------------ To be used at the end of a turn to reset the number of attacks and repairs the ship can use

    public void Reset()
    {
        numAttacksRemaining = 0;
        numRepairsUsed = 0;
        numAssaults = 0;
        for(int i = 0; i<arrComponents.Count; i++)
        {
            if(arrComponents[i] is p_commandSystem && arrComponents[i].getActivity() == true)
            {
                numAttacksRemaining++;
            }
        }
    }

    // -------------------------------------------- Transfers space marine from this ship to target ship

    private void TransferMarine(spaceMarine m, int i, p_ship target)
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
    private Tuple<bool, int> FireBeam(int wep)
    {
        int roll;
        roll = UnityEngine.Random.Range(1, 6);
        if (arrComponents[wep].getLevel() >= roll)
        {
            return Tuple.Create(true, roll);
        }
        else
        {
            return Tuple.Create(false, roll);
        }


    }

    //determines the amount of missiles that have a chance of hitting the enemy ship
    private Tuple<bool, int> FireMissile(int wep)
    {
        int roll;
        roll = UnityEngine.Random.Range(1, 6);
        if (arrComponents[wep].getLevel() >= roll)
        {
            return Tuple.Create(true, roll);
        }
        else
        {
            return Tuple.Create(false, roll);
        }
    }

    //determines the amount of beam waepons that actually hit the ship
    private Tuple<bool, int> ShieldDeflect(int loc, p_ship target)
    {
        int roll = UnityEngine.Random.Range(1, 6);

        if(target.arrComponents[loc].getLevel() <= roll )
        {
            return Tuple.Create(true, roll);
        }
        else
        {
            return Tuple.Create(false, roll);
        }
    }

    //determines the amount of missiles that actually hit the ship
    private Tuple<bool, int> MissileDeflect(int AMLoc, p_ship target)
    {
        int roll = UnityEngine.Random.Range(1, 6);
        if (target.arrComponents[AMLoc].getLevel() >= roll)
        {
            return Tuple.Create(true, roll);
        }
        else
        {
            return Tuple.Create(false, roll);
        }
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

    // -------------------------------------- Accessors

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

    public void BuyArmor()
    {
        numArmor++;
    }

    public void BuyEngine(int level)
    {
        if (slotsUsed < maxComponents)
        {
            p_engine e = new p_engine(level);
            numEngines++;
            arrComponents.Add(e);
            print("engine added");
        }
        else
            StartCoroutine(ErrorBox("You already have the maximum number of components"));
                
    }
    public void BuyBeamWep(int level)
    {
        if(slotsUsed<maxComponents)
        {
            p_beamWeapon bw = new p_beamWeapon(level);
            numBeamWeapons++;
            arrComponents.Add(bw);
            print("Beam Weapon Added");
        }
        else
            StartCoroutine(ErrorBox("You already have the maximum number of components"));


    }
    public void BuyMissileLauncher(int level)
    {
        if (slotsUsed < maxComponents)
        {
            p_missileLauncher ml = new p_missileLauncher(level);
            numMissiles++;
            arrComponents.Add(ml);
            print("Missile Launcher Added");
        }
        else
            StartCoroutine(ErrorBox("You already have the maximum number of components"));

    }
    public void BuyAntiMissile(int level)
    {
        if (slotsUsed < maxComponents)
        {
            p_antiMissile am = new p_antiMissile(level);
            numAntiMissile++;
            arrComponents.Add(am);
            print("Anti-Missile Added");
        }
        else
            StartCoroutine(ErrorBox("You already have the maximum number of components"));

    }
    public void BuyShieldGen(int level)
    {
        if (slotsUsed < maxComponents)
        {
            p_sheildGenerator sg = new p_sheildGenerator(level);
            numGenerators++;
            arrComponents.Add(sg);
            print("Shield Generator Added");
        }
        else
            StartCoroutine(ErrorBox("You already have the maximum number of components"));

    }
    public void BuyCommandSys()
    {
        if (slotsUsed < maxComponents)
        {
            p_commandSystem cs = new p_commandSystem();
            numCommandSys++;
            arrComponents.Add(cs);
            print("Command System Added");
        }
        else
            StartCoroutine(ErrorBox("You already have the maximum number of components"));
    }

    public void BuyRepairSys(int level)
    {
        if (slotsUsed < maxComponents)
        {
            p_repairSystem rs = new p_repairSystem(level);
            numRepairSys++;
            arrComponents.Add(rs);
            print("Repair System Added");
        }
        else
            StartCoroutine(ErrorBox("You already have the maximum number of components"));
    }
}


