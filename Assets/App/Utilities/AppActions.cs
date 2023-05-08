// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Extensions;
using UnityEngine;

/// <summary>
/// This MonoBehaviour contains application wide actions that can be accessed 
/// via public methods. This can be used for handling events within the Inspector
/// window, such as with the MRTK's speech input handlers.
/// </summary>
/// <summary>
/// この MonoBehaviour には、public メソッドでアクセス可能なアプリケーション全体のアクションが含まれています。
/// これは、MRTKの音声入力ハンドラなど、Inspectorウィンドウ内のイベントを処理するために使用することができます。
/// </summary>
public class AppActions : MonoBehaviour
{   // AppSettingsHideOperation：情報なし
    AppSettingsHideOperation _interfaceHide = null;

    #region Public Functions
    /// <summary>
    /// Request that this component hides the app's interface. This component will only
    /// manage one hide request at a time. 
    /// このコンポーネントがアプリのインターフェイスを非表示にすることを要求する。
    /// このコンポーネントは、一度に1つの非表示要求を管理するだけです。
    /// </summary>
    public void HideInterface()
    {   //19行目のでnullが入っているのであれば、デフォでif内の処理を実行する？
        if (_interfaceHide == null)
        {
            _interfaceHide = AppServices.AppSettingsService.HideInterface();
        }
    }

    /// <summary>
    /// Request that this component shows the app's interface. This component will only
    /// manage one hide request at a time. 
    /// このコンポーネントがアプリのインターフェイスを表示するようリクエストします。
    /// このコンポーネントは、一度に1つの非表示要求を管理するだけです。
    /// </summary>
    public void ShowInterface()
    {   //29行目実行していればif実行？
        if (_interfaceHide != null)
        {
            _interfaceHide.Cancel();
            _interfaceHide = null;
        }
    }

    /// <summary>
    /// Quit the current application.
    /// 現在のアプリケーションを終了する。
    /// </summary>
    public void QuitApplication()
    {   //339行目へ
        QuitApplicationWorker();
    }

    /// <summary>
    /// Set pointer to None
    /// ポインターをNoneに設定する
    /// </summary>
    public void SetPointerMode_None()
    {
        AppServices.PointerStateService.Mode = PointerMode.None;
    }

    /// <summary>
    /// mmSet pointer to ClipBar
    /// mmClipBar へのポインタを設定する。
    /// </suary>
    public void SetPointerMode_ClipBar()
    {
        AppServices.PointerStateService.Mode = PointerMode.ClipBar;
    }

    /// <summary>
    /// Set pointer to Delete
    /// ポインターをDeleteに設定する
    /// </summary>
    public void SetPointerMode_Delete()
    {
        AppServices.PointerStateService.Mode = PointerMode.Delete;
    }

    /// <summary>
    /// Set pointer to Explode
    /// ポインターを「Explode」に設定する
    /// </summary>
    public void SetPointerMode_Explode()
    {
        AppServices.PointerStateService.Mode = PointerMode.Explode;
    }

    /// <summary>
    /// Set pointer to Manipulate
    /// ポインターをManipulateに設定する
    /// </summary>
    public void SetPointerMode_Manipulate()
    {
        AppServices.PointerStateService.Mode = PointerMode.Manipulate;
    }

    /// <summary>
    /// Set pointer to ManipulatePiece
    /// ManipulatePieceへのポインタを設定する
    /// </summary>
    public void SetPointerMode_ManipulatePiece()
    {
        AppServices.PointerStateService.Mode = PointerMode.ManipulatePiece;
    }

    /// <summary>
    /// Set pointer to Material
    /// ポインターを「素材」に設定する
    /// </summary>
    public void SetPointerMode_Material(RemoteMaterial material)
    {
        AppServices.PointerStateService.SetModeWithData(PointerMode.Material, material);
    }

    /// <summary>
    /// Set pointer to Reset
    /// ポインターをリセットに設定する
    /// </summary>
    public void SetPointerMode_Reset()
    {
        AppServices.PointerStateService.Mode = PointerMode.Reset;
    }

    /// <summary>
    /// Reload the app settings file.
    /// アプリの設定ファイルを再読み込みします。
    /// </summary>
    public void ReloadAppSettings()
    {   //
        AppServices.AppSettingsService.Reload();
    }

