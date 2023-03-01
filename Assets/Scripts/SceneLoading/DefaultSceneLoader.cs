///////////////////////////////////////////////////////////
///// Creator : Chris Johnson 
///// Date Created : 04/02/2023
///// Purpose : Load scene 0 on editor play
///// https://stackoverflow.com/questions/35586103/unity3d-load-a-specific-scene-on-play-mode
/////doesnt work with data persistence - results in error // data persistence manager duplication possible and null returns
///////////////////////////////////////////////////////////
//#if UNITY_EDITOR
//using UnityEditor;
//using UnityEditor.SceneManagement;

//[InitializeOnLoadAttribute]
//public static class DefaultSceneLoader
//{
//    static DefaultSceneLoader()
//    {
//        EditorApplication.playModeStateChanged += LoadDefaultScene;
//    }

//    static void LoadDefaultScene(PlayModeStateChange state)
//    {
//        if (state == PlayModeStateChange.ExitingEditMode)
//        {
//            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
//        }

//        if (state == PlayModeStateChange.EnteredPlayMode)
//        {
//            EditorSceneManager.LoadScene(0);
//        }
//    }
//}
//#endif