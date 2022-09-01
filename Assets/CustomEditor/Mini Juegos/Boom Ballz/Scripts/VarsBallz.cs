using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarsBallz : MonoBehaviour {

	public static int level = 1;
	public static int numberOfBalls = 1;
	public static int newBalls = 1;
	public static int ballHitBottom = 0;
	public static bool lastBallHitBottom = false;
	public static bool startMovingTowardsMainBall = false;
	public static int ballsReachedDistance = 0;
	public static bool firstBallHitBottomCollider = false;
	public static float firstBallHitXPos = 0;
	public static bool canContinue = true;
	public static bool newWaveOfBricks = false;
	public static float speedUpTimer = 0;

	public static void RestartAllVariables() {
		VarsBallz.level = 1;
		VarsBallz.numberOfBalls = 1;
		VarsBallz.newBalls = 1;
		VarsBallz.ballHitBottom = 0;
		VarsBallz.lastBallHitBottom = false;
		VarsBallz.startMovingTowardsMainBall = false;
		VarsBallz.ballsReachedDistance = 0;
		VarsBallz.firstBallHitBottomCollider = false;
		VarsBallz.firstBallHitXPos = 0;
		VarsBallz.canContinue =  true;
		VarsBallz.newWaveOfBricks = false;
		VarsBallz.speedUpTimer = 0;
	}
}
