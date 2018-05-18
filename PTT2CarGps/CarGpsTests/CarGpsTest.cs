using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTT2CarGps;

namespace CarGpsTests
{
    [TestClass]
    public class CarGpsTests
    {
        [TestMethod]
        public void TestPositionAdding()
        {
            GPSform form = new GPSform();
            Point[] positions = { new Point(0, 0), new Point(1, 2), new Point(5, 2) };
            form.AddPositions(positions);
            Assert.AreEqual(form.signatureTrails[1][0], positions[1]);
        }
        [TestMethod]
        public void TestMultiplePositionAdding()
        {
            GPSform form = new GPSform();
            Point[] positions1 = { new Point(0, 0), new Point(1, 1), new Point(2, 2) };
            form.AddPositions(positions1);
            Point[] positions2 = { new Point(0, 1), new Point(3, 2)};
            form.AddPositions(positions2);
            Point[] positions3 = { new Point(1, 2), new Point(5, 3), new Point(3, 3), new Point(3, 3) };
            form.AddPositions(positions3);
            //Test if adding null doesn't change the data
            form.AddPositions(null);

            //Test if newest value get added at index zero of the array
            Assert.AreEqual(positions3[0], form.signatureTrails[0][0]);
            //Test if older values get shifted
            Assert.AreEqual(positions1[1], form.signatureTrails[1][2]);
            //Test if old position gets copied when there is no new position given
            Assert.AreEqual(form.signatureTrails[2][1], form.signatureTrails[2][2]);
            //Test if new trails get added when more points are given
            Assert.AreEqual(4, form.signatureTrails.Count);
            //Test if new trail value got saved in array
            Assert.AreEqual(positions3[3], form.signatureTrails[3][0]);
        }
    }
}
