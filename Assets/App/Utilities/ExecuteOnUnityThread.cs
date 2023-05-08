// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ExecuteOnUnityThread : MonoBehaviour
{
    private static CancellationTokenSource applicationTokenSource;//CancellationTokenに対して、キャンセルするように通達する。
    public static CancellationToken ApplicationToken => applicationTokenSource.Token;//.Token：この CancellationToken に関連付けられている CancellationTokenSource を取得する。

    private static Queue<Action> actions = new Queue<Action>();//action型の要素のFIFOクラスQueue()をクラス名actionで宣言する

    private static ExecuteOnUnityThread instance;

    public void Awake()//最初に実行
    {
        if (instance != null)//instanceがnullで無いなら実行
        {
            Destroy(this);//このインスタンス自身を削除する
        } else
        {
            instance = this;//instanceにこのインスタンス自身を入れる
            applicationTokenSource = new CancellationTokenSource();//変数applicationTokenSourceを新しいCancellationTokenSourceとして宣言する
        }
    }

    public void OnDestroy()//インスタンス削除時に実行
    {
        applicationTokenSource?.Cancel();//キャンセル要求を伝える
    }

    public void Update()//毎フレームごとに実行
    {
        lock (actions)//actionsを排他処理
        {
            while(actions.Count > 0)//Queue<Action>のタスク数が0より多ければtrue whileのためtrueの限りループを実行
            {
                var action = actions.Dequeue();//Queue() の先頭にあるオブジェクトを削除し、返します。
                action?.Invoke();//メインスレッドへアクションを実行依頼　型名?でnull許容型
            }
        }
    }

    public static void Enqueue(Action action)
    {
        lock(actions)
        {
            actions.Enqueue(action);
        }
    }
}
