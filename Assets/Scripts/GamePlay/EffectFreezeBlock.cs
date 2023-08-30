using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectFreezeBlock : Block
{
    private int effectDuration;
    private event UnityAction<float> onFreezeActivateEvent;

    // Start is called before the first frame update
    override protected void Start()
    {
        blockPoints = ConfigurationUtils.EffectBlockPoints;
        effectDuration = ConfigurationUtils.EffectBlockDuration;
        EventManager.AddOnFreezeActivateInvoker(this);
        base.Start();
    }

    public void AddOnFreezeActivateListener (UnityAction<float> action)
    {
        onFreezeActivateEvent += action;
    }
    public void RemoveOnFreezeActivateListener (UnityAction<float> action)
    {
        onFreezeActivateEvent -= action;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        onFreezeActivateEvent.Invoke(effectDuration);
        base.OnCollisionEnter2D(collision);
    }

    protected override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
        EventManager.RemoveOnFreezeActivateInvoker(this);
    }
}
