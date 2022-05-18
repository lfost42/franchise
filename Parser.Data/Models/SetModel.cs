using System;
namespace Franchise.Data.Models
{
    public class SetModel
    {
        int[] parent;   // stores index of parent node
        int[] rank;     //stores rank of perticular node

        /// <summary>
        /// Initialize n natural numbers
        /// </summary>
        public SetModel(int length)
        {
            parent = new int[length];   //initializng length of set
            rank = new int[length];

            //initially making parent of element itself
            for (int i = 0; i < parent.Length; i++)
                parent[i] = i;
        }

        public void MakeSet(int x)
        {
            parent[x] = x;  //making parent itself
            rank[x] = 0;    //initially rank is zero
        }

        public void Union(int x, int y)
        {
            int representativeX = FindSet(x); //finding representative of x
            int representativeY = FindSet(y); //finding representative of y

            //if both has same rank maiking y is x's parent
            if (rank[representativeX] == rank[representativeY])
            {
                rank[representativeY]++; //incrementing rank of y
                parent[representativeX] = representativeY;
            }

            // making parent which is having higher rank
            else if (rank[representativeX] > rank[representativeY])
            { parent[representativeY] = representativeX; }
            else
            { parent[representativeX] = representativeY; }
        }

        public int FindSet(int x)
        {
            if (parent[x] != x)
                parent[x] = FindSet(parent[x]); //path compression
            return parent[x];
        }

        public int FindImmidiateParent(int x)
        {
            return parent[x];
        }

        public int FindRank(int x)
        {
            return rank[x];
        }



    }
}
