using Game.BreakoutGame;
using UnityEngine;
using Xunit;
using static GameTests.Utils;

namespace GameTests
{
    public class DefaultBounceSurfaceTests
    {
        [Fact]
        void direction_changes_when_ball_hits_object()
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
