using System;

namespace Elite
{
    public class GameObject
    {

 

        public bool getsLit = false;
        public bool visible = true;

        public bool getsClipped = true;
        public bool getsCulled = true;

        public bool filled = false;

        public bool movesWithCamera = false;

        // Instead of euler angles I decided to define rotation with
        // a forward vector and an up vector, because it's (in my opinion)
        // for easier to reason with.
        public Vector3 up = new Vector3(0,1,0);
        public Vector3 forward = new Vector3(0,0,1);

        public Vector3 scale = new Vector3(1,1,1);
        public Vector3 position = new Vector3(0,0,0);
        public Vector3 offset;
        
        
        public short colour = 15;

        public Vector3 lightingDirection = new Vector3(0,0,-1);

    

        public Mesh mesh;


        public char character;

  

 
        public bool isDestroyed = false;


        public virtual void Start() {}
        public virtual void Update(float deltaTime) {}




        public void SetMesh(Mesh _mesh)
        {
            mesh = _mesh;
            offset = (FindLargestSize() / 2f) * -1f;


        }
        public Vector3 FindLargestSize()
        {
            Vector3 result = new Vector3(0,0,0);


            Vector3 topLeft = new Vector3(0,0,0);

            for (int i = 0; i < mesh.tris.Length; i++)
            {
                if(mesh.tris[i].a.x > result.x) result.x = mesh.tris[i].a.x;
                if(mesh.tris[i].a.y > result.y) result.y = mesh.tris[i].a.y;
                if(mesh.tris[i].a.z > result.z) result.z = mesh.tris[i].a.z;

                if(mesh.tris[i].b.x > result.x) result.x = mesh.tris[i].b.x;
                if(mesh.tris[i].b.y > result.y) result.y = mesh.tris[i].b.y;
                if(mesh.tris[i].b.z > result.z) result.z = mesh.tris[i].b.z;

                if(mesh.tris[i].c.x > result.x) result.x = mesh.tris[i].c.x;
                if(mesh.tris[i].c.y > result.y) result.y = mesh.tris[i].c.y;
                if(mesh.tris[i].c.z > result.z) result.z = mesh.tris[i].c.z;
            }

            return result;
        }


    }
}
