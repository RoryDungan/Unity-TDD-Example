using NUnit.Framework;
using UnityEngine;

namespace GameTests
{
    class Utils
    {
        /// <summary>
        /// Compare two Vector3 values, with a tolerance to account for floating point 
        /// error.
        /// </summary>
        public static void AssertEqual(Vector3 expected, Vector3 actual, float tolerance = 0.0000001f)
        {
            Assert.That(actual.x, Is.InRange(expected.x - tolerance, expected.x + tolerance));
            Assert.That(actual.y, Is.InRange(expected.y - tolerance, expected.y + tolerance));
            Assert.That(actual.z, Is.InRange(expected.z - tolerance, expected.z + tolerance));
        }
    }
}