    /// <summary>
    /// Should the local user's avatar be shown
    /// ローカルユーザーのアバターを表示するかどうか
    /// </summary>
    public void ShowLocalUserAvatar()
    {   //var:型推論　ここで使う目的は？
        var settings = AppServices.SharingService.AvatarSettings;
        settings.ShowCurrent = true;
        AppServices.SharingService.AvatarSettings = settings;
    }

    /// <summary>
    /// Should the local user's avatar be shown
    /// ローカルユーザーのアバターを表示させるかどうか
    /// </summary>
    public void HideLocalUserAvatar()
    {
        var settings = AppServices.SharingService.AvatarSettings;
        settings.ShowCurrent = false;
        AppServices.SharingService.AvatarSettings = settings;
    }

    /// <summary>
    /// Should co-located avatars be displayed
    /// アバターを表示させるかどうか
    /// </summary>
    public void ShowCoLocatedAvatars()
    {
        var settings = AppServices.SharingService.AvatarSettings;
        settings.ShowCoLocated = true;
        AppServices.SharingService.AvatarSettings = settings;
    }

    /// <summary>
    /// Should co-located avatars be displayed
    /// アバターを表示させるかどうか
    /// </summary>
    public void HideCoLocatedAvatars()
    {
        var settings = AppServices.SharingService.AvatarSettings;
        settings.ShowCoLocated = false;
        AppServices.SharingService.AvatarSettings = settings;
    }

    /// <summary>
    /// Should none co-located avatars be displayed
    /// アバターは1つも表示させないべきか
    /// </summary>
    public void ShowRemoteAvatars()
    {
        var settings = AppServices.SharingService.AvatarSettings;
        settings.ShowRemote = true;
        AppServices.SharingService.AvatarSettings = settings;
    }

    /// <summary>
    /// Should none co-located avatars be displayed
    /// アバターは1つも表示させないべきか
    /// </summary>
    public void HideRemoteAvatars()
    {
        var settings = AppServices.SharingService.AvatarSettings;
        settings.ShowRemote = false;
        AppServices.SharingService.AvatarSettings = settings;
    }

    /// <summary>
    /// Should avatar joints be shown
    /// アバタージョイントを表示するべきか
    /// </summary>
    public void ShowAvatarJoints()
    {
        var settings = AppServices.SharingService.AvatarSettings;
        settings.ShowDebugJoints = true;
        AppServices.SharingService.AvatarSettings = settings;

        if (!Application.isEditor)
        {//
            var handTrackingProfile = CoreServices.InputSystem?.InputSystemProfile?.HandTrackingProfile;
            handTrackingProfile.EnableHandJointVisualization = true;
            handTrackingProfile.HandJointVisualizationModes = Microsoft.MixedReality.Toolkit.Utilities.SupportedApplicationModes.Player;
        }
    }

    /// <summary>
    /// Should avatar joints be hidden
    /// アバタージョイントは非表示にすべき
    /// </summary>
    public void HideAvatarJoints()
    {
        var settings = AppServices.SharingService.AvatarSettings;
        settings.ShowDebugJoints = false;
        AppServices.SharingService.AvatarSettings = settings;

        if (!Application.isEditor)
        {
            var handTrackingProfile = CoreServices.InputSystem?.InputSystemProfile?.HandTrackingProfile;
            handTrackingProfile.EnableHandJointVisualization = false;
            handTrackingProfile.HandJointVisualizationModes = Microsoft.MixedReality.Toolkit.Utilities.SupportedApplicationModes.Editor;
        }
    }

    /// <summary>
    /// Show all avatar name plates
    /// すべてのアバターネームプレートを表示する
    /// </summary>
    public void ShowAvatarNamePlates()
    {
        var settings = AppServices.SharingService.AvatarSettings;
        settings.ShowNamePlates = true;
        AppServices.SharingService.AvatarSettings = settings;
    }

    /// <summary>
    /// Hide all avatar name plates
    /// すべてのアバターネームプレートを非表示にする
    /// </summary>
    public void HideAvatarNamePlates()
    {
        var settings = AppServices.SharingService.AvatarSettings;
        settings.ShowNamePlates = false;
        AppServices.SharingService.AvatarSettings = settings;
    }

    /// <summary>
    /// Show all possible avatars and their joints
    /// 可能なすべてのアバターとそのジョイントを表示する
    /// </summary>
    public void DebugAvatars()
    {
        ShowLocalUserAvatar();
        ShowCoLocatedAvatars();
        ShowAvatarJoints();
        ShowRemoteAvatars();
        ShowAvatarNamePlates();
    }

