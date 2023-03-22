using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetTesting : MonoBehaviour
{
    public float _temporaryMagnetStrength;
    public float _temporaryMagnetRange;
    public float _temporaryMagnetRemainingTime;
    public bool isMagnetActive;
    public int magnetStrength;
    public LayerMask collectibleLayer;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        

        HandleMagnetFactor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin Detector")
        {
            TemporarilyAttractCoin();
            Debug.Log("We touch!");
        }
    }

    public virtual void TemporarilyAttractCoin()
    {

        if (!isMagnetActive)
        {
            _temporaryMagnetStrength = 0;
        }

        isMagnetActive = true;
        // Check for nearby collectible objects
        

    }

    protected virtual void HandleMagnetFactor()
    {
        if (isMagnetActive)
        {
            if (_temporaryMagnetRemainingTime <= 0)
            {
                isMagnetActive = false;

                magnetStrength = 0;
            }
            else
            {
                _temporaryMagnetRemainingTime -= Time.deltaTime;


                Collider[] coins = Physics.OverlapSphere(player.position, _temporaryMagnetRange, collectibleLayer);
                foreach (Collider coin in coins)
                {
                    // Attract collectible to player
                    coin.transform.position = Vector3.Lerp(coin.transform.position, player.position, Time.deltaTime * _temporaryMagnetStrength);
                }

                Debug.Log(player.position);

            }
        }

    }
}
