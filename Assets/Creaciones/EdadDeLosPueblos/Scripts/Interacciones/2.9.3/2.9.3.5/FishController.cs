using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace I2935
{
    [System.Serializable]
    public class Fish
    {
        [Header(">>>     Fish Speed")]
        public float minSpeed;
        public float maxSpeed;

        [HideInInspector]
        public float speed;

        [Header(">>>     Fish Sprites"), Space(15)]
        public Sprite normalSprite;
        public Sprite highlighted;
        public Sprite pressed;
        public Sprite selected;
        public Sprite disabled;

        [Header(">>>     Fish Events"), Space(15)]
        public UnityEvent OnSelectFish;
    }

    public class FishController : MonoBehaviour
    {
        public Fish[] fishes;

        public void SelectFish(Image imageTarget, Button buttonTarget, int fishTarget, float speed)
        {
            fishes[fishTarget].speed = speed;

            imageTarget.sprite = fishes[fishTarget].normalSprite;

            SpriteState targetState = new SpriteState();

            targetState.highlightedSprite = fishes[fishTarget].highlighted;
            buttonTarget.spriteState = targetState;

            targetState.pressedSprite = fishes[fishTarget].pressed;
            buttonTarget.spriteState = targetState;

            targetState.selectedSprite = fishes[fishTarget].selected;
            buttonTarget.spriteState = targetState;

            targetState.disabledSprite = fishes[fishTarget].disabled;
            buttonTarget.spriteState = targetState;
        }
    }

}