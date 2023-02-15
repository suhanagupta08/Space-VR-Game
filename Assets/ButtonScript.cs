using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject blockPrefab;
    public Transform blockSpawnPoint;

    void Start()
    {
        // Get a reference to the button component
        Button button = GetComponent<Button>();

        // Add a listener for when the button is pressed
        button.onClick.AddListener(SpawnBlock);
    }

    void SpawnBlock()
    {
        // Spawn a new block at the spawn point
        GameObject block = Instantiate(blockPrefab, blockSpawnPoint.position, Quaternion.identity);
    }
}

