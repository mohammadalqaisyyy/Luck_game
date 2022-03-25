using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Mohammad Al-Qaisy

namespace Task_06
{
    class Character
    {
        int x, y, width, height;
        bool killer, alive;
        string id;
        Random random = new Random(System.DateTime.Now.Millisecond);

        public string _id
        {
            get { return id; }
        }
        public int _x
        {
            set { x = value; }
            get { return x; }
        }
        public int _y
        {
            set { y = value; }
            get { return y; }
        }
        public int _width
        {
            get { return width; }
        }
        public int _hieght
        {
            get { return height; }
        }
        public bool _alive
        {
            set { alive = value; }
            get { return alive; }
        }
        public bool _killer
        {
            set { killer = value; }
            get { return killer; }
        }

        public Character(string id, int x, int y, int width, int height)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.killer = false;
            this.alive = true;
        }

        public void SetAsKiller()
        {
            this.killer = true;
        }

        public void Kill(List<Character> players)
        {
            int xLeftPoint = this.x - 10, xRightPoint = this.x + this.width + 10,
                    yTopPoint = this.y - 10, yDownPoint = this.y + this.height + 10;
            int pLx, pRx, pTy, pDy;
            foreach (Character t in players)
            {
                pLx = t.x; pRx = t.x + t.width; 
                pTy = t.y; pDy = t.y + t.height;
                if (t.killer)
                    continue;
                else if (((xLeftPoint <= pLx && pLx <= xRightPoint) || (xLeftPoint <= pRx && pRx <= xRightPoint)) &&
                    ((yTopPoint <= pTy && pTy <= yDownPoint) || (yTopPoint <= pDy && pDy <= yDownPoint)))
                {
                    t._alive = false;
                }
            }
        }

        public void Update()
        {
            this.x = random.Next(0, 900);
            this.y = random.Next(0, 200);
        }
    }
}
