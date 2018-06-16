using Game.BreakoutGame;
using NUnit.Framework;
using UnityEngine;
using static GameTests.Utils;

namespace GameTests
{
    public class DefaultBounceSurfaceTests
    {
        [Test]
        public void direction_changes_when_ball_hits_object()
        {
            var testObject = new DefaultBounceSurface();

            var initialDirection = new Vector3(0f, 1f, 0f);
            var surfaceNormal = new Vector3(1f, -1f, 0f).normalized;
            var expectedDirection = new Vector3(1f, 0f, 0f);

            var actual = testObject.Bounce(Vector3.zero, initialDirection, surfaceNormal);

            AssertEqual(expectedDirection, actual);
        }
    }
}
