using Game.Unity;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class IntegrationTests 
{
    [UnityTest]
    public IEnumerator ball_bounces_off_paddle()
    {
        var paddle = new GameObject();
        paddle.AddComponent<PaddleBounceSurface>();

        var ball = new GameObject();
        ball.AddComponent<Ball>();

        yield return new WaitForEndOfFrame();
    }
}
