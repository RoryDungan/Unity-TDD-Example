using Game.Unity;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestTools.Utils;
using GameManagerSingleton = Game.BreakoutGame.GameManagerSingleton;

public class IntegrationTests
{
    /// <summary>
    /// Helper function to wait for the specified fixed update time.
    /// </summary>
    private IEnumerator WaitForFixedTime(float seconds)
    {
        var startTime = Time.fixedTime;
        while (Time.fixedTime < startTime + seconds)
        {
            yield return new WaitForFixedUpdate();
        }
    }

    private GameObject CreateTestBall()
    {
        var ball = new GameObject("Ball");
        ball.AddComponent<Ball>();
        ball.AddComponent<CircleCollider2D>();
        var rb = ball.AddComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.useFullKinematicContacts = true;

        ball.transform.position = Vector3.zero;

        return ball;
    }

    [TearDown]
    public void ResetSingletons()
    {
        // Reset score
        GameManagerSingleton.Instance.Score = 0;
    }


    [UnityTest]
    public IEnumerator ball_moves_3_units_per_second()
    {
        var ball = CreateTestBall();

        try
        {
            yield return WaitForFixedTime(1f);

            // Allow for 1 frame of error.
            var equalityComparer = new Vector3EqualityComparer(0.01f);

            Assert.That(
                ball.transform.position,
                Is.EqualTo(new Vector3(0f, 3f)).Using(equalityComparer)
            );
        }
        finally
        {
            Object.Destroy(ball);
        }
    }

    [UnityTest]
    public IEnumerator smashing_block_adds_to_score()
    {
        var block = new GameObject("Block");
        block.AddComponent<DefaultBounceSurface>();
        block.AddComponent<BoxCollider2D>();
        block.AddComponent<Block>();
        block.transform.position = new Vector3(0f, 3f);

        var ball = CreateTestBall();

        try
        {
            Assert.That(GameManagerSingleton.Instance.Score, Is.EqualTo(0));

            yield return new WaitForSeconds(1f);

            Assert.That(GameManagerSingleton.Instance.Score, Is.EqualTo(1));
        }
        finally
        {
            Object.Destroy(ball);
            Object.Destroy(block);
        }
    }

    [UnityTest]
    public IEnumerator block_smashes_on_touch()
    {
        // Arrange
        var block = new GameObject("Block");
        block.AddComponent<DefaultBounceSurface>();
        block.AddComponent<BoxCollider2D>();
        block.AddComponent<Block>();

        block.transform.position = new Vector3(0f, 3f, 0f);

        var ball = new GameObject("Ball");
        ball.AddComponent<Ball>();
        ball.AddComponent<CircleCollider2D>();
        var ballRb = ball.AddComponent<Rigidbody2D>();
        ballRb.bodyType = RigidbodyType2D.Kinematic;
        ballRb.useFullKinematicContacts = true;
        ball.transform.position = Vector3.zero;

        try
        {
            // Act
            yield return new WaitForSeconds(1f);

            // Assert
            Assert.True(block == null);
        }
        finally
        {
            // cleanup
            if (block)
            {
                Object.Destroy(block);
            }
            Object.Destroy(ball);
        }

        yield return null;
    }
}
