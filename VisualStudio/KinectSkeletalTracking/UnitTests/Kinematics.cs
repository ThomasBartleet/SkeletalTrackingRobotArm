﻿using KinectSkeletalTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KinematicsTests
{
    [TestClass]
    public class InverseKinematicsTests
    {
        const double angleTolerance = 0.000000001;
        private static readonly Point3 neck = new Point3(9, 12, 10);
        private static readonly Point3 spine = new Point3(9, 8, 10);
        private static readonly Point3 shoulderL = new Point3(8, 10, 10);
        private static readonly Point3 shoulderR = new Point3(10, 10, 10);
        private static readonly Vector3 neckToSpine = Vector3.FromPoints(neck, spine);
        private static readonly Vector3 shoulderL2R = Vector3.FromPoints(shoulderL, shoulderR);
        private static readonly Vector3 shoulderR2L = Vector3.FromPoints(shoulderR, shoulderL);

        [TestClass]
        public class RightArm
        {

            [TestClass]
            public class ShoulderYaw
            {
                [TestMethod]
                public void Inline()
                {
                    Vector3 shoulderToElbow = new Vector3(1, 0, 0);
                    double yaw = InverseKinematics.GetShoulderYaw(neckToSpine, shoulderL2R, shoulderToElbow);

                    Assert.AreEqual(0, yaw, angleTolerance);
                }

                [TestMethod]
                public void ElbowPointingDown()
                {
                    Vector3 shoulderToElbow = new Vector3(0, -1, 0);
                    double yaw = InverseKinematics.GetShoulderYaw(neckToSpine, shoulderL2R, shoulderToElbow);

                    Assert.AreEqual(-90, yaw, angleTolerance);
                }

                [TestMethod]
                public void ElbowPointingForward()
                {
                    Vector3 shoulderToElbow = new Vector3(0, 0, -1);
                    double yaw = InverseKinematics.GetShoulderYaw(neckToSpine, shoulderL2R, shoulderToElbow);

                    Assert.AreEqual(0, yaw, angleTolerance);
                }

                [TestMethod]
                public void ElbowPointingUp()
                {
                    Vector3 shoulderToElbow = new Vector3(0, 1, 0);
                    double yaw = InverseKinematics.GetShoulderYaw(neckToSpine, shoulderL2R, shoulderToElbow);

                    Assert.AreEqual(90, yaw, angleTolerance);
                }
            }

            [TestClass]
            public class ShoulderPitch
            {
                [TestMethod]
                public void Inline()
                {
                    Vector3 shoulderToElbow = new Vector3(1, 0, 0);
                    double pitch = InverseKinematics.GetShoulderPitch(shoulderL2R, shoulderToElbow);

                    Assert.AreEqual(0, pitch, angleTolerance);
                }

                [TestMethod]
                public void ElbowPointingDown()
                {
                    Vector3 shoulderToElbow = new Vector3(0, -1, 0);
                    double pitch = InverseKinematics.GetShoulderPitch(shoulderL2R, shoulderToElbow);

                    Assert.AreEqual(-90, pitch, angleTolerance);
                }

                [TestMethod]
                public void ElbowPointingForward()
                {
                    Vector3 shoulderToElbow = new Vector3(0, 0, -1);
                    double pitch = InverseKinematics.GetShoulderPitch(shoulderL2R, shoulderToElbow);

                    Assert.AreEqual(-90, pitch, angleTolerance);
                }

                [TestMethod]
                public void ElbowPointingUp()
                {
                    Vector3 shoulderToElbow = new Vector3(0, 1, 0);
                    double pitch = InverseKinematics.GetShoulderPitch(shoulderL2R, shoulderToElbow);

                    Assert.AreEqual(-90, pitch, angleTolerance);
                }
            }

            [TestClass]
            public class ShoulderRoll
            {
                [TestClass]
                public class ElbowPointingSide
                {
                    private static readonly Point3 elbow = new Point3(11, 10, 10);

                    [TestMethod]
                    public void Inline()
                    {
                        Point3 wrist = new Point3(12, 10, 10);
                        double roll = InverseKinematics.GetShoulderRollRight(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(0, roll);
                    }

                    [TestMethod]
                    public void WristPointingDown()
                    {
                        Point3 wrist = new Point3(11, 9, 10);
                        double roll = InverseKinematics.GetShoulderRollRight(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(-90, roll, angleTolerance);
                    }

                    [TestMethod]
                    public void WristPointingForward()
                    {
                        Point3 wrist = new Point3(11, 10, 9);
                        double roll = InverseKinematics.GetShoulderRollRight(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(0, roll, angleTolerance);
                    }

                    [TestMethod]
                    public void WristPointingUp()
                    {
                        Point3 wrist = new Point3(11, 11, 10);
                        double roll = InverseKinematics.GetShoulderRollRight(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(90, roll, angleTolerance);
                    }
                }

                [TestClass]
                public class ElbowPointingDown
                {
                    private static readonly Point3 elbow = new Point3(10, 9, 10);

                    [TestMethod]
                    public void Inline()
                    {
                        Point3 wrist = new Point3(10, 8, 10);
                        double roll = InverseKinematics.GetShoulderRollRight(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(0, roll);
                    }

                    [TestMethod]
                    public void WristPointingForward()
                    {
                        Point3 wrist = new Point3(10, 9, 9);
                        double roll = InverseKinematics.GetShoulderRollRight(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(90, roll, angleTolerance);
                    }

                    [TestMethod]
                    public void WristPointingInside()
                    {
                        Point3 wrist = new Point3(9, 9, 10);
                        double roll = InverseKinematics.GetShoulderRollRight(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(0, roll, angleTolerance);
                    }
                }

                [TestClass]
                public class ElbowPointingForward
                {
                    private static readonly Point3 elbow = new Point3(10, 10, 9);

                    [TestMethod]
                    public void Inline()
                    {
                        Point3 wrist = new Point3(10, 10, 8);
                        double roll = InverseKinematics.GetShoulderRollRight(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(0, roll);
                    }

                    [TestMethod]
                    public void WristPointingDown()
                    {
                        Point3 wrist = new Point3(10, 9, 9);
                        double roll = InverseKinematics.GetShoulderRollRight(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(-90, roll, angleTolerance);
                    }

                    [TestMethod]
                    public void WristPointingInside()
                    {
                        Point3 wrist = new Point3(9, 10, 9);
                        double roll = InverseKinematics.GetShoulderRollRight(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(0, roll, angleTolerance);
                    }

                    [TestMethod]
                    public void WristPointingUp()
                    {
                        Point3 wrist = new Point3(10, 11, 9);
                        double roll = InverseKinematics.GetShoulderRollRight(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(90, roll, angleTolerance);
                    }
                }
            }

            [TestClass]
            public class ElbowPitch
            {
                private static readonly Vector3 shoulderToElbow = new Vector3(1, 0, 0);

                [TestMethod]
                public void Inline()
                {
                    Vector3 elbowToWrist = new Vector3(1, 0, 0);
                    double angle = InverseKinematics.GetElbowAngle(shoulderToElbow, elbowToWrist);

                    Assert.AreEqual(0, angle, angleTolerance);
                }

                [TestMethod]
                public void WristPointingDown()
                {
                    Vector3 elbowToWrist = new Vector3(0, 0, -1);
                    double angle = InverseKinematics.GetElbowAngle(shoulderToElbow, elbowToWrist);

                    Assert.AreEqual(-90, angle, angleTolerance);
                }

                [TestMethod]
                public void WristPointingForward()
                {
                    Vector3 elbowToWrist = new Vector3(0, 0, -1);
                    double angle = InverseKinematics.GetElbowAngle(shoulderToElbow, elbowToWrist);

                    Assert.AreEqual(-90, angle, angleTolerance);
                }

                [TestMethod]
                public void WristPointingUp()
                {
                    Vector3 elbowToWrist = new Vector3(0, 1, 0);
                    double angle = InverseKinematics.GetElbowAngle(shoulderToElbow, elbowToWrist);

                    Assert.AreEqual(-90, angle, angleTolerance);
                }
            }
        }


        [TestClass]
        public class LeftArm
        {
            [TestClass]
            public class ShoulderYaw
            {
                [TestMethod]
                public void Inline()
                {
                    Vector3 shoulderToElbow = new Vector3(-1, 0, 0);
                    double yaw = InverseKinematics.GetShoulderYaw(neckToSpine, shoulderR2L, shoulderToElbow);

                    Assert.AreEqual(0, yaw, angleTolerance);
                }

                [TestMethod]
                public void ElbowPointingDown()
                {
                    Vector3 shoulderToElbow = new Vector3(0, -1, 0);
                    double yaw = InverseKinematics.GetShoulderYaw(neckToSpine, shoulderR2L, shoulderToElbow);

                    Assert.AreEqual(-90, yaw, angleTolerance);
                }

                [TestMethod]
                public void ElbowPointingForward()
                {
                    Vector3 shoulderToElbow = new Vector3(0, 0, -1);
                    double yaw = InverseKinematics.GetShoulderYaw(neckToSpine, shoulderR2L, shoulderToElbow);

                    Assert.AreEqual(0, yaw, angleTolerance);
                }

                [TestMethod]
                public void ElbowPointingUp()
                {
                    Vector3 shoulderToElbow = new Vector3(0, 1, 0);
                    double yaw = InverseKinematics.GetShoulderYaw(neckToSpine, shoulderR2L, shoulderToElbow);

                    Assert.AreEqual(90, yaw, angleTolerance);
                }
            }

            [TestClass]
            public class ShoulderPitch
            {
                [TestMethod]
                public void Inline()
                {
                    Vector3 shoulderToElbow = new Vector3(-1, 0, 0);
                    double pitch = InverseKinematics.GetShoulderPitch(shoulderR2L, shoulderToElbow);

                    Assert.AreEqual(0, pitch, angleTolerance);
                }

                [TestMethod]
                public void ElbowPointingDown()
                {
                    Vector3 shoulderToElbow = new Vector3(0, -1, 0);
                    double pitch = InverseKinematics.GetShoulderPitch(shoulderR2L, shoulderToElbow);

                    Assert.AreEqual(-90, pitch, angleTolerance);
                }

                [TestMethod]
                public void ElbowPointingForward()
                {
                    Vector3 shoulderToElbow = new Vector3(0, 0, -1);
                    double pitch = InverseKinematics.GetShoulderPitch(shoulderR2L, shoulderToElbow);

                    Assert.AreEqual(-90, pitch, angleTolerance);
                }

                [TestMethod]
                public void ElbowPointingUp()
                {
                    Vector3 shoulderToElbow = new Vector3(0, 1, 0);
                    double pitch = InverseKinematics.GetShoulderPitch(shoulderR2L, shoulderToElbow);

                    Assert.AreEqual(-90, pitch, angleTolerance);
                }
            }

            [TestClass]
            public class ShoulderRoll
            {
                [TestClass]
                public class ElbowPointingSide
                {
                    private static readonly Point3 elbow = new Point3(7, 10, 10);

                    [TestMethod]
                    public void Inline()
                    {
                        Point3 wrist = new Point3(6, 10, 10);
                        double roll = InverseKinematics.GetShoulderRollLeft(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(0, roll);
                    }

                    [TestMethod]
                    public void WristPointingDown()
                    {
                        Point3 wrist = new Point3(7, 9, 10);
                        double roll = InverseKinematics.GetShoulderRollLeft(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(-90, roll, angleTolerance);
                    }

                    [TestMethod]
                    public void WristPointingForward()
                    {
                        Point3 wrist = new Point3(6, 10, 9);
                        double roll = InverseKinematics.GetShoulderRollLeft(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(0, roll, angleTolerance);
                    }

                    [TestMethod]
                    public void WristPointingUp()
                    {
                        Point3 wrist = new Point3(7, 11, 10);
                        double roll = InverseKinematics.GetShoulderRollLeft(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(90, roll, angleTolerance);
                    }
                }

                [TestClass]
                public class ElbowPointingDown
                {
                    private static readonly Point3 elbow = new Point3(8, 9, 10);

                    [TestMethod]
                    public void Inline()
                    {
                        Point3 wrist = new Point3(8, 8, 10);
                        double roll = InverseKinematics.GetShoulderRollLeft(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(0, roll);
                    }

                    [TestMethod]
                    public void WristPointingForward()
                    {
                        Point3 wrist = new Point3(8, 9, 9);
                        double roll = InverseKinematics.GetShoulderRollLeft(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(90, roll, angleTolerance);
                    }

                    [TestMethod]
                    public void WristPointingInside()
                    {
                        Point3 wrist = new Point3(9, 9, 10);
                        double roll = InverseKinematics.GetShoulderRollLeft(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(0, roll, angleTolerance);
                    }
                }

                [TestClass]
                public class ElbowPointingForward
                {
                    private static readonly Point3 elbow = new Point3(8, 10, 9);

                    [TestMethod]
                    public void Inline()
                    {
                        Point3 wrist = new Point3(8, 10, 8);
                        double roll = InverseKinematics.GetShoulderRollLeft(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(0, roll);
                    }

                    [TestMethod]
                    public void WristPointingDown()
                    {
                        Point3 wrist = new Point3(8, 9, 9);
                        double roll = InverseKinematics.GetShoulderRollLeft(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(-90, roll, angleTolerance);
                    }

                    [TestMethod]
                    public void WristPointingInside()
                    {
                        Point3 wrist = new Point3(9, 10, 9);
                        double roll = InverseKinematics.GetShoulderRollLeft(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(0, roll, angleTolerance);
                    }

                    [TestMethod]
                    public void WristPointingUp()
                    {
                        Point3 wrist = new Point3(8, 11, 9);
                        double roll = InverseKinematics.GetShoulderRollLeft(neckToSpine, shoulderL, shoulderR, elbow, wrist);

                        Assert.AreEqual(90, roll, angleTolerance);
                    }
                }
            }

            [TestClass]
            public class ElbowPitch
            {
                private static readonly Vector3 shoulderToElbow = new Vector3(-1, 0, 0);

                [TestMethod]
                public void Inline()
                {
                    Vector3 elbowToWrist = new Vector3(-1, 0, 0);
                    double angle = InverseKinematics.GetElbowAngle(shoulderToElbow, elbowToWrist);

                    Assert.AreEqual(0, angle, angleTolerance);
                }

                [TestMethod]
                public void WristPointingDown()
                {
                    Vector3 elbowToWrist = new Vector3(0, 0, -1);
                    double angle = InverseKinematics.GetElbowAngle(shoulderToElbow, elbowToWrist);

                    Assert.AreEqual(-90, angle, angleTolerance);
                }

                [TestMethod]
                public void WristPointingForward()
                {
                    Vector3 elbowToWrist = new Vector3(0, 0, -1);
                    double angle = InverseKinematics.GetElbowAngle(shoulderToElbow, elbowToWrist);

                    Assert.AreEqual(-90, angle, angleTolerance);
                }

                [TestMethod]
                public void WristPointingUp()
                {
                    Vector3 elbowToWrist = new Vector3(0, 1, 0);
                    double angle = InverseKinematics.GetElbowAngle(shoulderToElbow, elbowToWrist);

                    Assert.AreEqual(-90, angle, angleTolerance);
                }
            }
        }
    }
}
