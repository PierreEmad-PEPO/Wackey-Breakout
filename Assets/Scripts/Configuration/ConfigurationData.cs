using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigurationData
{
    private string configurationFileName = "ConfigurationData.csv";
    private StreamReader streamReader = null;

    private float paddleMoveUnitsPerSecond = 10f;
    private float ballImpulseForce = 10f;
    private int ballLifeTime = 10;
    private int spawnNextBallTimeMin = 5;
    private int spawnNextBallTimeMax = 10;
    private int ballsNumberPerGame = 5;
    private int standardBlockPoints = 5;
    private int effectBlockPoints = 8;
    private int effectBlockDuration = 3;

    public ConfigurationData(DifficultyLevel difficulty)
    {

        switch (difficulty)
        {
            case DifficultyLevel.Easy:
                configurationFileName = "EasyConfigurationData.csv";
                break;
            case DifficultyLevel.Medium:
                configurationFileName = "MediumConfigurationData.csv";
                break;
            case DifficultyLevel.Hard:
                configurationFileName = "HardConfigurationData.csv";
                break;
        }

        try
        {
            streamReader = File.OpenText(
                Path.Combine(Application.streamingAssetsPath , configurationFileName)
                );

            string names = streamReader.ReadLine();
            string[] values = streamReader.ReadLine().Split(',');
            AssignValues( values );
        }
        catch (Exception ex) 
        {
            Debug.Log(ex.Message);
        }
        finally
        {
            streamReader?.Close();
        }
    }

    private void AssignValues(string[] values)
    {
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeTime = Int32.Parse(values[2]);
        spawnNextBallTimeMin = Int32.Parse(values[3]);
        spawnNextBallTimeMax = Int32.Parse(values[4]);
        ballsNumberPerGame = Int32.Parse(values[5]);
        standardBlockPoints = Int32.Parse(values[6]);
        effectBlockPoints = Int32.Parse(values[7]);
        effectBlockDuration = Int32.Parse(values[8]);
    }


    public float PaddleMoveUnitsPerSecond { get { return paddleMoveUnitsPerSecond; } }
    public float BallImpulseForce { get { return ballImpulseForce; } }
    public int BallLifeTime { get { return ballLifeTime; } }
    public int SpawnNextBallTimeMin { get { return spawnNextBallTimeMax; } }
    public int SpawnNextBallTimeMax { get { return spawnNextBallTimeMin; } }
    public int BallsNumberPerGame { get { return ballsNumberPerGame; } }
    public int StandardBlockPoints { get {  return standardBlockPoints; } }
    public int EffectBlockPoints { get { return effectBlockPoints; } }
    public int EffectBlockDuration { get {  return effectBlockDuration; } }
}
