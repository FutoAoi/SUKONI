using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text _bullets;
    [SerializeField] WeponController _controller;
    [SerializeField] TMP_Text _maxBullets;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _bullets.text = $"{_controller.RemainBullets}";
        _maxBullets.text = $"{_controller.MaxBullets}";
    }
}
