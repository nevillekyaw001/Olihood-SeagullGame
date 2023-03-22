using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class LootLockerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
