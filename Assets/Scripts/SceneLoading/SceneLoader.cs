/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 28/01/2023
/// Purpose : Script for loading other scenes
/////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private class LoadingMonoBehaviour : MonoBehaviour { } //dummy class that allows us to start a coroutine

    //names of scenes that exist
    public enum Scene {
        MenuScene,
        DenBedroom,
        LoadingScene,
        HouseScene,
        DenScene,
        Testing_Chris
    }

    private static Action aOnLoaderCallback;
    private static AsyncOperation aAsyncOperation;

    /// <summary>
    /// load a new scene
    /// </summary>
    /// <param scene to load="a_sScene"></param>
    public static void Load(Scene a_sScene)
    {
        //set the action to load the desired scene
        aOnLoaderCallback = () =>
        {
            GameObject goLoadingGameObjectt = new GameObject("Loading GameObejct");
            goLoadingGameObjectt.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(a_sScene));
            //LoadSceneAsync(a_sScene); //load the given scene
        };

        SceneManager.LoadScene(Scene.LoadingScene.ToString()); //load the loadingScene

    }

    /// <summary>
    /// load scene in background
    /// </summary>
    /// <param scene to load="a_sScene"></param>
    /// <returns></returns>
    static IEnumerator LoadSceneAsync(Scene a_sScene)
    {
        yield return null; //wait frame

        aAsyncOperation = SceneManager.LoadSceneAsync(a_sScene.ToString()); //start loading

        while (!aAsyncOperation.isDone == false) //wait until load is done
        {
            yield return null; //wait frame
        }
    }

    /// <summary>
    /// if an async operation exists return the progress of it
    /// </summary>
    /// <returns></returns>
    public static float GetLoadingProgress()
    {
        return aAsyncOperation.progress;


        //if (aAsyncOperation != null)
        //{
        //    return aAsyncOperation.progress; //return the loading progress
        //}
        //else
        //{
        //    return 1f; //else return 1
        //}
    }


    /// <summary>
    /// allows the scene to refresh between loading
    /// </summary>
    public static void loaderCallback()
    {
        //loader call back to load desired scene
        if (aOnLoaderCallback != null)
        {
            aOnLoaderCallback();
            aOnLoaderCallback = null;
        }
    }

    
}
