using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

public class p_ship : MonoBehaviour
{

    public int numBeamWeapons;
    public p_beamWeapon[] arrBeamWeapons;

    public int numGenerators;
    public p_sheildGenerator[] generators;

    public int numMissiles;
    public p_missileLauncher[] launchers;

    public int numAntiMissile;
    public p_antiMissile[] antiMissile;

    public int numCriticalHits = 0;
    public int numArmor;

    public p_engine[] engines;
    public int numEngines;
    public int maxComponents;
    public int slotsUsed;

    public p_ship()
    {
        numBeamWeapons = 0;
        numGenerators = 0;
        numMissiles = 0;
        numAntiMissile = 0;
        numEngines = 1;
        maxComponents = 5;
        slotsUsed = 0;

    }

    public p_ship(int bw, int g, int m, int am, int e, int mc)
    {
        numBeamWeapons = bw;
        numGenerators = g;
        numMissiles = m;
        numAntiMissile = am;
        numEngines = g;
        maxComponents = mc;
        slotsUsed = bw + g + m + am + e;
    }

    public void Attack(p_ship target)
    {
        int beamHit = 0; // number of beam weapons that need to be calculated against shields
        int missileHit = 0; //number of missiles that need top be calculated against anitmissiles
        int dmgHits = 0; //number of hits that actually make it through sheilds and anti missile

        for(int i = 0; i < arrBeamWeapons.Length; i++)
        {
            if(FireBeam(i) == true)
            {
                beamHit++;
            }
        }

        for (int i = 0; i < launchers.Length; i++)
        {
            if (FireMissile(i) == true)
            {
                missileHit++;
            }
        }

        if(target.HasShields() == true)
        {
            for(int i = 0; i < beamHit; i++)
            {
                if(target.ShieldDeflect(0) == true)
                {
                    dmgHits++;
                }
            }
        }
        else
        {
            dmgHits = beamHit;
        }

        for (int i = 0; i < antiMissile.Length; i++)
        {
            if (target.MissileDeflect(i) == true)
            {
                dmgHits++;
            }
        }

        if(missileHit > antiMissile.Length)
        {
            dmgHits = dmgHits + (antiMissile.Length - missileHit);
        }





    }


    //determines the amount of beam weapons that have a chance of hitting the enemy ship
    private bool FireBeam(int wep)
    {
        if(arrBeamWeapons[wep].getLevel() >= UnityEngine.Random.Range(1f, 6f))
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
        if (launchers[wep].getLevel() >= UnityEngine.Random.Range(1f, 6f))
        {
            return (true);
        }
        else
        {
            return (false);
        }


    }

    //determines the amount of beam waepons that actually hit the ship
    private bool ShieldDeflect(int s)
    {
        if (generators[s].getLevel() >= UnityEngine.Random.Range(1f, 6f))
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }

    //determines the amount of missiles that actually hit the ship
    private bool MissileDeflect(int am)
    {
        if (antiMissile[am].getLevel() >= UnityEngine.Random.Range(1f, 6f))
        {
            return (true);
        }
        else
        {
            return (false);
        }
    }


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
    public int GetNumEngine()
    {
        return numEngines;

    }
}
