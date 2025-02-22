﻿using extOSC;
using UnityEngine;

namespace MyOscComponents
{
    public class LightColorFX : OscAnimatedColorProp
    {
        [SerializeField] private Light light;

        protected override void OneTimeInit()
        {
            if (_wasInit) return;
            if (light == null) light = GetComponent<Light>();
            base.OneTimeInit();
        }
        
        protected override void PropSetterInternal(Color value)
        {
            light.color = value;
            prop = value;
        }

        protected override Color GetPropSourceValue() 
            => light == null ? default : light.color;
        

        protected override (bool success, Color value) ExtractValue(OSCValue val) => val.ExtractColor();
    }
}