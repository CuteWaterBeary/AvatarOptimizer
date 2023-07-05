using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRC.SDK3.Avatars.Components;

namespace Anatawa12.ApplyOnPlay
{
    internal class ApplyOnPlayCaller : IProcessSceneWithReport
    {
        public int callbackOrder => 0;

        public void OnProcessScene(Scene scene, BuildReport report)
        {
            var components = scene.GetRootGameObjects()
                .SelectMany(x => x.GetComponentsInChildren<VRCAvatarDescriptor>(true)).ToArray();

            var callbacks = ApplyOnPlayCallbackRegistry.GetCallbacks();

            foreach (var vrcAvatarDescriptor in components)
            {
                ProcessAvatar(vrcAvatarDescriptor.gameObject, callbacks);
            }
        }

        private bool ProcessAvatar(GameObject avatarGameObject, IApplyOnPlayCallback[] callbacks)
        {
            foreach (var applyOnPlayCallback in callbacks)
            {
                try
                {
                    if (!applyOnPlayCallback.ApplyOnPlay(avatarGameObject))
                    {
                        var message = $"The ApplyOnPlay for {avatarGameObject} was aborted because " +
                                      "'{applyOnPlayCallback.GetType().Name}' reported a failure.";
                        Debug.LogError(message);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    var message = $"The ApplyOnPlay for {avatarGameObject} was aborted because " +
                                  "'{applyOnPlayCallback.GetType().Name}' threw an exception.";
                    Debug.LogError(message);
                    Debug.LogException(ex);
                    return false;
                }
            }

            return true;
        }
    }
}