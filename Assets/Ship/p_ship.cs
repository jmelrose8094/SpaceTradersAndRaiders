using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class p_ship : MonoBehaviour
{


    public int numBeamWeapons;
    public [] p_beamWeapon arrBeamWeapons;
    
    public int numGenerators;
    public [] p_sheildGenerators generators;

    public int numMissiles;
    public [] p_missileLauncher launchers;

    public int numAntiMissile;
    public [] p_antiMissile antiMissile;

    public int numCriticalHits;
    public int numArmor;

    public p_engine engine;
    public int maxComponents;
    public int slotsUsed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
