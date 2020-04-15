using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderEnergy : MonoBehaviour
{
    public Slider energyPlayerCharlie;
    public Slider energyPlayerAtif;
    public Slider energyVirusOne;
    public Slider energyVirusTwo;
    public ScoreData score;

    void Start()
    {
        this.energyPlayerCharlie.value = score.hLife;
        this.energyPlayerAtif.value = score.mLife;
        this.energyVirusOne.value = BattleMachine.lifeBattleVirus1;
        this.energyVirusTwo.value = BattleMachine.lifeBattleVirus2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
