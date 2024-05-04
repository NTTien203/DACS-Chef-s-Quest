using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasProgress 
{
    public event EventHandler <onProgressEventArgs> OnProgress;
    public class onProgressEventArgs: EventArgs{
        public float progress;
    }
}
