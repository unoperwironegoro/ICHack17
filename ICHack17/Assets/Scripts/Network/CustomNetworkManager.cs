﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {
    public static GameObject[] GetPlayers() {
        return GameObject.FindGameObjectsWithTag("Mouse");
    }
}