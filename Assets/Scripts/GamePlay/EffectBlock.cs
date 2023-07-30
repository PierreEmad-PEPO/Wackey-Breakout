using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBlock : Block
{
    private EffectName effectName;

    public EffectName EffectBlockName 
    { 
        get { return effectName; } 
        set { effectName = value; }
    }

    // Start is called before the first frame update
    override protected void Start()
    {
        blockPoints = ConfigurationUtils.EffectBlockPoints;
        base.Start();
    }
}
