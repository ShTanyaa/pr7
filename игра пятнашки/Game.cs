﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace игра_пятнашки
{
  class Game
    {
        static Random rnd=new Random();
        int size;
        int[,] map;
        int space_x, space_y;
        public Game(int size)
        {
            if(size<2) size = 2;
            if (size > 5) size = 5;
            this.size = size;
            map = new int[size, size];

        }

        private int coords_to_position(int x, int y)
        {
            if (x < 0) x = 0;
            if (x > size - 1) x = size - 1;
            if (y < 0) y = 0;
            if (y > size - 1) y = size - 1;
            return y * size + x;
        }
        private void position_to_coords(int postion, out int x, out int y)
        {
            x = postion % size;
            y = postion / size;
        }

        public void start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map[x, y] = coords_to_position(x, y) + 1;
            space_x = size - 1;
            space_y = size - 1;
            map[space_x, space_y] = 0;
        }

        public int get_number(int position)
        {
            int x, y;
            position_to_coords(position, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y];
        }
        public void shift(int position)
        {
            int x, y;
            position_to_coords(position, out x, out y);
            if (Math.Abs(space_x - x) + Math.Abs(space_y - y) != 1)
                return;
            map[space_x, space_y] = map[x, y];
            map[x, y] = 0;
            space_x = x;
            space_y = y;
        }
        public void shift_random()
        {
            int a = rnd.Next(0, 4);
            int x = space_x;
            int y = space_y;
            switch (a)
            {
                case 0: x--; break;
                case 1: x++; break;
                case 2: y--; break;
                case 3: y++; break;
            }
            shift(coords_to_position(x, y));
        }

        public bool the_end()
        {
            if (space_x != size - 1 || space_y != size - 1)
            {
                return false;
            }

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (x == size - 1 && y == size - 1)
                    {
                        continue;
                    }

                    if (map[x, y] != coords_to_position(x, y) + 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}

