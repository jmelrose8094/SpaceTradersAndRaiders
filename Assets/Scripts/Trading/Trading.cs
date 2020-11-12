using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trading : MonoBehaviour
{

    public UnityEngine.UI.Text pOneMins, pTwoMins;
    public int comOne, comTwo, rareOne, rareTwo, vRareOne, vRareTwo;
    public GameObject retrieval;
    public Text minCount;


    // Start is called before the first frame update
    void Start()
    {
        retrieval = GameObject.FindGameObjectWithTag("End Turn");
    }

    // Update is called once per frame
    void Update()
    {
        //Retrieves current mineral count
        comOne = retrieval.GetComponent<EndTurn>().commonMineralsOne;
        comTwo = retrieval.GetComponent<EndTurn>().commonMineralsTwo;
        rareOne = retrieval.GetComponent<EndTurn>().rareMineralsOne;
        rareTwo = retrieval.GetComponent<EndTurn>().rareMineralsTwo;
        vRareOne = retrieval.GetComponent<EndTurn>().vRareMineralsOne;
        vRareTwo = retrieval.GetComponent<EndTurn>().vRareMineralsTwo;

        //Updates trading textbox
        pOneMins.text = "Common Minerals: " + comOne + "\nRare Minerals: " + rareOne + "\nVery Rare Minerals: " + vRareOne;
        pTwoMins.text = "Common Minerals: " + comTwo + "\nRare Minerals: " + rareTwo + "\nVery Rare Minerals: " + vRareTwo;
    }


    public GameObject errorMessage;

    public void ConfirmTrade()
    {
        InputField inp1 = GameObject.FindWithTag("ComMinOne").GetComponent<InputField>() as InputField;
        InputField inp2 = GameObject.FindWithTag("ComMinTwo").GetComponent<InputField>() as InputField;
        InputField inp3 = GameObject.FindWithTag("RareMinOne").GetComponent<InputField>() as InputField;
        InputField inp4 = GameObject.FindWithTag("RareMinTwo").GetComponent<InputField>() as InputField;
        InputField inp5 = GameObject.FindWithTag("VRareMinOne").GetComponent<InputField>() as InputField;
        InputField inp6 = GameObject.FindWithTag("VRareMinTwo").GetComponent<InputField>() as InputField;
        int comOnePut = 0;
        Int32.TryParse(inp1.text, out comOnePut);
        int comTwoPut = 0;
        Int32.TryParse(inp2.text, out comTwoPut);
        int rareOnePut = 0;
        Int32.TryParse(inp3.text, out rareOnePut);
        int rareTwoPut = 0;
        Int32.TryParse(inp4.text, out rareTwoPut);
        int vRareOnePut = 0;
        Int32.TryParse(inp5.text, out vRareOnePut);
        int vRareTwoPut = 0;
        Int32.TryParse(inp6.text, out vRareTwoPut);

        //Trading of minerals
        if (comOnePut <= comOne)
        {
            retrieval.GetComponent<EndTurn>().commonMineralsOne -= comOnePut;
            retrieval.GetComponent<EndTurn>().commonMineralsTwo += comOnePut;
        }
        else
        {
            errorMessage.SetActive(true);
            StartCoroutine(errorEnd());
        }

        if (comTwoPut <= comTwo)
        {
            retrieval.GetComponent<EndTurn>().commonMineralsTwo -= comTwoPut;
            retrieval.GetComponent<EndTurn>().commonMineralsOne += comTwoPut;
        }
        else
        {
            errorMessage.SetActive(true);
            StartCoroutine(errorEnd());
        }

        if (rareOnePut <= rareOne)
        {
            retrieval.GetComponent<EndTurn>().rareMineralsOne -= rareOnePut;
            retrieval.GetComponent<EndTurn>().rareMineralsTwo += rareOnePut;
        }
        else
        {
            errorMessage.SetActive(true);
            StartCoroutine(errorEnd());
        }

        if (rareTwoPut <= rareTwo)
        {
            retrieval.GetComponent<EndTurn>().rareMineralsTwo -= rareTwoPut;
            retrieval.GetComponent<EndTurn>().rareMineralsOne += rareTwoPut;
        }
        else
        {
            errorMessage.SetActive(true);
            StartCoroutine(errorEnd());
        }

        if (vRareOnePut <= vRareOne)
        {
            retrieval.GetComponent<EndTurn>().vRareMineralsOne -= vRareOnePut;
            retrieval.GetComponent<EndTurn>().vRareMineralsTwo += vRareOnePut;
        }
        else
        {
            errorMessage.SetActive(true);
            StartCoroutine(errorEnd());
        }

        if (vRareTwoPut <= vRareTwo)
        {
            retrieval.GetComponent<EndTurn>().vRareMineralsTwo -= vRareTwoPut;
            retrieval.GetComponent<EndTurn>().vRareMineralsOne += vRareTwoPut;
        }
        else
        {
            errorMessage.SetActive(true);
            StartCoroutine(errorEnd());
        }
    }

    public IEnumerator errorEnd()
    {
        yield return new WaitForSeconds(2);
        errorMessage.SetActive(false);
    }

}
