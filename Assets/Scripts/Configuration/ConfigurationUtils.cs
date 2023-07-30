using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    private static ConfigurationData configurationData;

    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static int BallLifeTime
    {
        get { return configurationData.BallLifeTime; }
    }

    public static int SpawnNextBallTimeMin
    {
        get { return configurationData.SpawnNextBallTimeMin; }
    }

    public static int SpawnNextBallTimeMax
    {
        get { return configurationData.SpawnNextBallTimeMax; }
    }

    public static int BallsNumberPerGame
    {
        get { return configurationData.BallsNumberPerGame; }
    }
    public static int StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints; }
    }
    public static int EffectBlockPoints
    {
        get { return configurationData.EffectBlockPoints;}
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
