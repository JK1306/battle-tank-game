﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : SingletonBehaviour<Enemy>
{
    void Start()
    {
        Player.Instance.display();
    }
}
