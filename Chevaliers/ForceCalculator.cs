using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Media.Media3D;

namespace Chevaliers
{
    internal class ForceCalculator
    {
        private Dictionary<Place, Vector2> positions = new();
        private Dictionary<Place, Vector2> speeds = new();
        private Dictionary<Place, Vector2> forces = new();
        private Dictionary<int, Place> PlaceIndex;

        public static float ForceFactor = 500000f; //2 mocnina: 500 - abs: 4 // 3. mocnina 35000 - abs: 14
        public static float PathStiffness = 0.005f; //2 mocnina: 500000 - lin: 0.1

        public static float Friction = 0.1f; //0.1f;
        public static float MinSpeed = 0.01f;//0.1f;
        public static float Dt = 0.5f;

        public ForceCalculator(Dictionary<int, Place> placeIndex, double width, double height )
        {
            Random random = new();

            PlaceIndex = placeIndex;

            foreach (KeyValuePair<int, Place> placeKVP in placeIndex)
            {
                forces[placeKVP.Value] = Vector2.Zero;
                speeds[placeKVP.Value] = Vector2.Zero;
                positions[placeKVP.Value] = new Vector2(
                    (float)(random.NextDouble() * width), 
                    (float)(random.NextDouble() * height)
                );
            }
        }

        public Dictionary<Place, Vector2> Step()
        {
            CalculateForces();
            CalculateSpeeds();
            CalculatePositions();
            return positions;
        }

        private void CalculateForces()
        {
            foreach (Place place in PlaceIndex.Values)
            {
                Vector2 force = Vector2.Zero;
                foreach(Place otherPlace in PlaceIndex.Values)
                {
                    force += GetForce(place, otherPlace);
                }
                forces[place] = force;
            }
        }

        private void CalculateSpeeds()
        {
            Vector2 newSpeed;
            foreach (Place place in PlaceIndex.Values)
            {
                //newSpeed = speeds[place] + forces[place] * Dt - Vector2.Normalize(speeds[place]) * Friction * Dt;

                newSpeed = speeds[place] + forces[place] * Dt;
                if (speeds[place] != Vector2.Zero)
                    newSpeed -= Vector2.Normalize(speeds[place]) * Friction * Dt;


                if (newSpeed.Length() < MinSpeed)
                    newSpeed = Vector2.Zero;

                newSpeed = Vector2.Clamp(newSpeed, new Vector2(-3, -3), new Vector2(3, 3));

                speeds[place] = newSpeed;
            }
        }

        private void CalculatePositions()
        {
            foreach (Place place in PlaceIndex.Values)
            {
                positions[place] += speeds[place] * Dt;
            }
        }

        private Vector2 GetForce(Place thisPlace, Place otherPlace)
        {
            if (thisPlace == otherPlace)
                return Vector2.Zero;

            Vector2 thisPos = positions[thisPlace];
            Vector2 otherPos = positions[otherPlace];
            Vector2 diff = thisPos - otherPos;
            float dist = diff.Length();

            //float distFactor = Vector2.DistanceSquared(positions[thisPlace], positions[otherPlace]);
            float distFactor = MathF.Pow(dist, 3);
            //float distFactor = MathF.Sqrt(Vector2.Distance(positions[thisPlace], positions[otherPlace]));

            Vector2 force = ForceFactor * Vector2.Normalize(diff) / distFactor;
            
            if (thisPlace.IsConnectedTo(otherPlace))
            {
                force -= PathStiffness * Vector2.Normalize(diff) * diff.LengthSquared();
            }

            //Vector2 speed = speeds[thisPlace];
            //if (speed != Vector2.Zero)
            //{ 
            //    Vector2 friction = -Friction * Vector2.Normalize(speeds[thisPlace]) * speed.Length();
            //    force -= friction;
            //}

            return force;
        }

        public Vector2 GetPosition(Place place) => positions[place];

    }
}
