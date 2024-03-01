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
    internal class Simulation
    {
        private Dictionary<Place, Vector2> positions = new();
        private Dictionary<Place, Vector2> speeds = new();
        private Dictionary<Place, Vector2> forces = new();
        private Dictionary<int, Place> PlaceIndex;

        public float repulsiveFactor = 500000f; //2 mocnina: 500 - abs: 4 // 3. mocnina 35000 - abs: 14
        public float repulsivePower = 3;

        public float PathStiffness = 0.005f; //2 mocnina: 500000 - lin: 0.1
        public float attractivePower = 2;


        public float Friction = 0.1f; //0.1f;
        public float MaxSpeed = 4f; //0.1f;
        public float MinSpeed = 0.01f;//0.1f;
        public float Dt = 0.5f;

        public Vector2 TopLeft { get; set; }
        public Vector2 BottomRight { get; set; }

        public Simulation(Dictionary<int, Place> placeIndex, double width, double height )
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
            Vector2 oldSpeed, newSpeed;
            foreach (Place place in PlaceIndex.Values)
            {
                //newSpeed = speeds[place] + forces[place] * Dt - Vector2.Normalize(speeds[place]) * Friction * Dt;
                oldSpeed = speeds[place];

                newSpeed = oldSpeed + forces[place] * Dt;
                if (oldSpeed != Vector2.Zero)
                    newSpeed -= Vector2.Normalize(oldSpeed) * Friction * Dt;


                if (newSpeed.Length() < MinSpeed)
                    newSpeed = Vector2.Zero;

                newSpeed = Vector2.Clamp(newSpeed, new Vector2(-MaxSpeed, -MaxSpeed), new Vector2(MaxSpeed, MaxSpeed));

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

            Vector2 diff = positions[thisPlace] - positions[otherPlace];
            Vector2 force = RepulsiveForce(diff);
            force += BorderForce(positions[thisPlace]);
            
            if (thisPlace.IsConnectedTo(otherPlace))
                force += AttractiveForce(diff);

            return force;
        }

        private Vector2 RepulsiveForce(Vector2 diffVector)
        {
            return diffVector == Vector2.Zero ? 
                        Vector2.Zero :
                        repulsiveFactor * Vector2.Normalize(diffVector) / MathF.Pow(diffVector.Length(), repulsivePower);            
        }

        private Vector2 AttractiveForce(Vector2 diffVector)
        {
            return -PathStiffness * Vector2.Normalize(diffVector) * MathF.Pow(diffVector.Length(), attractivePower);
        }

        private Vector2 BorderForce(Vector2 position)
        {
            Vector2 borderForce = Vector2.Zero;
            borderForce += RepulsiveForce(position - new Vector2(TopLeft.X, position.Y));
            borderForce += RepulsiveForce(position - new Vector2(BottomRight.X, position.Y));
            borderForce += RepulsiveForce(position - new Vector2(position.X, TopLeft.Y));
            borderForce += RepulsiveForce(position - new Vector2(position.X, BottomRight.Y));
            return borderForce * 0.1f;
        }

        public Vector2 GetPosition(Place place) => positions[place];

    }
}
