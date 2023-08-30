using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectSpeedBlock : Block
{
    private int effectDuration;
    private event UnityAction<int,int> onSpeedActivateEvent;

    override protected void Start()
    {
        blockPoints = ConfigurationUtils.EffectBlockPoints;
        effectDuration = ConfigurationUtils.EffectBlockDuration;
        EventManager.AddOnSpeedActivateInvoker(this);
        base.Start();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        onSpeedActivateEvent(effectDuration, 50);
        EventManager.RemoveOnSpeedActivateInvoker(this);
        base.OnCollisionEnter2D(collision);
    }

    public void AddOnSpeedActivateListener (UnityAction<int,int> action)
    {
        onSpeedActivateEvent += action;
    }
    public void RemoveOnSpeedActivateListener (UnityAction<int,int> action)
    {
        onSpeedActivateEvent -= action;
    }
}
