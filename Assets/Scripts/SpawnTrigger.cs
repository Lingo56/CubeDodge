using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public SpawnControl spawnControl;
    public DifficultyControl difficultyControl;
    int difficultyLevel;

    private void OnTriggerEnter(Collider collision)
    {
        difficultyControl.SetDifficulty();
        difficultyLevel = difficultyControl.GetDifficulty();

        if (collision.gameObject.tag == "TileTrigger")
        {
            switch(difficultyLevel){
                case 0:
                    spawnControl.SpawnEasyTiles();
                    break;
                case 1:
                    spawnControl.SpawnMediumTiles();
                    break;
                case 2:
                    spawnControl.SpawnHardTiles();
                    break;
            }
        }
    }
}
