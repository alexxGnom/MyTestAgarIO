using UnityEngine;
using System.Collections;
using System;

namespace MyAgarIO
{
	public abstract class Unit : BaseUnit
	{
		public ITarget Target { private get; set; }

		[SerializeField]
		protected int startWeight;

		[SerializeField]
		protected int maxWeight = 5000;

		[SerializeField]
		private float maxSpeed;

		private float minSpeed = 0.5f;
		private float speed;


		[SerializeField]
		private float scaleFactor = 1.0f;

		private Vector3 startScale;

		private Rigidbody thisRigidbody;
		private Transform thisTransform;
		private SphereCollider thisCollider;

		private Vector3 targetPos;

		void Start()
		{
			this.speed = CalculateSpeed();

			this.Weight = startWeight;

			if (maxWeight < startWeight)
				maxWeight = startWeight;

			thisRigidbody = GetComponent<Rigidbody>();
			thisTransform = transform;
			thisCollider = GetComponent<SphereCollider>();

			this.startScale = thisTransform.localScale;

			targetPos = Vector3.zero;
		}

		void FixedUpdate()
		{
			speed = CalculateSpeed();
			thisTransform.localScale = CalculateScale();
			if (Target == null)
				return;
			targetPos = Target.GetTargetPointForObject(this.gameObject);
			targetPos.z = 0.0f;

			var direction = targetPos - thisTransform.position;
			if (direction.magnitude > 0.1)
			{
				thisRigidbody.MovePosition(thisTransform.position + direction.normalized * Time.fixedDeltaTime * speed);
			}

		}

		void OnTriggerEnter(Collider other)
		{
			var food = other.gameObject.GetComponent<BaseUnit>();
			if (food != null)
				Eat(food);
		}

		protected float CalculateSpeed()
		{
			return  maxSpeed - ((maxSpeed - minSpeed) * (Weight / maxWeight));
		}

		protected Vector3 CalculateScale()
		{
			return startScale + Vector3.one * 0.01f * Weight * scaleFactor;
		}

		protected virtual void Eat(BaseUnit food)
		{
			if (this.Weight > food.Weight && this.Weight < maxWeight)
			{
				this.Weight += food.Weight;
				if (this.Weight > maxWeight)
					this.Weight = maxWeight;
				food.Die();
			}
		}

		public Vector3 GetCurrentTargetPos()
		{
			return targetPos;
		}
	}
}
