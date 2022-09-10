using System;
using Unity.Mathematics;
using UnityEngine;


/* Controls the player movement and player health */
public class Player : MonoBehaviour
{
    [SerializeField] private HealtController  _healtController;
    [SerializeField] private MovementController _movementController;

    private void Awake()
    {
        _movementController.Configure(new RegularMovable(), new DrunkMovable());
    }
    public void Reset()
    {
        _healtController.Reset();
        _movementController.Reset();
    }
}
