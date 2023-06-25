using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int blockPoints = 5;

    // Start is called before the first frame update
    void Start()
    {
        blockPoints = ConfigurationUtils.StandardBlockPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HUD.AddScore(blockPoints);

        Destroy(gameObject);
    }
}
