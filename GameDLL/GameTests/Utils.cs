using UnityEngine;
using Xunit;

namespace GameTests
{
    class Utils
    {
        /// <summary>
        /// Compare two Vector3 values, ignoring floating point error.
        /// </summary>
        public static void AssertEqual(Vector3 expected, Vector3 actual, float tolerance = 0.0000001f)
        {
            Assert.InRange(actual.x, expected.x - tolerance, expected.x + tolerance);
            Assert.InRange(actual.y, expected.y - tolerance, expected.y + tolerance);
            Assert.InRange(actual.z, expected.z - tolerance, expected.z + tolerance);
        }
    }
}
