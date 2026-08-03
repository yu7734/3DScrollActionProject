using UnityEngine;

public interface IPlayerState
{
    //ステートに入った時実行される関数
    void Enter();

    // 毎フレーム実行される処理
    void Update();
    // ステートから出る時に一度だけ実行される処理
    void Exit();
}
