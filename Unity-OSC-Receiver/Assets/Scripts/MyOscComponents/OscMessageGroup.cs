﻿using System.Collections.Generic;
using System.Linq;
using extOSC;
using Unity.VisualScripting;
using UnityEngine;

namespace MyOscComponents
{
    public class OscMessageGroup : OscTriggeredEffect
    {
        [SerializeField] private OscTriggeredEffect[] effects;
        [SerializeField] private bool getChildrenOnAwake;

        private void Awake()
        {
            if (getChildrenOnAwake) effects = GetComponentsInChildren<OscTriggeredEffect>();
        }
        
        public override void HandleValue(OSCValue val)
        {
            foreach (var fx in effects.Except(this.Yield()))
            {
                fx.HandleValue(val);
            }
        }
    }
}