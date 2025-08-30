using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Analytics;

public class FirebaseAnalysisManager : GoogleAdsManagerAbstract
{
    [SerializeField] protected Firebase.FirebaseApp app;

    protected override void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                app = FirebaseApp.DefaultInstance;
                // Debug.Log("Firebase Initialized");
            }
            //else
            //{
            //    Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            //}
        });
    }
}
