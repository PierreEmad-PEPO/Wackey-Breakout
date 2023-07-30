using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    // Start is called before the first frame update
    override protected void Start()
    {
        blockPoints = ConfigurationUtils.StandardBlockPoints;
        base.Start();
    }
}