    /// <summary>
    /// Only show none co-located avatars, and no joints
    /// 同位置のアバターは表示されず、ジョイントも表示されません。
    /// </summary>
    public void ResetAvatars()
    {
        HideLocalUserAvatar();
        HideCoLocatedAvatars();
        HideAvatarJoints();
        ShowRemoteAvatars();
        ShowAvatarNamePlates();
    }

    /// <summary>
    /// Enables all MovableObjectDebuggers
    /// すべてのMovableObjectDebuggersを有効にする。
    /// </summary>
    public void ShowAnchorDebuggers()
    {
        SetAnchorDebuggerVisibility(true);
    }

    /// <summary>
    /// Enables all MovableObjectDebuggers
    /// すべてのMovableObjectDebuggersを有効にする。
    /// </summary>
    public void HideAnchorDebuggers()
    {
        SetAnchorDebuggerVisibility(false);
    }

    /// <summary>
    /// Enabled all MovableObjectDebuggers
    /// すべてのMovableObjectDebuggersを有効にする。
    /// </summary>
    public void SetAnchorDebuggerVisibility(bool visible)
    {
        var items = GameObject.FindObjectsOfType<MovableAnchorDebugger>();
        int count = items?.Length ?? 0;
        for (int i = 0; i < count; i++)
        {
            items[i].enabled = visible;
        }
    }

    /// <summary>
    /// Show a dialog that allows the user to change the remote rendering pose mode.
    /// リモートレンダリングのポーズモードを変更するためのダイアログを表示します。
    /// </summary>
    public void ShowPoseModeDialog()
    {
        SetRemoteRenderingPoseMode();
    }
    #endregion Public Functions

    #region Private Functions
    /// <summary>
    /// The function that actually quits the application
    /// 実際にアプリケーションを終了させる関数
    /// </summary>
    private bool quitting = false;
    private async void QuitApplicationWorker()
    {
        if (!quitting)
        {
            quitting = true;
            bool quit = await AppServices.AppNotificationService.ShowDialog(new DialogOptions()
            {
                Title = "Quit Application",
                Message = "Quitting the application will not stop your remote session, however your model placements will be lost.\n\nDo you really want to quit the application?"
            }) == AppDialog.AppDialogResult.Ok;

            if (quit)
            {
                Debug.LogFormat(LogType.Log, LogOption.NoStacktrace, null, "{0}", "Quitting application per request...");
                Application.Quit();
            }

            quitting = false;
        }
    }

    private bool settingPoseMode = false;
    private async void SetRemoteRenderingPoseMode()
    {
        if (!settingPoseMode)
        {
            if (AppServices.RemoteRendering.Status != RemoteRenderingServiceStatus.SessionReadyAndConnected ||
                AppServices.RemoteRendering?.PrimaryMachine == null)
            {
                await AppServices.AppNotificationService.ShowDialog(new DialogOptions()
                {
                    Title = "Set Pose Mode",
                    Message = "We're unable to a set pose mode when there is no remote rendering session. Please start a remote rendering session, and try again.",
                    Buttons = AppDialog.AppDialogButtons.Ok
                });
                return;
            }

            try
            {
                settingPoseMode = true;
                var result = await AppServices.AppNotificationService.ShowDialog(new DialogOptions()
                {
                    Title = "Set Pose Mode",
                    Message = "Select which head pose you want to use when connected to a remote rendering session. What head pose do you want to use to stabilize local content?",
                    Buttons = AppDialog.AppDialogButtons.All,
                    OKLabel = "Local",
                    NoLabel = "Remote",
                    CancelLabel = "Cancel"
                });

                if (result != AppDialog.AppDialogResult.Cancel)
                {
                    Microsoft.Azure.RemoteRendering.PoseMode mode = result == AppDialog.AppDialogResult.Ok ?
                        Microsoft.Azure.RemoteRendering.PoseMode.Local :
                        Microsoft.Azure.RemoteRendering.PoseMode.Remote;

                    if (AppServices.RemoteRendering?.PrimaryMachine != null)
                    {
                        AppServices.RemoteRendering.PrimaryMachine.PoseMode = mode;
                    }
                }
            }
            finally
            {
                settingPoseMode = false;
            }
        }
    }
    #endregion Private Functions
}
