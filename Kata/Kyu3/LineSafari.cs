//
// This file is part of Stefan Haglund's CodeWars Kata Solutions Collection (SHCKSC),
// written and maintained by Stefan Haglund (stefan.haglund@me.com).
//
// SHCKSC is free software: you can redistribute it and/or modify it under the terms
// of the GNU General Public License as published by the Free Software Foundation,
// either version 3 of the License, or (at your option) any later version.
//
// SHCKSC is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
// without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License along with this program.
// If not, see <https://www.gnu.org/licenses/>.
//
//-------------------------------------------------------------------------------------------------


// Kata: "Line Safari - Is that a line?" by dinglemouse
// SOLUTION


using Kata;
using Kata.Kyu3;


namespace Kata.Kyu3
{
    public class LineSafari
    {
        private struct Point
        {
            public int y;
            public int x;

            public Point(int y, int x) {
                this.y = y; this.x = x;
            }
        }

        public static bool Line(char[][] grid) {
            int totalTiles; List<Point> starts;

            // get all starting points and total tile count
            starts=new List<Point>(); totalTiles=0;
            for(int y=0; y<grid.Length; y++) {
                for(int x=0; x<grid[y].Length; x++) {
                    if(grid[y][x]!=' ') totalTiles++;
                    if(grid[y][x]=='X') { starts.Add(new Point(y, x)); }
                }
            }

            // there must be two starting tiles (X) and at least
            // one must be a valid path with all tiles visited
            if(starts.Count==2) {
                List<Point> visited;
                if(IsValidPath(grid, starts[0].y, starts[0].x, out visited) && visited.Count==totalTiles) { return true; }
                if(IsValidPath(grid, starts[1].y, starts[1].x, out visited) && visited.Count==totalTiles) { return true; }
            }
            return false;
        }

        private static bool IsValidPath(char[][] grid, int y, int x, out List<Point> visited) {
            IEnumerable<Point>? exits; Point last, pos;

            last=new Point(y, x); pos=new Point(y, x);
            visited=new List<Point>(); visited.Add(pos);

            for(;;) {
                // get all possible exits, except back to already visited
                exits=Exits(grid, pos.y, pos.x).Except(visited);
                // if this is a corner (+), straight ahead is not allowed
                if(grid[pos.y][pos.x]=='+') { exits=exits.Except([new Point(2*pos.y-last.y, 2*pos.x-last.x)]); }
                // if there are multiple possible exits or no exits, quit
                // if there is one and only one exit, go there and continue
                if(exits.Count()!=1) { break; }
                last=pos; pos=exits.First(); visited.Add(pos);
            }

            // at least two tiles must be visited and must be at an end tile (X)
            if(visited.Count()>1 && grid[pos.y][pos.x]=='X') { return true; }
            return false;
        }

        private static IEnumerable<Point> Exits(char[][] grid, int y, int x) {
            List<Point> exits;

            exits=new List<Point>();
            if(IsValidStep(grid, y,x, 1, 0)) { exits.Add(new Point( 1+y, 0+x)); }
            if(IsValidStep(grid, y,x,-1, 0)) { exits.Add(new Point(-1+y, 0+x)); }
            if(IsValidStep(grid, y,x, 0, 1)) { exits.Add(new Point( 0+y, 1+x)); }
            if(IsValidStep(grid, y,x, 0,-1)) { exits.Add(new Point( 0+y,-1+x)); }
            return exits;
        }

        private static bool IsValidStep(char[][] grid, int y, int x, int dy, int dx) {
            char from, to;

            if(WithinBounds(grid, y+dy, x+dx)) {
                from=grid[y][x]; to=grid[y+dy][x+dx];

                // must follow path direction
                if(((from=='-' || to=='-') && dy!=0)) { return false; }
                if(((from=='|' || to=='|') && dx!=0)) { return false; }

                // must go to a valid tile
                return (to=='-' || to=='|' || to=='+' || to=='X');
            }
            return false;
        }

        private static bool WithinBounds(char[][] grid, int y, int x) {
            return (y>=0 && y<grid.Length && x>=0 && x<grid[y].Length);
        }

    }
}
