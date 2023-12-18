using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using System;

public class DataCoins : MonoBehaviour
{
    public DatabaseReference Database;

    public GameObject ScoreElementos;
    public Transform score;


    //DatabaseReference refecence;
    private void InitializeFireBase()
    {
         }
    public Text scoreText;

    //private void Start()
    //{
    //    refecence = FirebaseDatabase.DefaultInstance.RootReference;
    //    FirebaseDatabase.DefaultInstance.GetReference("Count").ValueChanged += HandleUpdataScore;
    //}

    //public void HandleUpdataScore(object sender, ValueChangedEventArgs args)
    //{
    //    DataSnapshot snapshot = args.Snapshot;
    //    Debug.Log(snapshot.Value);
    //    scoreText.text = snapshot.Value.ToString();
    //}

    //public void UpdateScore()
    //{
    //    FirebaseDatabase.DefaultInstance.GetReference("Cunt").GetValueAsync().ContinueWith(task =>
    //    {
    //        if (task.IsFaulted)
    //        {
    //            Debug.LogError(task);
    //        }
    //        else if (task.IsCompleted)
    //        {
    //            DataSnapshot snapshot = task.Result;
    //            int value = int.Parse(Convert.ToString(snapshot.Value));
    //            value++;
    //            refecence.Child("Count").SetValueAsync(value);
    //        }
    //    });

    //}
}

