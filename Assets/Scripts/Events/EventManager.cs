using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    private static List<Ball> onBallDieInvokers = new List<Ball>();
    private static UnityAction onBallDieListener;

    public static void AddOnBallDieInvoker(Ball ball)
    {
        onBallDieInvokers.Add(ball);
        if (onBallDieListener != null) ball.AddOnBallDieEventListener(onBallDieListener);
    }
    public static void RemoveOnBallDieInvoker(Ball ball)
    {
        onBallDieInvokers.Remove(ball);
    }
    public static void AddOnBallDieListener(UnityAction _onBallDieListener)
    {
        onBallDieListener = _onBallDieListener;
        foreach (Ball ball in onBallDieInvokers)
            ball.AddOnBallDieEventListener(onBallDieListener);
    }

    //-------------------------------------------------------------------------

    private static List<Ball> onBallLostInvokers = new List<Ball>();
    private static UnityAction onBallLostListener;

    public static void AddOnBallLostInvoker(Ball ball)
    {
        onBallLostInvokers.Add(ball);
        if (onBallLostListener != null) ball.AddOnBallLostEventListener(onBallLostListener);
    }
    public static void RemoveOnBallLostInvoker(Ball ball)
    {
        onBallLostInvokers.Remove(ball);
    }
    public static void AddOnBallLostListener(UnityAction _onBallLostListener)
    {
        onBallLostListener = _onBallLostListener;
        foreach (Ball ball in onBallLostInvokers)
            ball.AddOnBallLostEventListener(onBallLostListener);
    }

    //----------------------------------------------------------------------------

    private static List<Block> onBlockDestroyedInvokers = new List<Block>();
    private static UnityAction<int> onBlockDestroyedListener;

    public static void AddOnBlockDestroyedInvoker(Block block)
    {
        onBlockDestroyedInvokers.Add(block);
        if (onBlockDestroyedListener != null) 
            block.AddOnBlockDestroyedEventListener(onBlockDestroyedListener);
    }
    public static void RemoveOnBlockDestroyedInvoker(Block block)
    {
        onBlockDestroyedInvokers.Remove(block);
    }
    public static void AddOnBlockDestroyedListener(UnityAction<int> action)
    {
        onBlockDestroyedListener = action;
        foreach (Block block in onBlockDestroyedInvokers)
            block.AddOnBlockDestroyedEventListener(onBlockDestroyedListener);
    }

    //----------------------------------------------------------------------------

    private static List<EffectFreezeBlock> onFreezeActivateInvokers = new List<EffectFreezeBlock>();
    private static List<UnityAction<float>> onFreezeActivateListeners = new List<UnityAction<float>>();

    public static void AddOnFreezeActivateInvoker (EffectFreezeBlock block)
    {
        onFreezeActivateInvokers.Add(block);
        if (onFreezeActivateListeners.Count > 0)
        {
            foreach (UnityAction<float> action in onFreezeActivateListeners)
                block.AddOnFreezeActivateListener(action);

        }
    }
    public static void RemoveOnFreezeActivateInvoker(EffectFreezeBlock block)
    {
        onFreezeActivateInvokers.Remove(block);
    }
    public static void AddOnFreezeActivateListener(UnityAction<float> action)
    {
        onFreezeActivateListeners.Add(action);
        if (onFreezeActivateInvokers.Count > 0)
        {
            foreach (EffectFreezeBlock block in onFreezeActivateInvokers)
                block.AddOnFreezeActivateListener(action);
        }
    }
    public static void RemoveOnFreezeActivateListener(UnityAction<float> action)
    {
        onFreezeActivateListeners.Remove(action);
        foreach (EffectFreezeBlock block in onFreezeActivateInvokers)
            block.RemoveOnFreezeActivateListener(action);
    }

    //----------------------------------------------------------------------

    private static List<EffectSpeedBlock> onSpeedActivateInvokers = new List<EffectSpeedBlock>();
    private static List<UnityAction<int,int>> onSpeedActivateListeners = new List<UnityAction<int,int>>();

    public static void AddOnSpeedActivateInvoker(EffectSpeedBlock block)
    {
        onSpeedActivateInvokers.Add(block);
        if (onSpeedActivateListeners.Count > 0)
        {
            foreach (UnityAction<int,int> action in onSpeedActivateListeners)
                block.AddOnSpeedActivateListener(action);

        }
    }
    public static void RemoveOnSpeedActivateInvoker(EffectSpeedBlock block)
    {
        onSpeedActivateInvokers.Remove(block);
    }
    public static void AddOnSpeedActivateListener(UnityAction<int,int> action)
    {
        onSpeedActivateListeners.Add(action);
        if (onSpeedActivateInvokers.Count > 0)
        {
            foreach (EffectSpeedBlock block in onSpeedActivateInvokers)
                block.AddOnSpeedActivateListener(action);
        }
    }
    public static void RemoveOnSpeedActivateListener(UnityAction<int,int> action)
    {
        onSpeedActivateListeners.Remove(action);
        foreach (EffectSpeedBlock block in onSpeedActivateInvokers)
            block.RemoveOnSpeedActivateListener(action);
    }

    //----------------------------------------------------------------------

    private static Block onYouWininvoker;
    private static List<UnityAction> onYouWinListeners = new List<UnityAction>();

    public static void AddOnYouWinInvoker(Block block)
    {
        onYouWininvoker = block;

        foreach(UnityAction action in onYouWinListeners)
        {
            block.AddOnYouWinEventListener(action);
        }
    }

    public static void AddOnYouWinListener(UnityAction action)
    {
        onYouWinListeners.Add(action);

        if (onYouWininvoker != null) onYouWininvoker.AddOnYouWinEventListener(action);
    }

    public static void RemoveOnYouWinListener(UnityAction action)
    {
        onYouWinListeners.Remove(action);
    }

}
