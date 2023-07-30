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

}
