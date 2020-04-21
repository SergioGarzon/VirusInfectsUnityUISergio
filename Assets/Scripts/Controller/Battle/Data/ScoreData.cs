using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ScoreData : ScriptableObject
{
    [SerializeField] private int initialScore=0;
    //score del nivel, vida
    [SerializeField] private int initialShootingPoints=0;
    //puntos a cargarse para ataques especiales
    [SerializeField] private int initialGamePoints = 0;
    //puntos totales del juego

    [NonSerialized] public int xp;
    [NonSerialized] public int mLife;
    [NonSerialized] public int hLife;
    [NonSerialized] public int shootingPoints;
    [NonSerialized] public int mana;

    public void UpdateScore() {
        xp += initialScore;
        initialScore = xp;
    }
    public void UpdatePoints(int multiplier) {
        shootingPoints = initialShootingPoints;
    }
    public void UpdateGamePoints(int multiplier) {
        mana += initialGamePoints * multiplier;
    }

}
[Serializable]
public class SerializableScoreData {
    private int xp;
}
[Serializable]
public class SerializableShootingPoints {
    private int shootingPoints;
}
[Serializable]
public class SerializableGamePoints {
    private int mana;
}
public class SerializableMagoLife {
    private int magoLife;
}
public class SerializableHackerLife {
    private int hackerLife;
}

public class GameData : ScriptableObject
{
    [SerializeField] private State currentState;
    [SerializeField] private State enemysDamagePoints;

    [NonSerialized] public State actualState;
    //para cambiar de estado. Guarda el estado actual 
    [NonSerialized] public State enemyDamage;
    //cuenta los virus muertos

    public void SaveState()
    {
        actualState = currentState;
    }
    public void Damage()
    {
        enemyDamage = enemysDamagePoints;
    }
}
