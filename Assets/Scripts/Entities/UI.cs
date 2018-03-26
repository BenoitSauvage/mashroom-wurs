using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Slider progress;

    float percentage = .5f;

    public void SelectUnitPercentage (float _value) {
        percentage = _value;
    }

    public float GetSelectedPercentage () {
        return percentage;
    }

    public void UpdateSlider (float _ai, float _player) {
        progress.maxValue = _ai + _player;
        progress.value = _player;
    }

}
