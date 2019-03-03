using UnityEngine;
using System.Collections;
using JacobGames.SuperInvoke;
using UnityEngine.UI;

namespace JacobGames.SuperInvoke.Examples 
{
		public class RunRepeatSequence : MonoBehaviour {

				public GameObject Bomb;

				public float InitialDelay;
				public float RepeatRate;
				public int Repeats;

				private ISuperInvokeSequence sequence;

				private FigureMover bombMover;
				private FigureScaler bombScaler;
				private FigureRotator bombRotator;

				private ParticleSystem explosion;



				void Awake() {
						bombMover = Bomb.GetComponent<FigureMover>();
						bombScaler = Bomb.GetComponent<FigureScaler>();
						bombRotator = Bomb.GetComponent<FigureRotator>();

						explosion = Bomb.GetComponentInChildren<ParticleSystem>();
				}
						


				void Start() {
						ComposeSequence();
						sequence.RunRepeat(InitialDelay, RepeatRate, Repeats);
				}


				private void ComposeSequence() {
						sequence = SuperInvoke.CreateSequence();

						sequence.AddMethod(ResetTransform); // reset position, scale, and rotation for every repeat

						// divided by two because there are two movements in two different point
						// so that the repeat and the movements are synced, i.e. total movements time = repeat rate
						float oneMovementDuration = RepeatRate /2f; 


						sequence.AddMethod(()=> bombMover.MoveTo(new Vector2(0, 2.2f), oneMovementDuration)); // move to up

						sequence.AddDelay(oneMovementDuration);
						sequence.AddMethod(()=> bombRotator.RotateZ(20f)); 
						sequence.AddMethod(()=> bombMover.MoveTo(new Vector2(4.5f, -0.5f), oneMovementDuration));

						sequence.AddDelay(oneMovementDuration);
						sequence.AddMethod(()=> bombScaler.Scale(0));
						sequence.AddMethod(()=> explosion.Play());
				}




				private void ResetTransform() {						
						bombMover.ReturnToInitialPosition();	
						bombScaler.ReturnToInitialScale();
						bombRotator.ReturnToInitialRotation();
				}


		}
}


