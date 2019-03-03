using System;
using UnityEngine;

namespace JacobGames.SuperInvoke.Examples
{

		/// <summary>
		/// Figure mover. Service class. It moves GameObjects using a lerp function.
		/// </summary>
		public class FigureMover : MonoBehaviour {

				private Vector3 initialPosition;
				private const float MovingOffset = 3f;


				#region LerpVars
				private bool lerping;
				private Vector3 lerpStartPosition;
				private Vector3 lerpEndPosition;
				private float lerpDurationTime;

				private float timeStartedLerping;
				#endregion


				void Awake () {
						initialPosition = this.transform.localPosition;
				}


				void FixedUpdate() {
						if (lerping) {
								float timeSinceStarted = Time.time - timeStartedLerping;
								float percentageComplete = timeSinceStarted / lerpDurationTime;

								transform.localPosition = Vector3.Lerp(lerpStartPosition, lerpEndPosition, percentageComplete);

								if (percentageComplete >= 1.0f) {
										lerping = false;
								}
						}
				}






				public void MoveTo(Direction direction, float duration = 0.25f) {
						MoveTo(getPositionFromDirection(direction));
				}



				public void MoveTo(Vector3 endPosition, float duration = 0.25f) {		
						timeStartedLerping = Time.time;
						lerpStartPosition = transform.localPosition;
						lerpEndPosition = endPosition;
						lerpDurationTime = duration;
						lerping = true;
				}





				private Vector3 getPositionFromDirection(Direction direction) {
						Vector3 pos = Vector3.zero;

						switch (direction) {
						case Direction.UP:
								pos = new Vector3(0, MovingOffset, 0);
								break;

						case Direction.LEFT:
								pos = new Vector3(-MovingOffset, 0, 0);
								break;

						case Direction.DOWN:
								pos = new Vector3(0, -MovingOffset, 0);
								break;

						case Direction.RIGHT:
								pos = new Vector3(MovingOffset, 0, 0);
								break;

						default:
								pos = Vector3.zero;
								break;
						}

						return pos;
				}



				public void ReturnToInitialPosition() {
						this.transform.localPosition = initialPosition;
				}


		}


}

