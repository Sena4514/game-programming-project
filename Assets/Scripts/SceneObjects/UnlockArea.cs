using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockArea : MonoBehaviour
{
    public UnlockData unlockableData;
    public TextMeshPro NameText;
    public TextMeshPro PriceText;
    public List<GameObject> ObjectsToUnlock = new List<GameObject>();
    public GameObject plane, bot, car, train, stickMan, carUnlock, trainUnlock, botUnlock, planeUnlock;
    public Stash stash;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    private void OnEnable()
    {
        CheckUnlocked();
    }

    void Start()
    {
        ObjectsToUnlock.ForEach((x) => x.SetActive(false));
        //ObjectToUnlock.SetActive(false);
        NameText.text = "UNLOCK " + unlockableData.unlockableName.ToUpper();
        PriceText.text = unlockableData.RemainingPrice.ToString();

    }

    public void Pay(Stashable stashable)
    {
        if (unlockableData.RemainingPrice <= 0)
            return;

        unlockableData.CollectedPrice++;
        stashable.PayStashable(transform, PaymentCompleted);

    }

    private void PaymentCompleted()
    {
        PriceText.text = unlockableData.RemainingPrice.ToString();

        CheckUnlocked();
    }

    private void CheckUnlocked()
    {
        if (unlockableData.RemainingPrice <= 0)
        {
            ObjectsToUnlock.ForEach((x) =>
            {
                //x.transform.parent = null;
                x.SetActive(true);
            });
            gameObject.SetActive(false);

            if (stickMan.activeSelf == true && carUnlock.activeSelf == false) //
            {
                car.SetActive(true);
                stash.maxCollectableCount = 10;
                stickMan.SetActive(false);
            }
            else if (car.activeSelf == true && trainUnlock.activeSelf == false) //
            {
                train.SetActive(true);
                stash.maxCollectableCount = 20;
                car.SetActive(false);
            }
            else if (train.activeSelf == true && botUnlock.activeSelf == false) //
            {
                bot.SetActive(true);
                stash.maxCollectableCount = 10;
                train.SetActive(false);
            }
            else if (bot.activeSelf == true && planeUnlock.activeSelf == false) //
            {
                plane.SetActive(true);
                stash.maxCollectableCount = 5;
                bot.SetActive(false);
            }
        }
    }
}

